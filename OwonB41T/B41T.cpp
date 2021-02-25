#include "stdafx.h"
#include "B41T.hpp"
#include "data_parser.hpp"

#include "packet_handler.hpp"

#include <cctype>
// TODO: Move these somewhere nicer


std::vector<uint8_t> read_IBuffer(winrt::Windows::Storage::Streams::IBuffer const& ibuf) {
	std::vector<uint8_t> toret(ibuf.Length());
	auto reader = winrt::Windows::Storage::Streams::DataReader::FromBuffer(ibuf);

	for (size_t i = 0; i<toret.size(); ++i)
		toret[i] = reader.ReadByte();

	return toret;
}



void B41T::waitUntilConnected() {
	std::unique_lock<std::mutex> lk(mut);
	connecting_cv.wait(lk);
}



void B41T::connectByName(std::wstring nameSubstrMatch) {
	connectByNames({nameSubstrMatch});
}




void B41T::connectByNames(std::vector<std::wstring> nameSubstrMatches) {

		// Thread-global list of the addresses and names found to avoid reporting or checking the same device more than once
	static struct {
		std::set<std::pair<uint64_t, std::wstring>> addrs;
		std::mutex mut;
	} foundList;

	using namespace winrt::Windows::Devices::Bluetooth;
	using namespace winrt::Windows::Devices::Bluetooth::Advertisement;

	bleAdvertisementWatcher.ScanningMode(Advertisement::BluetoothLEScanningMode::Active);


	bleAdvertisementWatcher.Received([this, nameSubstrMatches](BluetoothLEAdvertisementWatcher const& watcher, BluetoothLEAdvertisementReceivedEventArgs const& eventArgs) {
		{ // Track advertisements
			std::lock_guard<std::mutex> guard(foundList.mut);

			decltype(foundList.addrs)::key_type key(eventArgs.BluetoothAddress(), eventArgs.Advertisement().LocalName().c_str());
			// Skip this result if it is a duplicate advertisement
			if (foundList.addrs.find(key) == foundList.addrs.end()) {
				foundList.addrs.emplace(key);
			} else {
				return;
			}
		}


		std::wstring name(eventArgs.Advertisement().LocalName().c_str());
		std::wcerr << "FOUND: " << std::hex << eventArgs.BluetoothAddress() << std::dec << "\t" << name << std::endl;

		for (const auto& nameSubstr : nameSubstrMatches) {
			if (name.find(nameSubstr) != std::wstring::npos) {
				std::cerr << "\nFOUND OWON B41T+" << std::endl;
				watcher.Stop(); // End the advertisement watcher, we don't need it anymore

				bool status = connectByAddress(eventArgs.BluetoothAddress()).get();

				if (!status) {
					std::cerr << "Something went wrong while opening the device" << std::endl;
				}

			}
		}

	});

	// Start looking for the meter
	bleAdvertisementWatcher.Start();
}



concurrency::task<bool> B41T::sendControl(uint16_t cmd) {
	winrt::Windows::Storage::Streams::DataWriter writer;
	writer.ByteOrder(winrt::Windows::Storage::Streams::ByteOrder::LittleEndian);
	std::cerr << "Sending Control: " << std::hex << cmd << std::dec << std::endl;
	writer.WriteInt16(cmd);

	auto status = co_await ctrlCharacteristic.WriteValueAsync(writer.DetachBuffer());

	co_return status == winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCommunicationStatus::Success;
}



concurrency::task<bool> B41T::sendCommand(const std::vector<uint8_t>& buf) {
	if (buf.size() != 16) {
		std::cerr << "WARNING: Attempting to send command of length " << buf.size() << std::endl;
	}

	winrt::Windows::Storage::Streams::DataWriter writer;
	std::cerr << "Sending command: " <<  std::string_view(reinterpret_cast<const char*>(buf.data()), buf.size()) << std::endl;
	
	winrt::array_view<const uint8_t> view(buf);
	writer.WriteBytes(buf);


	decltype(auto) status = co_await cmdCharacteristic.WriteValueWithResultAsync(writer.DetachBuffer());
	co_return status.Status() == winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCommunicationStatus::Success;
}

concurrency::task<bool> B41T::sendCommand(std::string_view cmd) {
	if (cmd.size() > 15) {
		std::cerr << "Attempting to send a command longer than 15 bytes" << std::endl;
		co_return false;
	}
	std::vector<uint8_t> buf(16); // zero filled
	std::copy(cmd.begin(), cmd.end(), buf.begin());

	co_return co_await sendCommand(buf);
}


concurrency::task<bool> B41T::sendRenameCommand(std::string_view sv) {
	if (sv.size() > 14) {
		std::cerr << "rename strings cannot be longer than 14 characters" << std::endl;
		co_return false;
	}
	for (auto&& c : sv) 
		if (!std::isprint(c) || c == '?' || c == '*' || c == '@' || c == ',') { // blacklist these to be safe
			std::cerr << "rename strings cannot contain ceratain special characters" << std::endl;
			co_return false;
		}
	
	std::vector<uint8_t> buf(16); // zero filled
	buf[0] = '@';
	std::copy(sv.begin(), sv.end(), buf.begin()+1);

	co_return co_await sendCommand(buf);
}






concurrency::task<bool> B41T::sendDateCommand() {
	std::time_t tt = std::time(nullptr);
	std::tm tm;

	auto failure = localtime_s(&tm, &tt);
	if (failure) {
		std::cerr << "Could not get current time and date" << std::endl;
		co_return false;
	}


	constexpr std::string_view prefix = "*DATe"; // why did they use lowercase e?
	std::vector<uint8_t> cmd(16);

	auto it = std::copy(prefix.begin(), prefix.end(), cmd.begin());
	
	int year = tm.tm_year + 1900;
	*it++ = uint8_t(year/100);
	*it++ = uint8_t(year%100);

	*it++ = uint8_t(tm.tm_mon + 1);
	*it++ = uint8_t(tm.tm_mday);
	
	*it++ = uint8_t(tm.tm_hour);
	*it++ = uint8_t(tm.tm_min);
	*it++ = uint8_t(tm.tm_sec);

	std::cerr << "sending date command: \"" << cmd << "\"" << std::endl;

	co_return co_await sendCommand(cmd);
}

concurrency::task<bool> B41T::sendRecordCommand(uint32_t interval, uint32_t count) {
	if (count > 10000) {
		std::cerr << "Cannot record more than 10000 readings" << std::endl;
		co_return false;
	}
	if (!interval) {
		std::cerr << "Recording interval cannot be 0"<< std::endl;
		co_return false;
	}
	constexpr std::string_view prefix = "*RECOrd,"; // such weird command syntax
	
	std::vector<uint8_t> cmd(16);
	auto it = std::copy(prefix.begin(), prefix.end(), cmd.begin());


	// TODO: Endian issue here. handle it properly in the future! Little endian works here
	auto tgt = reinterpret_cast<uint32*>(cmd.data()) + 2;
	tgt[0] = interval;
	tgt[1] = count;

	std::cerr << "sending record start command: \"" << cmd << "\"" << std::endl;

	co_return co_await sendCommand(cmd);
}

concurrency::task<bool> B41T::startRecording(uint32_t interval, uint32_t count) {
	if (!co_await sendDateCommand()) {
		std::cerr << "cannot start recording" << std::endl;
		co_return false;
	}
	co_return co_await sendRecordCommand(interval, count);
}



concurrency::task<uint32_t> B41T::queryOfflineLength() {
	auto status = sendCommand("*READlen?").get();
	if (!status) {
		std::cerr << "Failed to send query for recording length" << std::endl;
		co_return 0;
	}

	using namespace winrt::Windows::Devices::Bluetooth;
	using namespace GenericAttributeProfile;
	// Holy crap, it took a while to figure out that I was doing this correctly, it's just that
	// windows caches characteristic values by default!!!
	cmdCharacteristic.ReadValueAsync(BluetoothCacheMode::Uncached);
	decltype(auto) result = cmdCharacteristic.ReadValueAsync().get();
	auto resultStatus = result.Status();

	if (resultStatus != GattCommunicationStatus::Success) {
		std::cerr << "Failed to read length" << std::endl;
		co_return 0;
	}

	auto value = read_IBuffer(result.Value());

	// TODO: Do not rely on machine byte order for this
	uint32_t size = *reinterpret_cast<const uint32_t*>(value.data());

	//std::cerr << std::hex << value << std::endl << "OFFLINE SIZE: " << std::hex << size << '\t' << std::dec << size << " records" << std::endl;

	co_return size;
}


concurrency::task<bool> B41T::startDownload() {
	auto size = co_await queryOfflineLength();
	std::cerr << "Will attempt to download " << std::dec << size << " bytes" << std::endl;

	packets.setExpectedBytes(size);
	packets.clear();

	// TODO: will this be a race condition? What if the download command goes through before this next statement
	auto status = co_await sendCommand("*READ1?");

	if (!status) {
		std::cerr << "Failed to send query for recording length" << std::endl;
		co_return false;
	}

	co_return true;

}





// Given a UID and a member reference as a target, open the characteristic
concurrency::task<bool> B41T::getCharacteristic(winrt::guid uid, winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCharacteristic& target, std::string_view characteristicName) {
	using namespace winrt::Windows::Devices::Bluetooth;

	decltype(auto) characteristicResult = co_await service.GetCharacteristicsForUuidAsync(uid);
	if (characteristicResult.Status() != GenericAttributeProfile::GattCommunicationStatus::Success) {
		std::cerr << "Failed to find " << characteristicName << " characteristic" << std::endl;
		co_return false;
	}
	target = characteristicResult.Characteristics().GetAt(0);
	co_return true;
}

concurrency::task<bool> B41T::registerNotifications() {
	using namespace winrt::Windows::Devices::Bluetooth;
	using namespace GenericAttributeProfile;


	if (readCharacteristic.CharacteristicProperties() != GattCharacteristicProperties::Notify) {
		std::cerr << "Does not have notify property" << std::endl;
		co_return false;
	}


	GattCommunicationStatus status = co_await readCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue::Notify);
	if (status != GattCommunicationStatus::Success) {
		std::cerr << "Connection Failed" << std::endl;
		co_return false;
	}

	readCharacteristic.ValueChanged([this](GattCharacteristic const& , GattValueChangedEventArgs const& args) {

		packets << read_IBuffer(args.CharacteristicValue());

		if (packets.isDownloading()) {
			std::cerr << "downloading: " << packets.downloadedPercent() << '%' <<  std::endl;
		} else if(packets.isDoneDownloading()) { // Just finished downloading, data has not been handled yet
			
			auto dd = packets.getDownloadedData();
			dd.print();

			packets.clear();
				
		} else {
			data_parser dp(packets.getPrevious());
			if (dp.isValidFromData()) {
				std::cout << dp.formattedString() << std::endl;
			} else {
				std::cerr << "BAD DATA PASSED TO PARSER" << std::endl;
			}
		}


	});


	registered = true;
	co_return true;
}

concurrency::task<bool> B41T::connectByAddress(unsigned long long deviceAddress) {
	// TODO: Better mutext handling
	//std::unique_lock<std::mutex> lock(mut); // Ensure nothing can go wrong in very odd circumstances
	if (opened) {
		std::cerr << "Trying to reopen connection to multimeter that is already open" << std::endl;
		co_return false;
	}

	using namespace winrt::Windows::Devices::Bluetooth;
	device = co_await BluetoothLEDevice::FromBluetoothAddressAsync(deviceAddress);
	std::wcerr <<
		"Meter Info:\n" <<
		"\tName:\t"			<< device.Name().c_str() << '\n' <<
		"\tAddr:\t"			<< std::hex << device.BluetoothAddress() << std::dec << '\n' <<
		"\tId:\t"				<< device.DeviceId().c_str()  << "\n\n";


	decltype(auto) services = co_await device.GetGattServicesForUuidAsync(serviceUUID);
	if (services.Status() != GenericAttributeProfile::GattCommunicationStatus::Success) {
		std::cerr << "Failed to find service uuid" << std::endl; // TODO: Throw exception?
		co_return false;
	}
	service = services.Services().GetAt(0);



	if (!getCharacteristic(cmdCharacteristicUUID, cmdCharacteristic, "cmd").get())
		co_return false;

	if (!getCharacteristic(ctrlCharacteristicUUID, ctrlCharacteristic, "ctrl").get())
		co_return false;

	if (!getCharacteristic(readCharacteristicUUID, readCharacteristic, "read").get())
		co_return false;



	std::cerr << "done finding characteristics" << std::endl;

	if (!co_await registerNotifications())
		co_return false;


	connecting_cv.notify_all();
	opened = true;

	co_return true; // TODO: Other returns
}


concurrency::task<bool> B41T::hold(const buttons::button& b) {
	return sendControl(b.hold());
}
concurrency::task<bool> B41T::press(const buttons::button& b) {
	return sendControl(b.press());
}

concurrency::task<bool> B41T::hold(char c) {
	return hold(buttons::get(c));
}

concurrency::task<bool> B41T::press(char c) {
	return c >= 'A' && c <= 'Z' 
		? hold(c-'A'+'a') 
		: press(buttons::get(c));
}