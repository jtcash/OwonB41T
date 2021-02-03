#include "stdafx.h"
#include "B41T.hpp"

//TODO: move these into utilities file
std::string display_string(std::vector<uint8_t> bytes);
std::vector<uint8_t> read_IBuffer(winrt::Windows::Storage::Streams::IBuffer const& ibuf);




void B41T::scanByName(std::wstring nameSubstrMatch) {

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
			if (auto addr = eventArgs.BluetoothAddress(); foundList.addrs.find(key) == foundList.addrs.end()) {
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

			bool status = openByAddress(eventArgs.BluetoothAddress()).get();

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

	auto characteristicResult = co_await service.GetCharacteristicsForUuidAsync(uid);
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




	readCharacteristic.ValueChanged([](GattCharacteristic const& charateristic, GattValueChangedEventArgs const& args) {
		auto buf = read_IBuffer(args.CharacteristicValue());
		// for (const auto& b : buf) std::cout << formatting::hex(b) << ' '; std::cout << std::endl;
		std::cout << display_string(buf) << std::endl;
	});
	co_return true;
}

concurrency::task<bool> B41T::openByAddress(unsigned long long deviceAddress) {
	std::unique_lock<std::mutex>(mut); // Ensure nothing can go wrong in very odd circumstances
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


	auto services = co_await device.GetGattServicesForUuidAsync(serviceUUID);
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

	if (registerNotifications().get())
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