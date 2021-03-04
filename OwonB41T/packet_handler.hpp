#pragma once
#include "stdafx.h"

#include "data_parser.hpp"


// When an offline data download begins, a header is sent before the record data indicating the start time,
// interval and number of records
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


  // Methods for extracting human readable representation of this header
  std::string timeString() const;

  // Same as timeString, but after adding a number of seconds to the time
  std::string timeString(uint32_t addSeconds) const;

  std::tm time(uint32_t addSeconds = 0) const;


};

// TODO: This is not 100% portable, but will work for now. Basically all machines that would run this are little endian

// Assertions to ensure nothing funky is going on with the structure memory layout
static_assert(sizeof(packet_header) == 16, "packet_header is not right :(");
static_assert(offsetof(packet_header, century) == 0, "packet_header is not right2 :(");
static_assert(offsetof(packet_header, day) == 3, "packet_header is not right3 :(");



// A structure for parsing out readings from an offline data download
struct downloaded_data {
  static inline constexpr std::string_view offline_prefix = "#\t";

  packet_header header;
  data_parser dp;

  std::vector<uint16_t> readings;

  downloaded_data(const std::vector<uint8_t>& packet);


  void print() const;
};



// A structure for handling and parsing packets from the meter, including offline data download packets
class packet_handler {


  std::vector<uint8_t> previous;
  std::vector<uint8_t> buffer;
  uint32_t expectedBytes;
  bool downloading;

public:

  // Offline data downloads are wrapped with marker packets that contain only 0xffs. Check if a packet is one
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


  // Push a packet into the packet handler. If downloading, appends a copy to the end of buffer
  packet_handler& push(std::vector<uint8_t> pak);
  packet_handler& operator<<(std::vector<uint8_t> pak) {
    return push(std::move(pak));
  }

  // Check if a download has finished
  bool isDoneDownloading() const;

  // Construct a downloaded_data type from the buffer. Should only be used after isDoneDownloading goes true.
  downloaded_data getDownloadedData() const;



  // TODO: this should be more complicated and maybe include some thread safety?
  void clear() {
    buffer.clear();
  }

  // Set the number of expected bytes to be downloaded in the download body
  packet_handler& setExpectedBytes(uint32_t eb) {
    expectedBytes = eb;
    return *this;
  }
  uint32_t getExpectedBytes() const noexcept {
    return expectedBytes;
  }

  // Returns the total number of expected bytes to be downloaded, including the start and stop markers and data header
  uint32_t getExpectedPayloadBytes() const noexcept {
    return getExpectedBytes() + packet_header::marker_length*2 + packet_header::header_length;
  }

  // Get a percent value for the progress of the download
  double downloadedPercent() const {
    return 100.0*double(buffer.size())/getExpectedPayloadBytes();
  }



  // TODO: delete me
  void test() {
    packet_header h = *reinterpret_cast<const packet_header*>(buffer.data() + packet_header::marker_length);
    std::cerr << "packet_header year = " << uint16_t(h.century) << uint16_t(h.year) << '\t' << h.bytes << std::endl;
  }


  // TODO: This is not portable, but is a simple temporary solution
  packet_header get_header() const {
    return *reinterpret_cast<const packet_header*>(buffer.data() + packet_header::marker_length);
  }



};

