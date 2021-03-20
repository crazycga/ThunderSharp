# ThunderSharp

[![Build DLLs](https://github.com/crazycga/ThunderSharp/actions/workflows/dotnet.yml/badge.svg)](https://github.com/crazycga/ThunderSharp/actions/workflows/dotnet.yml)

[![CodeQL](https://github.com/crazycga/ThunderSharp/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/crazycga/ThunderSharp/actions/workflows/codeql-analysis.yml)

## Overview
This project is a .NET Core implementation of the control library for the ThunderBorg controller for the PiBorg: https://www.piborg.org/
The core of this project stems from a Mono implemention written by mshmelv called RPi.I2C.Net: https://github.com/mshmelev/RPi.I2C.Net
The library leverages the C library *libnativei2c.so*, and this gentlemen has some really good information located [here](http://blog.mshmelev.com/2013/06/connecting-raspberry-pi-and-arduino-software.html) and [here](http://blog.mshmelev.com/2013/06/connecting-raspberry-pi-and-arduino.html)

## Dot Net on Raspberry Pi
The .NET Core 3.1 (at the time of this writing) runtime engine is available from Microsoft.  Installation is done using the steps
located at Microsoft's website: https://docs.microsoft.com/en-us/dotnet/iot/deployment

## Future
This .md is part of the project, and will be updated as time goes on.

## ThunderBorgSettings_class

### Attributes

#### Id

Used for assigning an ID value in case you are storing this in a database.

#### BoardAddress

Tracks the board address of the settings.  **NOTE** if you try to restore settings using *SetCurrentEnvironment* and the board address does not match, the class will throw an ArugmentException.

#### VoltagePinMax

Exposes the voltage pin max that was in use by the code at the time that the settings were captured.  **NOTE** this value is a constant in the code, set by VOLTAGE_PIN_MAX in the ThunderBorg class.

#### BatteryMonitorMin

This is the minimum value used by the GetBatteryMonitoringLimits method of the ThunderBorg object.

#### BatteryMonitorMax

This is the maximum value used by the GetBatteryMonitoringLimits method of the ThunderBorg ojbect.

#### LED1_Red / LED1_Green / LED1_Blue

Each of these bytes represents the settings for LED1: red, green and blue.

#### LED2_Red / LED2_Green / LED2_Blue

Each of these bytes represents the settings for LED2: red, green and blue.

#### BatteryMonitoringState

True / false value representing the battery monitoring state.

#### FailSafeState

True / false value representing the failsafe state.

#### IsUsed [readonly]

True / false state indicating whether or not the object has been assigned any value; **false** indicates that it has not changed since instantiation.

### Events

#### PropertyChanged()

Trigger when a value assigned to the object changes.

### Methods

#### GetCurrentEnvironment(ThunderBorg_class, Logger_class)
Sets the object to the current ThunderBorg settings that it finds.

#### SetCurrentEnvironment(ThunderBorg_class, Logger_class)
Sets the current environment to the settings in the object, **subject to** the board address being the same.  This method will not work if the object has not been changed since instantiation.
