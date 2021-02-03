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
	if (args->Length > 1) {
		nameSubstring = args[1]->Data();
	}
	meter.scanByName(nameSubstring);

	for (;;) {
		char c;
		std::cin >> c;
		std::cerr << "typed: '" << c << '\'' <<  std::endl;

		meter.press(c);

	}
	return 0;
}

