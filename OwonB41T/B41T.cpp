#include "stdafx.h"
#include "B41T.hpp"
#include "data_parser.hpp"
// TODO: Move these somewhere nicer
namespace formatting {


	static constexpr char nib(uint8_t b) {
		uint8_t x = b&0xf;
		return x < 10 ? '0' + x : 'a'+ (x-10);
	}

	static std::string hex(uint8_t x) {
		return std::string({nib(x>>4), nib(x)});
	}
	static std::string hex(uint16_t x) {
		return hex(uint8_t(x>>8)) + hex(uint8_t(x));
	}
	static std::string hex(uint32_t x) {
		return hex(uint16_t(x>>16)) + hex(uint16_t(x));
	}
	static std::string hex(uint64_t x) {
		return hex(uint32_t(x>>32)) + hex(uint32_t(x));
	}

}

std::vector<uint8_t> read_IBuffer(winrt::Windows::Storage::Streams::IBuffer const& ibuf) {
	std::vector<uint8_t> toret(ibuf.Length());
	auto reader = winrt::Windows::Storage::Streams::DataReader::FromBuffer(ibuf);

	for (size_t i = 0; i<toret.size(); ++i)
		toret[i] = reader.ReadByte();

	return toret;
}


double decimal_value(std::array<uint16_t, 3> data) {
	int mag = data[0] & 0x7;
	if (mag == 0b111) {
		return std::numeric_limits<double>::infinity();
	}

	uint16_t val = data[2];
	double sign = 1.0;
	if (val >= 0x7fff) {
		sign = -1.0;
		val &= 0x7fff;
	}

	return sign * val / std::pow(10.0, mag);

}


std::string status_string(std::array<uint16_t, 3> data) {
	uint16_t val = data[1];
	constexpr const char* names[]{"HOLD", "REL", "AUTO", "Bat", "MIN", "MAX", "OL", "MAXMIN"};

	std::string status = "";
	for (int i = 0; i<8; ++i) {
		if ((val&(1<<i)) != 0) {
			if (status.size() > 0)
				status += ' ';
			status += names[i];
		}
	}
	return status;
}


const char* func_string(std::array<uint16_t, 3> data) {
	constexpr const char* funcs[]{"V DC", "V AC", "A DC", "A AC", "Ohm", "Farad", "Hz", "Duty", "TempC", "TempF", "Volts Diode", "Ohms Continuity", "hFE", "NCV/ADP"};
	return funcs[((data[0] >> 6) & 0xf)%14];
}

const char* scale_string(std::array<uint16_t, 3> data) {
	constexpr const char* scales[]{"%", "n", "u", "m", "", "k", "M", "G"};
	return scales[(data[0] >> 3) & 0x7];
}
double scale_factor(std::array<uint16_t, 3> data) {
	constexpr double scales[]{0.01, 1e-9, 1e-6, 1e-3, 1.0, 1e3, 1e6, 1e9};
	return scales[(data[0] >> 3) & 0x7];
}

std::string scientific_string(std::array<uint16_t, 3> data) {
	std::ostringstream oss;
	oss << std::setprecision(4) << std::scientific << decimal_value(data);
	return oss.str();
}


// returns the value from the display with the same format/number of digits as displayed
std::string value_string(std::array<uint16_t, 3> data) {
	int mag = data[0] & 0x7;
	//return std::to_string(mag) + " " + formatting::hex(data[2]);
	if (mag == 0b111)
		return "OL";
	
	uint16_t val = data[2];
	bool negative = (1<<15) & val;
	
	// NOTE: there has to be a simple way to do this that i'm overlooking
	// But I cannot figure out a universal way to make the string returned here
	// exactly match the multimeter screen
	auto posPart = [](uint16_t val, int mag) {
		auto v = std::to_string(val);
		std::string r = std::string(5-v.size(), '0') + v;
		auto loc = r.insert(r.begin() + (6 -mag - 1), '.');

		auto it = r.begin();
		for (; it<loc-1; ++it)
			if (*it != '0' || *(it+1) == '.')
				break;
		return r.substr((it-r.begin()));
	};
	// Append the negative symbol if needed
	return negative ? "-" + posPart(val&0x7fff, mag) : posPart(val, mag);
}





// TODO: Create a class to handle processing the data
// all of these formatting parts should be put into a class where the constructor takes the vector
// of bytes and splits everything up into fields for easy processing once this program gets more
// complicated




std::string display_string(std::vector<uint8_t> bytes) {
	if (bytes.size() != 6)
		return "BAD DATA COLLECTION";

	std::array<uint16_t, 3> data;

	for (auto i = 0; i<3; ++i)	{
		data[i] = uint16_t(bytes[2*i] | uint16_t(bytes[2*i+1] << 8));
	}

	data_parser dp(bytes);




	

	return value_string(data) + " " + scale_string(data) + " " + func_string(data) + "\t" + status_string(data)
		 +"\t::\t" + dp.formatted_string();
	//return value_string(data) + " " + scale_string(data) + " " + func_string(data) + "\t" + status_string(data);
	//return std::to_string(decimal_value(data)) + " " + scaleString + " " + funcString + "\t" + status_string(data);
	//return std::to_string(decimal_value(data)) + " " + scaleString + " " + funcString + "\t" + status_string(data) + '\t' + value_string(data);
	//return std::to_string(decimal_value(data)) + " " + scaleString + " " + funcString + "\t" + status_string(data);
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
	std::cerr << "Sending command: " << std::hex << cmd << std::endl;
	writer.WriteInt16(cmd);

	auto status = co_await ctrlCharacteristic.WriteValueAsync(writer.DetachBuffer());

	co_return status == winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCommunicationStatus::Success;
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
		std::cout << display_string(buf) << std::endl;
	});
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

	if (!registerNotifications().get())
		co_return false;


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