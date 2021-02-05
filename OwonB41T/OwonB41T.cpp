/** OwonB41T.cpp
 * Jeffrey Cash
 * 
 */


#include "stdafx.h"

#include "B41T.hpp"
#include "data_parser.hpp"




B41T meter;





//int main(int argc, char* argv[]) {
int main(Platform::Array<Platform::String^>^ args) {
	winrt::init_apartment();
	//Microsoft::WRL::Wrappers::RoInitializeWrapper initialize(RO_INIT_MULTITHREADED);
	
	// Not sure if necesssary, but I'm leaving this here for now until I figure out. All UWP BLE examples had something like this,
	/// But I cannot do SDDL stuff here because it is not UWP
	/// L"O:BAG:BAD:(A;;0x7;;;PS)(A;;0x3;;;SY)(A;;0x7;;;BA)(A;;0x3;;;AC)(A;;0x3;;;LS)(A;;0x3;;;NS)"
	//(void)CoInitializeSecurity(nullptr, -1, nullptr, nullptr, RPC_C_AUTHN_LEVEL_DEFAULT, RPC_C_IMP_LEVEL_IDENTIFY, NULL, EOAC_NONE, nullptr);

	

	// Set to your meter's mac address to directly connect
	uint64_t addr{}; 
	// note that you cannot connect back for a few seconds after a connection has been
	// interrupted, so if you ctrl-c out of the program, it will fail if you restart it within
	// a few seconds. The connectByName option does not fail in this way, it just takes longer to connect


	// TODO: allow connection through bluetoo th address
	if (addr) {
		meter.connectByAddress(addr);
	} else {
		std::wstring nameSubstring = L"B41T";
		if (args->Length > 1) {
			nameSubstring = args[1]->Data();
		}
		meter.connectByName(nameSubstring);
	}
	std::cerr << "Connecting..." << std::endl;
	meter.waitUntilConnected();
	std::cerr << "Done connecting\n" << std::endl;





	// TODO: Clean up the interactive loop
	for (;;) {
		char c;
		std::cin >> c;
		std::cerr << "typed: '" << c << '\'' <<  std::endl;

		if (c == 'o') {
			auto status = meter.startDownload().get();
			if (!status) 
				std::cerr << "FAILED TO START DOWNLOAD" << std::endl;
			continue;
		} else if (c == '@') {
			std::string name;
			std::getline(std::cin, name);

			name += "B41T+"; // for ease of use while debugging 
			auto status = meter.sendRenameCommand(name).get();
			if (!status)
				std::cerr << "Failed to rename device to \"" << name << "\"" << std::endl;
			std::cerr << "renamed device to \"" << name << "\"" << std::endl;
			continue;
			
		} else if (c == 'l') { // TODO: Choose key 
			auto status = meter.sendDateCommand().get();
			if (!status) {
				std::cerr << "Failed to send date command!" << std::endl;
			}
		} else if (c == 'p') {
			uint32_t interval{};
			uint32_t count{};

			std::cin >> interval;
			std::cin >> count;

			// TODO: Error checking to ensure integers were given
			eecho(interval);
			eecho(count);

			meter.startRecording(interval, count);
			
		}


		meter.press(c);

	}
	return 0;
}

