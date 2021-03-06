# ThunderSharp

[![NuGet Package](https://github.com/crazycga/ThunderSharp/actions/workflows/dotnet.yml/badge.svg)](https://github.com/crazycga/ThunderSharp/actions/workflows/dotnet.yml)

[![CodeQL](https://github.com/crazycga/ThunderSharp/actions/workflows/codeql-analysis.yml/badge.svg)](https://github.com/crazycga/ThunderSharp/actions/workflows/codeql-analysis.yml)

## Overview
This project is a .NET Core implementation of the control library for the ThunderBorg controller for the PiBorg: https://www.piborg.org/
The core of this project stems from a Mono implemention written by mshmelv called RPi.I2C.Net: https://github.com/mshmelev/RPi.I2C.Net
The library leverages the C library *libnativei2c.so*, and this gentlemen has some really good information located [here](http://blog.mshmelev.com/2013/06/connecting-raspberry-pi-and-arduino-software.html) and [here](http://blog.mshmelev.com/2013/06/connecting-raspberry-pi-and-arduino.html)

## Dot Net on Raspberry Pi
The .NET Core 3.1 (at the time of this writing) runtime engine is available from Microsoft.  Installation is done using the steps
located at Microsoft's website: https://docs.microsoft.com/en-us/dotnet/iot/deployment

## NuGet Package  ![Nuget](https://img.shields.io/nuget/v/ThunderSharpLibrary)  ![Nuget](https://img.shields.io/nuget/dt/ThunderSharpLibrary)

The NuGet package is available with the command 

`Install-Package ThunderSharpLibrary`

## Future
This .md is part of the project, and will be updated as time goes on.

## Credits
Special thanks to the following repos and repo owners:
- https://github.com/piborg
- https://github.com/mshmelev/RPi.I2C.Net
- https://github.com/unosquare/raspberryio (and others in their domain)

Special thanks to:
- https://github.com/ArronChurchill
- https://github.com/mshmelev

