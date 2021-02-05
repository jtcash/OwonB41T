#include "stdafx.h"
#include "packet_handler.hpp"



std::string packet_header::timeString() const {
  std::ostringstream oss{};

  auto put = [&oss](uint8_t x) {
    oss << std::setw(2) << std::setfill('0') << uint16_t(x);
  };

  put(century);
  put(year);
  oss << '-';
  put(month);
  oss << '-';
  put(day);

  oss << ' ';
  put(hour);
  oss << ':';
  put(minute);
  oss << ':';
  put(second);

  return oss.str();
}


std::string packet_header::timeString(uint32_t addSeconds) const {
  std::ostringstream oss{};
  
  std::tm tm = time(addSeconds);
  oss << std::put_time(&tm, "%Y-%m-%d %H:%M:%S");

  return oss.str();
}

std::tm packet_header::time(uint32_t addSeconds) const {
  std::tm tm{};

  std::istringstream iss(timeString());

  iss >> std::get_time(&tm, "%Y-%m-%d %H:%M:%S");
    
  tm.tm_sec += addSeconds;

  return tm;
}



bool packet_handler::is_marker_packet(const std::vector<uint8_t>& data) {
	if (data.size() != packet_header::marker_length)
		return false;
	for (auto&& e : data)
		if (e != packet_header::marker_byte)
			return false;
	return true;
} 







downloaded_data::downloaded_data(const std::vector<uint8_t>& packet) {
    // TODO: endian issue here too
  if (packet.size() < packet_header::marker_length*2 + packet_header::header_length + 2) {
    std::cerr << "ISSUE WITH PACKET PASSED TO DOWNLOADED_DATA" << std::endl;
  } else {
    auto headerStart = packet.data() + packet_header::marker_length;
    header = *reinterpret_cast<const packet_header*>(headerStart);

    auto fsmStart = reinterpret_cast<const uint16_t*>(headerStart + packet_header::header_length);
    dp = data_parser(*fsmStart);

    auto dataStart = fsmStart + 1;

    if (header.bytes%2 != 0) {
      std::cerr << "BAD HEADER BYTES VALUE" << std::endl;
    }
    readings.resize(header.bytes/2 - 1);
    std::copy_n(dataStart, header.bytes/2 - 1, readings.begin());

  }
}

void downloaded_data::print() const {
  uint32_t i = 0;
  for (auto&& r : readings) {
    auto d = dp.parseReading(r);
    // TODO: very innefficient. do better.
    std::cout << offline_prefix << header.timeString(i++ * header.interval) << '\t' << d.formattedString() << std::endl;
  }
}










packet_handler& packet_handler::push(std::vector<uint8_t> pak) {
  if (is_marker_packet(pak))
    downloading = true;

  if (downloading)
    buffer.insert(buffer.end(), pak.begin(), pak.end());
  
  if (isDoneDownloading())
    downloading = false;

  previous = std::move(pak);

  return *this;
}


bool packet_handler::isDoneDownloading() const {
  if (buffer.size() < packet_header::marker_length*2)
    return false;
  for (auto it = buffer.end() - packet_header::marker_length; it != buffer.end(); ++it)
    if (*it != packet_header::marker_byte)
      return false;
  return true;
}

downloaded_data packet_handler::getDownloadedData() const {
  return downloaded_data(buffer);
}
