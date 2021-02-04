#include "stdafx.h"
#include "B41T.hpp"
#include "data_parser.hpp"
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

		// Thread-global list of the addresses and names found to avoid reporting or checking the same device more than once
	static struct {
		std::set<std::pair<uint64_t, std::wstring>> addrs;
		std::mutex mut;
	} foundList;

	using namespace winrt::Windows::Devices::Bluetooth;
	using namespace winrt::Windows::Devices::Bluetooth::Advertisement;

	bleAdvertisementWatcher.ScanningMode(Advertisement::BluetoothLEScanningMode::Active);


	bleAdvertisementWatcher.Received([this, nameSubstrMatch](BluetoothLEAdvertisementWatcher const& watcher, BluetoothLEAdvertisementReceivedEventArgs const& eventArgs) {
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
		std::wcerr << "FOUND: " << std::hex << eventArgs.BluetoothAddress() << "\t" << name << std::endl;

		if (name.find(nameSubstrMatch) != std::wstring::npos) {
			std::cerr << "\nFOUND OWON B41T+" << std::endl;
			watcher.Stop(); // End the advertisement watcher, we don't need it anymore

			bool status = connectByAddress(eventArgs.BluetoothAddress()).get();

			if (!status) {
				std::cerr << "Something went wrong while opening the device" << std::endl;
			}

		}

	});

	// Start looking for the meter
	bleAdvertisementWatcher.Start();
}



concurrency::task<bool> B41T::sendControl(uint16_t cmd) {
	winrt::Windows::Storage::Streams::DataWriter writer;
	writer.ByteOrder(winrt::Windows::Storage::Streams::ByteOrder::LittleEndian);
	std::cerr << "Sending Control: " << std::hex << cmd << std::endl;
	writer.WriteInt16(cmd);

	auto status = co_await ctrlCharacteristic.WriteValueAsync(writer.DetachBuffer());

	co_return status == winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCommunicationStatus::Success;
}



concurrency::task<bool> B41T::sendCommand(const std::vector<uint8_t>& buf) {
	if (buf.size() != 16) {
		std::cerr << "WARNING: Attempting to send command of length " << buf.size() << std::endl;
	}

	winrt::Windows::Storage::Streams::DataWriter writer;
	//writer.ByteOrder(winrt::Windows::Storage::Streams::ByteOrder::LittleEndian);
	std::cerr << "Sending command: " <<  std::string_view(reinterpret_cast<const char*>(buf.data()), buf.size()) << std::endl;
	//writer.WriteInt32(cmd);
	winrt::array_view<const uint8_t> view(buf);
	writer.WriteBytes(buf);


	decltype(auto) status = co_await cmdCharacteristic.WriteValueWithResultAsync(writer.DetachBuffer());
	//status.
	//status.Status()
	co_return status.Status() == winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCommunicationStatus::Success;
	//auto status = co_await cmdCharacteristic.WriteValueAsync(writer.DetachBuffer());
	//co_return status == winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCommunicationStatus::Success;
}

concurrency::task<bool> B41T::sendCommand(std::string_view cmd) {
	if (cmd.size() > 16) {
		std::cerr << "Attempting to send a command longer than 15 bytes" << std::endl;
		co_return false;
	}
	std::vector<uint8_t> buf(16); // zero filled
	std::copy(cmd.begin(), cmd.end(), buf.begin());

	co_return co_await sendCommand(buf);
}

concurrency::task<uint32_t> B41T::queryOfflineLength() {
	auto status = sendCommand("*READlen?").get();
	if (!status) {
		std::cerr << "Failed to send query for recording length" << std::endl;
		co_return false;
	}

	using namespace winrt::Windows::Devices::Bluetooth;
	using namespace GenericAttributeProfile;
	//Sleep(2000);
	// Holy crap, it took a while to figure out that I was doing this correctly, it's just that
	// windows caches characteristic values by default!!!
	cmdCharacteristic.ReadValueAsync(BluetoothCacheMode::Uncached);
	decltype(auto) result = cmdCharacteristic.ReadValueAsync().get();
	//decltype(auto) result = co_await cmdCharacteristic.ReadValueAsync();
	auto resultStatus = result.Status();

	if (resultStatus != GattCommunicationStatus::Success) {
		std::cerr << "Failed to read length" << std::endl;
		co_return false;
	}

	auto value = read_IBuffer(result.Value());
	eecho(value.size());

	// TODO: Do not rely on machine byte order for this
	uint32_t size = *reinterpret_cast<const uint32_t*>(value.data());

	std::cerr << std::hex << value << std::endl;
	std::cerr << "OFFLINE SIZE: " << std::hex << size << '\t' << std::dec << size << std::endl;

	co_return size;
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




	readCharacteristic.ValueChanged([](GattCharacteristic const& , GattValueChangedEventArgs const& args) {
		auto buf = read_IBuffer(args.CharacteristicValue());
		// for (const auto& b : buf) std::cout << formatting::hex(b) << ' '; std::cout << std::endl;
		data_parser dp(buf);
		std::cout << dp.formattedString() << std::endl;
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
		"\tAddr:\t"			<< std::hex << device.BluetoothAddress() << '\n' <<
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