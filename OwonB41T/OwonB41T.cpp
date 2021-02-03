/** OwonB41T.cpp
 * Jeffrey Cash
 * 
 */


#include "stdafx.h"

#include "B41T.hpp"




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



//concurrency::task<bool> sendControl(winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCharacteristic& characteristic, uint16_t cmd) {
//	//winrt::Windows::Storage::Streams::IBuffer buf;
//	winrt::Windows::Storage::Streams::DataWriter writer;
//	writer.ByteOrder(winrt::Windows::Storage::Streams::ByteOrder::LittleEndian);
//
//	writer.WriteInt16(cmd);
//
//	auto status = co_await characteristic.WriteValueAsync(writer.DetachBuffer());
//
//	co_return status == winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCommunicationStatus::Success;
//}



std::vector<uint8_t> read_IBuffer(winrt::Windows::Storage::Streams::IBuffer const& ibuf) {
	std::vector<uint8_t> toret(ibuf.Length());
	auto reader = winrt::Windows::Storage::Streams::DataReader::FromBuffer(ibuf);

	for (size_t i = 0; i<toret.size(); ++i)
		toret[i] = reader.ReadByte();

	return toret;
}


double decimal_value(std::array<uint16_t, 3> data)
{
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



std::string status_string(const std::array<uint16_t, 3>& data)
{
	uint16_t val = data[1];
	std::string names[]{"HOLD", "REL", "AUTO", "Bat", "MIN", "MAX", "OL", "MAXMIN"};

	std::string status = "";
	for (int i = 0; i<8; ++i)
	{
		if ((val&(1<<i)) != 0)
		{
			if (status.size() > 0)
			{
				status += " ";
			}
			status += names[i];

		}
	}
	return status;
}


const char* func_string(const std::array<uint16_t, 3>& data) {
	constexpr const char* funcs[]{"V DC", "V AC", "A DC", "A AC", "Ohm", "Farad", "Hz", "Duty", "TempC", "TempF", "Volts Diode", "Ohms Continuity", "hFE"};
	return funcs[((data[0] >> 6) & 0xf)%13];
}

const char* scale_string(const std::array<uint16_t, 3>& data) {
	constexpr const char* scales[]{"%", "n", "u", "m", "", "k", "M"};
	return scales[((data[0] >> 3) & 0x7)%7];
}

std::string display_string(std::vector<uint8_t> bytes)
{
	std::array<uint16_t, 3> data;
	//uint16_t chunks = new ushort[3];

	for (int i = 0; i<3; ++i)
	{
		data[i] = uint16_t(bytes[2*i] | uint16_t(bytes[2*i+1] << 8));
		//chunks[i] |= (ushort)(data[1] << 8);
	}

	std::string funcString = func_string(data);

	std::string scaleString = scale_string(data);

	return std::to_string(decimal_value(data)) + " " + scaleString + " " + funcString + "\t" + status_string(data);

}








//
//struct OwonB41 {
//
//	inline static auto serviceUUID						= winrt::Windows::Devices::Bluetooth::BluetoothUuidHelper::FromShortId(0xfff0);
//	inline static auto cmdCharacteristicUUID  = winrt::Windows::Devices::Bluetooth::BluetoothUuidHelper::FromShortId(0xfff1);
//	inline static auto ctrlCharacteristicUUID	= winrt::Windows::Devices::Bluetooth::BluetoothUuidHelper::FromShortId(0xfff3);
//	inline static auto readCharacteristicUUID = winrt::Windows::Devices::Bluetooth::BluetoothUuidHelper::FromShortId(0xfff4);
//
//	winrt::Windows::Devices::Bluetooth::Advertisement::BluetoothLEAdvertisementWatcher bleAdvertisementWatcher;
//
//
//
//	winrt::Windows::Devices::Bluetooth::BluetoothLEDevice device{nullptr};
//	winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattDeviceService service{nullptr};
//	winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCharacteristic cmdCharacteristic{nullptr};
//	winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCharacteristic ctrlCharacteristic{nullptr};
//	winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCharacteristic readCharacteristic{nullptr};
//
//	std::mutex mut{};
//	bool opened{false};
//	
//
//
//
//
//
//
//
//
//	// TODO: Move into OwonB41T class
//	void scanByName(std::wstring nameSubstrMatch = L"B41T+") {
//
//		// Thread-global list of the addresses and names found to avoid reporting or checking the same device more than once
//		static struct {
//			std::set<std::pair<uint64_t, std::wstring>> addrs;
//			std::mutex mut;
//		} foundList;
//
//		using namespace winrt::Windows::Devices::Bluetooth;
//		using namespace winrt::Windows::Devices::Bluetooth::Advertisement;
//
//		bleAdvertisementWatcher.ScanningMode(Advertisement::BluetoothLEScanningMode::Active);
//
//
//		bleAdvertisementWatcher.Received([this,nameSubstrMatch](BluetoothLEAdvertisementWatcher const& watcher, BluetoothLEAdvertisementReceivedEventArgs const& eventArgs) {
//			{ // Track advertisements
//				std::lock_guard<std::mutex> guard(foundList.mut);
//
//				decltype(foundList.addrs)::key_type key(eventArgs.BluetoothAddress(), eventArgs.Advertisement().LocalName().c_str());
//				// Skip this result if it is a duplicate advertisement
//				if (auto addr = eventArgs.BluetoothAddress(); foundList.addrs.find(key) == foundList.addrs.end()) {
//					foundList.addrs.emplace(key);
//				} else {
//					return;
//				}
//			}
//
//
//			std::wstring name(eventArgs.Advertisement().LocalName().c_str());
//			std::wcerr << "FOUND: " << std::hex << eventArgs.BluetoothAddress() << "\t" << name << std::endl;
//
//			if (name.find(nameSubstrMatch) != std::wstring::npos) {
//				std::cerr << "\nFOUND OWON B41T+" << std::endl;
//				watcher.Stop(); // End the advertisement watcher, we don't need it anymore
//
//				bool status = openByAddress(eventArgs.BluetoothAddress()).get();
//
//				if (!status) {
//					std::cerr << "Something went wrong while opening the device" << std::endl;
//				}
//
//			}
//
//		});
//
//		// Start looking for the meter
//		bleAdvertisementWatcher.Start();
//	}
//
//
//private:
//	concurrency::task<bool> sendControl(uint16_t cmd) {
//		winrt::Windows::Storage::Streams::DataWriter writer;
//		writer.ByteOrder(winrt::Windows::Storage::Streams::ByteOrder::LittleEndian);
//		std::cerr << "Sending command: " << std::hex << cmd << std::endl;
//		writer.WriteInt16(cmd);
//
//		auto status = co_await ctrlCharacteristic.WriteValueAsync(writer.DetachBuffer());
//
//		co_return status == winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCommunicationStatus::Success;
//	}
//
//
//
//	// Given a UID and a member reference as a target, open the characteristic
//	concurrency::task<bool> getCharacteristic(winrt::guid uid, winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCharacteristic& target, std::string_view characteristicName = "a") {
//		using namespace winrt::Windows::Devices::Bluetooth;
//
//		auto characteristicResult = co_await service.GetCharacteristicsForUuidAsync(uid);
//		if (characteristicResult.Status() != GenericAttributeProfile::GattCommunicationStatus::Success) {
//			std::cerr << "Failed to find " << characteristicName << " characteristic" << std::endl;
//			co_return false;
//		}
//		target = characteristicResult.Characteristics().GetAt(0);
//		co_return true;
//	}
//
//	concurrency::task<bool> registerNotifications() {
//		using namespace winrt::Windows::Devices::Bluetooth;
//		using namespace GenericAttributeProfile;
//
//
//		if (readCharacteristic.CharacteristicProperties() != GattCharacteristicProperties::Notify) {
//			std::cerr << "Does not have notify property" << std::endl;
//			co_return false;
//		}
//
//
//		GattCommunicationStatus status = co_await readCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue::Notify);
//		if (status != GattCommunicationStatus::Success) {
//			std::cerr << "Connection Failed" << std::endl;
//			co_return false;
//		}
//
//		readCharacteristic.ValueChanged([](GattCharacteristic const& charateristic, GattValueChangedEventArgs const& args) {
//			auto buf = read_IBuffer(args.CharacteristicValue());
//			// for (const auto& b : buf) std::cout << formatting::hex(b) << ' '; std::cout << std::endl;
//			std::cout << display_string(buf) << std::endl;
//		});
//		co_return true;
//	}
//
//public:
//
//	concurrency::task<bool> openByAddress(unsigned long long deviceAddress) {
//		std::unique_lock<std::mutex>(mut); // Ensure nothing can go wrong in very odd circumstances
//		if (opened) {
//			std::cerr << "Trying to reopen connection to multimeter that is already open" << std::endl;
//			co_return false;
//		}
//
//		using namespace winrt::Windows::Devices::Bluetooth;
//		device = co_await BluetoothLEDevice::FromBluetoothAddressAsync(deviceAddress);
//		std::wcerr << 
//			"Meter Info:\n" <<
//			"\tName:\t"			<< device.Name().c_str() << '\n' <<
//			"\tAddr:\t"			<< std::hex << device.BluetoothAddress() << '\n' <<
//			"\tId:\t"				<< device.DeviceId().c_str()  << "\n\n";
//
//
//		auto services = co_await device.GetGattServicesForUuidAsync(serviceUUID);
//		if (services.Status() != GenericAttributeProfile::GattCommunicationStatus::Success) {
//			std::cerr << "Failed to find service uuid" << std::endl; // TODO: Throw exception?
//			co_return false;
//		}
//		service = services.Services().GetAt(0);
//
//
//
//		if (!getCharacteristic(cmdCharacteristicUUID, cmdCharacteristic, "cmd").get())
//			co_return false;
//
//		if (!getCharacteristic(ctrlCharacteristicUUID, ctrlCharacteristic, "ctrl").get())
//			co_return false;
//
//		if (!getCharacteristic(readCharacteristicUUID, readCharacteristic, "read").get())
//			co_return false;
//
//
//
//		std::cerr << "done finding characteristics" << std::endl;
//
//		if (registerNotifications().get())
//			co_return false;
//		
//
//		opened = true;
//
//		co_return true; // TODO: Other returns
//	}
//
//
//
//
//
//
//	struct buttons {
//		struct button {
//			static constexpr uint16_t short_press(uint8_t code) {
//				return uint16_t(1<<8) | (code&uint8_t(0xf));
//			}
//			static constexpr uint16_t long_press(uint8_t code) {
//				return (code & uint8_t(0xf));
//			}
//			uint8_t code;
//			
//
//			constexpr uint16_t press() const {
//				return short_press(code);
//			}
//			constexpr uint16_t hold() const {
//				return long_press(code);
//			}
//
//		};
//
//		static inline constexpr button none  {uint8_t(0)};
//		static inline constexpr button select{uint8_t(1)};
//		static inline constexpr button range{	uint8_t(2)};
//		static inline constexpr button hold{	uint8_t(3)};
//		static inline constexpr button rel{		uint8_t(4)};
//		static inline constexpr button hz{		uint8_t(5)};
//		static inline constexpr button max{		uint8_t(6)};
//		static inline constexpr button all{		uint8_t(7)};
//		
//		static inline std::map<char, const button*> map{
//			{'s', &select},
//			{'r', &range},
//			{'h', &hold},
//			{'d', &rel},
//			{'z', &hz},
//			{'m', &max},
//			{'a', &all},
//		};
//		static const button& get(char c) {
//			if (auto it = map.find(c); it!=map.end()) {
//				return *(it->second);
//			} else {
//				return none;
//			}
//		}
//
//	};
//
//	
//
//	
//	
//	auto hold(const buttons::button& b) {
//		return sendControl(b.hold());
//	}
//	auto press(const buttons::button& b) {
//		return sendControl(b.press());
//	}
//
//	auto hold(char c) {
//		return hold(buttons::get(c));
//	}
//
//	auto press(char c) {
//		return c >= 'A' && c <= 'Z' 
//			? hold(c-'A'+'a') 
//			: press(buttons::get(c));
//	}
//
//};







// TODO: Move these to somewhere tidier
B41T meter;









//int main(int argc, char* argv[]) {
int main(Platform::Array<Platform::String^>^ args) {
	winrt::init_apartment();
	//Microsoft::WRL::Wrappers::RoInitializeWrapper initialize(RO_INIT_MULTITHREADED);
	
	// Not sure if necesssary, but I'm leaving this here for now until I figure out. All UWP BLE examples had something like this,
	/// But I cannot do SDDL stuff here because it is not UWP
	/// L"O:BAG:BAD:(A;;0x7;;;PS)(A;;0x3;;;SY)(A;;0x7;;;BA)(A;;0x3;;;AC)(A;;0x3;;;LS)(A;;0x3;;;NS)"
	//(void)CoInitializeSecurity(nullptr, -1, nullptr, nullptr, RPC_C_AUTHN_LEVEL_DEFAULT, RPC_C_IMP_LEVEL_IDENTIFY, NULL, EOAC_NONE, nullptr);

	

	std::wstring nameSubstring = L"B41T+";
	//std::wcerr << args->Length << std::endl;
	if (args->Length > 1) {
		nameSubstring = args[1]->Data();
	}
	meter.scanByName(nameSubstring);


	//Sleep(5000);

	//sendCommand(meter.cmdCharacteristic, 3);
	for (;;) {
		char c;
		std::cin >> c;
		std::cerr << "typed: '" << c << '\'' <<  std::endl;

		meter.press(c);

	}
	return 0;
}

