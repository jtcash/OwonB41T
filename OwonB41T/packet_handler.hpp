#pragma once
#include "stdafx.h"

#include "data_parser.hpp"


struct packet_header {
  static inline constexpr uint8_t marker_byte = 0xff;
  static inline constexpr size_t marker_length = 20;
  static inline constexpr size_t header_length = 16;


  uint8_t century;
  uint8_t year;

  uint8_t month;
  uint8_t day;

  uint8_t hour;
  uint8_t minute;

  uint8_t second;
  uint8_t pad;

  uint32_t interval;

  uint32_t bytes;

};
// TODO: This is not 100% portable, but will work for now. Basically all machines that would run this are little endian
static_assert(sizeof(packet_header) == 16, "packet_header is not right :(");
static_assert(offsetof(packet_header, century) == 0, "packet_header is not right2 :(");
static_assert(offsetof(packet_header, day) == 3, "packet_header is not right3 :(");


struct downloaded_data {
  packet_header header;
  data_parser dp;

  std::vector<uint16_t> readings;

  downloaded_data(const std::vector<uint8_t>& packet);


  void print() const;
};



class packet_handler {





  std::vector<uint8_t> previous;
  std::vector<uint8_t> buffer;
  uint32_t expectedBytes;
  bool downloading;

public:


  static bool is_marker_packet(const std::vector<uint8_t>& data);


  packet_handler() : previous{}, buffer{}, expectedBytes{}, downloading{false}
  {  }


  bool isDownloading() const noexcept {
    return downloading;
  }

  const std::vector<uint8_t>& getPrevious() const {
    return previous;
  }
  const std::vector<uint8_t>& getBuffer() const {
    return buffer;
  }


  bool isMarker() const {
    return is_marker_packet(previous);
  }



  packet_handler& push(std::vector<uint8_t> pak);
  packet_handler& operator<<(std::vector<uint8_t> pak) {
    return push(std::move(pak));
  }

  bool isDoneDownloading() const;

  downloaded_data getDownloadedData() const;



  // TODO: this should be more complicated
  void clear() {
    buffer.clear();
  }


  packet_handler& setExpectedBytes(uint32_t eb) {
    expectedBytes = eb;
    return *this;
  }
  uint32_t getExpectedBytes() const noexcept {
    return expectedBytes;
  }

  uint32_t getExpectedPayloadBytes() const noexcept {
    return expectedBytes + packet_header::marker_length*2 + packet_header::header_length;
  }

  double downloadedPercent() const {
    return 100.0*double(buffer.size())/getExpectedPayloadBytes();
  }




  void test() {
    packet_header h = *reinterpret_cast<const packet_header*>(buffer.data() + packet_header::marker_length);
    std::cerr << "packet_header year = " << uint16_t(h.century) << uint16_t(h.year) << '\t' << h.bytes << std::endl;
  }



  // TODO: This is not portable, but is a simple temporary solution
  packet_header get_header() const {
    return *reinterpret_cast<const packet_header*>(buffer.data() + packet_header::marker_length);
  }



};

