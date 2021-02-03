#pragma once
#include "stdafx.h"



// TODO: Move these somewhere nicer
std::string display_string(std::vector<uint8_t> bytes);
std::vector<uint8_t> read_IBuffer(winrt::Windows::Storage::Streams::IBuffer const& ibuf);









class B41T{

	inline static auto serviceUUID = winrt::Windows::Devices::Bluetooth::BluetoothUuidHelper::FromShortId(0xfff0);
	inline static auto cmdCharacteristicUUID = winrt::Windows::Devices::Bluetooth::BluetoothUuidHelper::FromShortId(0xfff1);
	inline static auto ctrlCharacteristicUUID = winrt::Windows::Devices::Bluetooth::BluetoothUuidHelper::FromShortId(0xfff3);
	inline static auto readCharacteristicUUID = winrt::Windows::Devices::Bluetooth::BluetoothUuidHelper::FromShortId(0xfff4);

	winrt::Windows::Devices::Bluetooth::Advertisement::BluetoothLEAdvertisementWatcher bleAdvertisementWatcher;



	winrt::Windows::Devices::Bluetooth::BluetoothLEDevice device{nullptr};
	winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattDeviceService service{nullptr};
	winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCharacteristic cmdCharacteristic{nullptr};
	winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCharacteristic ctrlCharacteristic{nullptr};
	winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCharacteristic readCharacteristic{nullptr};

	std::mutex mut{};

	bool opened{false};




	concurrency::task<bool> sendControl(uint16_t cmd);
	concurrency::task<bool> getCharacteristic(winrt::guid uid, winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCharacteristic& target, std::string_view characteristicName = "a");
	concurrency::task<bool> registerNotifications();

public:
	void connectByName(std::wstring nameSubstrMatch = L"B41T+");
	concurrency::task<bool> connectByAddress(unsigned long long deviceAddress);








	struct buttons {
		struct button {
			static constexpr uint16_t short_press(uint8_t code) {
				return uint16_t(1<<8) | (code&uint8_t(0xf));
			}
			static constexpr uint16_t long_press(uint8_t code) {
				return (code & uint8_t(0xf));
			}
			uint8_t code;


			constexpr uint16_t press() const {
				return short_press(code);
			}
			constexpr uint16_t hold() const {
				return long_press(code);
			}

		};

		static inline constexpr button none{uint8_t(0)};
		static inline constexpr button select{uint8_t(1)};
		static inline constexpr button range{uint8_t(2)};
		static inline constexpr button hold{uint8_t(3)};
		static inline constexpr button rel{uint8_t(4)};
		static inline constexpr button hz{uint8_t(5)};
		static inline constexpr button max{uint8_t(6)};
		static inline constexpr button all{uint8_t(7)};

		static inline std::map<char, const button*> map{
			{'s', &select},
			{'r', &range},
			{'h', &hold},
			{'d', &rel},
			{'z', &hz},
			{'m', &max},
			{'a', &all},
		};
		static const button& get(char c) {
			if (auto it = map.find(c); it!=map.end()) {
				return *(it->second);
			} else {
				return none;
			}
		}

	};


	concurrency::task<bool> hold(const buttons::button& b);
	concurrency::task<bool> press(const buttons::button& b);
	

	concurrency::task<bool> hold(char c);
	concurrency::task<bool> press(char c);


};

