# AuthentiKit Tuning App
![Version Experimtal](https://img.shields.io/badge/Version-1.3.1-blue)

Windows Desktop Application to calbirate button-based peripherals (e.g. AuthentiKit Trim Wheels, Honeycombe Bravo Trim Wheel) for use in simulators (e.g Microsoft Flight Simulator 2020). 

* [**Download Installer**](https://github.com/Colmanian/AuthentiKit-Trim-Calibration/releases)

* [**User Guide**](https://authentikit.org/tuning)

* [**About the Initial Developer**](https://collotech.net)

**Requements**
* Windows 10 / 11
* vJoy 2.1.9 - [download here](https://github.com/jshafer817/vJoy/releases/tag/v2.1.9.1)

Note: vJoy 2.1.9 is recommended, especially if you're experiencing vJoy crashes, but some people have had success with vJoy 2.2.1 as well ([download here](https://github.com/njz3/vJoy/releases/tag/v2.2.1.1)) 

# Versioning Strategy

`Major.Minor.Hotfix`, where

* `Major` is a significant update, like a redesigned user interface
* `Minor` is an incremental update, like adding in a new mapping type, or a selection of new presets
* `Hotfix` is a reactive change like a bug fix or tweak to existing functionality


# Contributing
It's best to reach out if you'd like to collaberate to maximise the chances of getting your changes into the released software. 

This application is written in .NET 6. This was choson over .Net Core / UMP so that the application doesn't run in a sandbox, and because UWP applications have 'application and lifecyle management control', meaning they pause when minimised or not in use which wouldn't work for this application (as far as I can tell anyway).

To develop and build, install `.NET 6 SDK` and open up the soluiton found in the `/AuthentiKitTrimCalibration` solution in Visual Studio 2022. It's written using a pretty standard pattern so if you're familar with the .NET you should be able to dev and build with relative ease. You'll need the [Installer Projects plugin](https://marketplace.visualstudio.com/items?itemName=VisualStudioClient.MicrosoftVisualStudio2022InstallerProjects) for Visual Studio.

## User Interface Testing using WinAppDriver
To run the UI tests, you'll need [WinAppDriver](https://github.com/microsoft/WinAppDriver). Grab the MSI installer for v1.2.1 if you're having issues.
* Run the WinAppDriver Server at `C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe`
* Run the tests in the MSTest Project `AuthentiKitTuningApp.Test` to automatically open the latest Debug build and run through a series of tests before closin the app and giving a test summary. Note that your mouse will move around as the tests execute.

# Credits
* vJoy - https://sourceforge.net/projects/vjoystick/
* AuthentiKit - https://www.authentikit.org

# License

This project was written by Ian Colman for the AuthentiKit Community, with contribution from others via GitHub. The AuthentiKit brand/identity is owned by Phil Hulme.

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