# AuthentiKit Trim Calibration
![Version 0.3 Beta](https://img.shields.io/badge/Version-0.3--beta-blue)

Windows Desktop Application to calbirate button-based Trim Wheels for use in Microsoft Flight Simulator 2020. 

**Requements**
* Windows 10
* vJoy installed - [vjoystick.sourceforge.net](vjoystick.sourceforge.net)

**Installer Download**

(In Progress)


# Setup

(In Progress)

# Change Log

* 0.3-beta (INSERT DATE)
    * Complete re-write as a .NET CORE Win32 Desktop Application, using WinUI 3.0
    * Added an installer
    * Uses the vJoy DLL installed on the user's PC rather than one bundled inthe app.

* 0.2-beta (18-Apr-2021)
    * Input devices configurable from dropdown (buttons still hard coded)
    * Cleaned up GUI
    * Added additional mappings for rudder trim. Complete mappings now
        * Input Button 11 -> vJoy Button 1
        * Input Button 12 -> vJoy Button 2
        * Input Button 09 -> vJoy Button 3
        * Input Button 10 -> vJoy Button 4
    * Hidden anything 'vJoy' from input device list to avoid loop conditions

* 0.1-beta (15-Apr-2021)
    * Inital Release
    * Basic hard coded mapping of BU0836 buttons 11 and 12 to vJoy device 1 buttons 1 and 2
    * vJoy DLL bundled into exe
    * Console window displays to show debug info

# Development & Build
Running an exe you've downloaded of the internet can be understandably uncomfortable. If you'd like to build it from scratch yourself, you can, all the source code is provided. Just follow these steps. You'll need to be comfortable in Python to do so.

The project requires the `vJoyInterface.dll` to be copied across to project directory from your vJoy install directory to this project's `python\pyvjoy` directory. To install and run:
* `pip install -r requirements.txt`
* `python python/app.py`

Build using PyInstaller which requires you to have copied vJoyInterface.dll as above. Note the `\` and `/` might be diferent for you depending on what type of terminal you're using. 

`pyinstaller.exe --onefile --icon=images/icon.ico --add-binary='python\pyvjoy\vJoyInterface.dll:.' --name='AuthentiKit Trim Calibration' python/app.py`

Your newly built `.exe` file will be overwrite the one in the `dist/` directory.

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