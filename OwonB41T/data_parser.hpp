#pragma once

#include "stdafx.h"




namespace std {
	template<typename CharT, typename Traits, typename T>
	std::basic_ostream<CharT, Traits>& operator<<(std::basic_ostream<CharT, Traits>& os, const std::vector<T>& v) {
		os << "{ ";
		bool first = true;
		for (auto&& e : v) {
			if (first)
				first = false;
			else
				os << ", ";
			os << e;
		}
		return os << '}';
	}
}
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

/** data_parser
 * this class handles the measurement data from the meter and allows it to be parsed
 * into a human readable format.
 * 
 */
class data_parser {
	
	static inline constexpr std::array<char, 8> scale_chars{ '%',  'n',  'u',  'm',  ' ', 'k', 'M', 'G'}; 
	static inline constexpr std::array<double, 8> scales{    0.01, 1e-9, 1e-6, 1e-3, 1.0, 1e3, 1e6, 1e9};
	static inline constexpr std::array<std::string_view, 14> func_strings{
		"V DC",
		"V AC",
		"A DC", 
		"A AC", 
		"Ohm", 
		"Farad", 
		"Hz", 
		"Duty", 
		"TempC", 
		"TempF", 
		"Volts Diode", 
		"Ohms Continuity", 
		"hFE", 
		"NCV/ADP"
	};
	static inline constexpr std::array<std::string_view,8> status_names{
		"HOLD", "REL", "AUTO", "Bat", "MIN", "MAX", "OL", "MAXMIN"
	};



	std::array<uint16_t, 3> data{};
	uint8_t func{};
	uint8_t scale{};
	uint8_t magnitude{};

	uint16_t mode{};

	uint16_t reading{};

	bool valid{};
public:
	constexpr data_parser()
	{  }
	data_parser(std::array<uint16_t, 3> data) : data{data} {
		init();
	}
	data_parser(std::vector<uint8_t> bytes);

private:
	void init(); // Populate all other fields from the data 

public:
	// true if reading is OL
	bool isOL() const noexcept {
		return magnitude == uint8_t(0b111);
	}
	// true if reading is negative
	bool isNegative() const noexcept {
		return reading & (1<<15);
	}
	// true if data parsed successfully
	bool isValid() const noexcept {
		return valid;
	}

	// Get the scale multiplier
	double scaleFactor() const noexcept {
		return scales[scale];
	}
	//std::string_view scale_string() const noexcept {
	//	return std::string_view(&scale_chars[scale], 1);
	//} TODO: remove me, no longer needed

	// Get SI unit representations for the scale multiplier
	char scaleChar() const noexcept {
		return scale_chars[scale];
	}
	// Get a string representation of the meter's current function
	std::string_view funcString() const noexcept {
		return func_strings[func%func_strings.size()]; // crappy safety for unexpected values
	}




	std::string statusString() const;      // get a string representing things like HOLD, MAX, REL... etc.

	double decimalValue() const;						// get the measurement value


	std::string scientificString() const;	// get the measurement value in scientific notation 


	std::string measurementString() const; // get the measurement value as it is displayed on the meter


	std::string formattedString() const;   // get a nice human-readable string of the parsed data


	std::string hexString() const;
};