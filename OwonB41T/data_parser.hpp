#pragma once

#include "stdafx.h"

class data_parser {
	static inline constexpr char scale_chars[]{'%', 'n', 'u', 'm', ' ', 'k', 'M', 'G'}; 



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
	data_parser(std::vector<uint8_t> bytes) {
		if (bytes.size() == 6) {
			for (auto i = 0; i<3; ++i)
				data[i] = uint16_t(bytes[2*i] | uint16_t(bytes[2*i+1] << 8));
			
			func = (data[0] >> 6) & 0b1111;
			scale = (data[0] >> 3) & 0x111;
			magnitude = data[0] & 0x111;

			mode = data[1];

			reading = data[2];


			valid = true;
		}
	}

	constexpr double scale_factor() const {
		constexpr double scales[]{0.01, 1e-9, 1e-6, 1e-3, 1.0, 1e3, 1e6, 1e9};
		return scales[(data[0] >> 3) & 0x7];
	}
	

};