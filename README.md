# AuthentiKit Trim Calibration
![Version Experimtal](https://img.shields.io/badge/Version-Exprimental-blue)

Windows Desktop Application to calbirate button-based peripherals (e.g. AuthentiKit Trim Wheels) for use in simulators (e.g Microsoft Flight Simulator 2020). 

**User Guide**

https://authentikit.org/tuning

**Requements**
* Windows 10/11
* vJoy 2.2.1 or earlier for Windows 10 - [download here](https://github.com/njz3/vJoy/releases/tag/v2.2.1.1)
* vJoy 2.1.9 for Windows 11 - [download here](https://github.com/jshafer817/vJoy/releases/tag/v2.1.9.1)


**Installer Download**

See our [releases page](https://github.com/Colmanian/AuthentiKit-Trim-Calibration/releases)


# Change Log

See our [releases page](https://github.com/Colmanian/AuthentiKit-Trim-Calibration/releases)

# Development & Build
This application is written in .NET CORE's WinForms framework as a Win32 Desktop app. This was choson over UWP so that the application doesn't run in a sandbox, and because UWP applications have 'application and lifecyle management control', meaning they pause when minimised or not in use which wouldn't work for this application. 

To develop and build, install `.NET 5.0.403 SDK` or later (untested with later versions) and open up the soluiton found the `/AuthentiKitTrimCalibration` directory in Visual Studio 2019. It's written using a pretty standard pattern so if you're familar with the WinUI framework in .NET Core you should be able to dev and build with relative ease.

# Versioning Strategy

`Major.Minor.Hotfix`, where

* `Major` is a significant update, like a redesigned user interface
* `Minor` is an incremental update, like adding in a new mapping type, or a selection of new presets
* `Hotfix` is a reactive change like a bug fix or tweak to existing functionality

# Credits
* vJoy - https://sourceforge.net/projects/vjoystick/
* AuthentiKit - https://www.authentikit.org

# License

This project was written by Ian Colman for the AuthentiKit Community. The AuthentiKit brand/identity is owned by Phil Hulme.

This project is and is licensed under the Creative Commons Attribution-NonCommercial-NoDerivatives 4.0 International license. Unde the terms of this license you are free to:

**Use and share** — run, copy and redistribute the material in any medium or format

The licensor cannot revoke these freedoms as long as you follow the following license terms:

* **Attribution** — You must give appropriate credit, provide a link to the license, and indicate if changes were made. You may do so in any reasonable manner, but not in any way that suggests the licensor endorses you or your use.

* **NonCommercial** — You may not use the material for commercial purposes.

* **NoDerivatives** — If you remix, transform, or build upon the material, you may not distribute the modified material. 

*Appropriate Credit Example*:

*The "AuthentKit Encoder Tool" was written by Ian Colman (Colmanian), licensed under CC BY NC ND 4.0*

[![CC BY-NC-ND 4.0][cc-by-nc-nd-image]][cc-by-nc-nd]

[cc-by-nc-nd]: http://creativecommons.org/licenses/by-nc-nd/4.0/
[cc-by-nc-nd-image]: https://licensebuttons.net/l/by-nc-nd/4.0/88x31.png
[cc-by-nc-nd-shield]: https://img.shields.io/badge/License-CC%20BY%20NC%20ND%204.0-lightgrey.svg