// stdafx.h : include file for standard system include files,
// or project specific include files that are used frequently, but
// are changed infrequently
//

#pragma once

#include "targetver.h"


#include <utility>
#include <array>
#include <algorithm>
#include <cmath>
#include <limits>
#include <mutex>
#include <condition_variable>
#include <thread>

#include <iostream>

#include <string>
#include <string_view>
#include <sstream> 
#include <iomanip>
//#include <ios>
#include <experimental/resumable>
#include <set>
#include <map>

#include <atomic>


#include <winrt/base.h>
#include <winrt/Windows.Storage.Streams.h>
#include <winrt/Windows.Foundation.h>
#include <winrt/Windows.Foundation.Collections.h>
#include <winrt/Windows.Devices.Bluetooth.h>
#include <winrt/Windows.Devices.Bluetooth.Advertisement.h>
#include <winrt/Windows.Devices.Bluetooth.GenericAttributeProfile.h>

#include <ctime>


 
#include <ppltasks.h>
#include <pplawait.h>
// TODO: reference additional headers your program requires here


// What the heck is microsoft thinking??? Clobbering min and max is absurdly ignorant
#pragma push_macro("max")
#undef max

#pragma push_macro("min")
#undef min

