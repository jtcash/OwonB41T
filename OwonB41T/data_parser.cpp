#include "stdafx.h"

#include <iomanip>
#include <ios>
#include <sstream> 

#include "data_parser.hpp"


data_parser::data_parser(std::vector<uint8_t> bytes) {
	if (bytes.size() == 6) {
		for (auto i = 0; i<3; ++i)
			data[i] = uint16_t(bytes[2*i] | uint16_t(bytes[2*i+1] << 8));
		init();
	}
}
void data_parser::init() {
	func = uint8_t((data[0] >> 6) & 0b1111);
	scale = uint8_t((data[0] >> 3) & 0b111);
	magnitude = uint8_t(data[0] & 0b111);

	mode = data[1];

	reading = data[2];

	valid = true;
}

std::string data_parser::status_string() const {
	std::string status = "";
	for (int i = 0; i<8; ++i) {
		if ((mode&(1<<i)) != 0) {
			if (status.size() > 0)
				status += ' ';
			status += status_names[i];
		}
	}
	return status;
}


double data_parser::decimal_value() const {
	int mag = data[0] & 0x7;
	if (mag == 0b111)
		return std::numeric_limits<double>::infinity();

	uint16_t val = data[2];
	double sign = 1.0;
	if (val >= 0x7fff) {
		sign = -1.0;
		val &= 0x7fff;
	}

	return sign * val / std::pow(10.0, mag);
}



std::string data_parser::scientific_string() const {
	std::ostringstream oss;
	oss << std::setprecision(4) << std::scientific << decimal_value();
	return oss.str();
}


std::string data_parser::measurement_string() const {
	if (isOL())
		return "OL";

	// NOTE: there has to be a simple way to do this that i'm overlooking
	// But I cannot figure out a universal way to make the string returned here
	// exactly match the multimeter screen
	auto posPart = [this](uint16_t val) {
		constexpr size_t num_digits = 5; // TODO: make option for owon B35, where this would be 4

		auto v = std::to_string(val);
		std::string r = std::string(num_digits - v.size(), '0') + v;
		auto loc = r.insert(r.begin() + (num_digits - magnitude), '.');

		auto it = r.begin();
		for (; it<loc-1; ++it)
			if (*it != '0' || *(it+1) == '.')
				break;
		return r.substr((it-r.begin()));
	};

	// Append the negative symbol if needed
	return isNegative()
		? "-" + posPart(reading&0x7fff) 
		: posPart(reading);
}



std::string data_parser::formatted_string() const {
	if (!isValid())
		return "Invalid data passed to parser";

	std::string toret(measurement_string());;
	toret += ' ';
	toret += scale_char();
	toret += ' ';
	toret += func_string();
	toret += '\t';
	toret += status_string();
	return toret;
}

