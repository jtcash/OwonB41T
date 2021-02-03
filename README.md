# OwonB41T
A Windows Bluetooth(BLE) client for the Owon B41T+ multimeter. Any BLE adaptor is compatible, so no dongle needed!  
Requires Windows 10  
I will be posting binaries in the future, but you should be able to compile this yourself if your Visual Studio environment is up to date.

## Current Features
This project is currently early in development, but I've completed the core functionality: 
* Compatibility with any Bluetooth Low Energy adapter (built-in ones included)
* Connecting to an Owon B41T+ by device name or mac address
* Printing data from the meter to stdout
* Controlling the meter with simluated button presses from stdin

## Features Coming Soon
* Retries for failed or dropped connections
* Command line argument parsing to make this a useful interface for use with other programs
* Sending non-button commands to the meter: start logging, stop logging, download recorded data, rename device... etc.
* Output format customization

## Example Usage
If your haven't changed your multimeter's name, it should just connect automatically. Otherwise, you can pass the name (or a substring) of your multimeter as the first argument to the program.
```
$ ./x64/Release/OwonB41T.exe 2>/dev/null
0.0082  V AC    AUTO
0.0086  V AC    AUTO
0.0086  V AC    AUTO
0.0079  V AC    AUTO
```
After the meter is connected, you can interact with it using the following keys (for now, you must press return to send each keypress).
| Button | Key | 
| :------------- | :----------: |
| Hold/Backlight | h |
| Select | s |
| Range | r |
| Hz/Duty | z |
| Max/Min | m |
| Rel/BLE | d |

To simulate pressing and holding a key, use a capital letter instead, e.g. sending an 'H' turns on the backlight. 

---

NOTE: The current methods of interacting with the meter will certainly be changed in the future. This is just what I slapped together while I was trying to get the more complicated bits working.
