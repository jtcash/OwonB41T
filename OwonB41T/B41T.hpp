#pragma once
#include "stdafx.h"

#include "packet_handler.hpp"

// TODO: Move these somewhere nicer
std::vector<uint8_t> read_IBuffer(winrt::Windows::Storage::Streams::IBuffer const& ibuf);

#define echo(...) std::cout << __LINE__ << ":\t" #__VA_ARGS__ " = " << __VA_ARGS__ << std::endl
#define eecho(...) std::cerr << __LINE__ << ":\t" #__VA_ARGS__ " = " << __VA_ARGS__ << std::endl



class B41T {

	struct {
		bool rawOutput{ false }; // Output raw notification data to stdout instead of parsing it
	} options{};

	using BluetoothUuidHelper = winrt::Windows::Devices::Bluetooth::BluetoothUuidHelper;
	inline static auto serviceUUID = BluetoothUuidHelper::FromShortId(0xfff0);
	inline static auto cmdCharacteristicUUID = BluetoothUuidHelper::FromShortId(0xfff1);
	inline static auto ctrlCharacteristicUUID = BluetoothUuidHelper::FromShortId(0xfff3);
	inline static auto readCharacteristicUUID = BluetoothUuidHelper::FromShortId(0xfff4);

	winrt::Windows::Devices::Bluetooth::Advertisement::BluetoothLEAdvertisementWatcher bleAdvertisementWatcher;


	winrt::Windows::Devices::Bluetooth::BluetoothLEDevice device{ nullptr };
	winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattDeviceService service{ nullptr };

	// The different GATT characteristics used to communicate with the meter.
	winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCharacteristic cmdCharacteristic{ nullptr };
	winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCharacteristic ctrlCharacteristic{ nullptr };
	winrt::Windows::Devices::Bluetooth::GenericAttributeProfile::GattCharacteristic readCharacteristic{ nullptr };


	// A mutex/cv pair to let the main thread block until a connection has been established
	std::mutex mut{};
	std::condition_variable connecting_cv;


	// Flags to keep track of the current connection state
	bool opened{ false };
	bool registered{ false };


	// A structure for handling packets from the meter's read characteristic
	packet_handler packets{};

	// Send a control command to the meter. Used by button presses
	concurrency::task<bool> sendControl(uint16_t cmd);


	// Send a command directly to the meter on the cmd GATT characteristic
	concurrency::task<bool> sendCommand(const std::vector<uint8_t>& buf);
	concurrency::task<bool> sendCommand(std::string_view cmd);

public:

	// Query the length of the meter's offline data recording. Returns the number of bytes of the body of the recording
	concurrency::task<uint32_t> queryOfflineLength();

	// max 14 characters, be careful with special symbols!
	concurrency::task<bool> sendRenameCommand(std::string_view sv);

	// Send the current time and date to the meter. Used when starting an offline recording to track the recording time
	concurrency::task<bool> sendDateCommand();

	// Start an offline recording session.
	concurrency::task<bool> sendRecordCommand(uint32_t interval, uint32_t count);

	// Start an offline recording session. First sends the current time and date to make the recording reflect the time and date
	concurrency::task<bool> startRecording(uint32_t interval, uint32_t count);




private: // temp

	// Register a handler for packets from the meter on 0xfff4
	concurrency::task<bool> registerNotifications();

	// Take in a packet from the GATT notification handler and pass it to the packet handler
	void handlePacket(std::vector<uint8_t> pak);


public:

	// Block until the meter has been connected to
	void waitUntilConnected();

	// Begin downloading stored offline data
	concurrency::task<bool> startDownload();


	// Connect to a meter by name, using a substring to match the meter
	void connectByName(std::wstring nameSubstrMatch = L"B35T");

	// Quick solution to allow seraching for numerous names. I cant pass the names by reference, as they could be destroyed in another thread
	void connectByNames(std::vector<std::wstring> nameSubstrMatches = { L"B41T", L"B41T+", L"BDM", L"B35T", L"B35T+" });

	// Connect to a meter by a BLE mac address. This is used by connectByNames() to actually create the connection
	concurrency::task<bool> connectByAddress(unsigned long long deviceAddress);







	// A structure for abstracting away details of sending control messages to the ctrl characteristic
	struct buttons {
		struct button {
			// Encode a button press/hold code
			static constexpr uint16_t short_press(uint8_t code) {
				return uint16_t(1 << 8) | (code & uint8_t(0xf));
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

			constexpr bool operator==(const button& that) const {
				return code == that.code;
			}
			constexpr bool operator!=(const button& that) const {
				return !operator==(that);
			}
		};

		// The different buttons available for interacting with the meter
		static inline constexpr button none{ uint8_t(0) };
		static inline constexpr button select{ uint8_t(1) };
		static inline constexpr button range{ uint8_t(2) };
		static inline constexpr button hold{ uint8_t(3) };
		static inline constexpr button rel{ uint8_t(4) };
		static inline constexpr button hz{ uint8_t(5) };
		static inline constexpr button max{ uint8_t(6) };
		static inline constexpr button all{ uint8_t(7) };

		// Get a button reference from a character used to index the buttons
		static constexpr const button& get(char c) {
			switch (c) {
			case 's': return select;
			case 'r': return range;
			case 'h': return hold;
			case 'd': return rel;
			case 'z': return hz;
			case 'm': return max;
			case 'a': return all;
			default:  return none;
			}
		}

		static constexpr bool is_valid(char c) {
			if (c >= 'A' && c <= 'Z')
				return is_valid(c - 'A' + 'a');
			else
				return get(c) != none;
		}
	};


	// Send press/hold commands to the meter
	concurrency::task<bool> hold(const buttons::button& b);
	concurrency::task<bool> press(const buttons::button& b);


	concurrency::task<bool> hold(char c);
	concurrency::task<bool> press(char c);

	static constexpr bool check_button(char c) {
		return buttons::is_valid(c);
	}


};

