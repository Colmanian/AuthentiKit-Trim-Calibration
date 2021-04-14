# AuthentiKit Trim Calibration
![Version 0.1 Beta](https://img.shields.io/badge/Version-0.1--beta-blue)

Proof of concept tool for better mapping of Authentikit Trim Wheels to Microsoft Flight Simulator 2020. 

Maps buttons 11 and 12 from Leo Bodnar's BU0836A 12-Bit Joystick controller to buttons 1 and 2 of vJoy device 1, calibrated for use as trim wheel up/down in MSFS.

# Usage

 1. Set up your AuthentiKit Trim Wheel: https://authentikit.org/ 
 2. Install vJoy, including the option to install vJoy Monitor: https://sourceforge.net/projects/vjoystick/ 
 3. Download and run [AuthentiKit Trim Calibration.exe](https://github.com/Colmanian/AuthentiKit-Trim-Calibration/blob/main/dist/AuthentiKit%20Trim%20Calibration.exe)
 4. Run vJoy Monitor and verify buttons 1 and 2 illuminate. The console window also gives a good indication that things are working.
 5. Leave this window running and open up MSFS 
 6. Ensure the AuthentKit trim wheel isn't bound to anything in MSFS directly 
 7. Map button 1 and 2 of your vJoy device in MSFS to Elevator Trim Up and Down 

Limitations with this proof of concept: 
 - Elevator trim wheel is expected only at Buttons 11 and 12 of the 'BU0836 Interface' 
 - Elevator trim outputs are be mapped across only to vJoy buttons 1 and 2 

# Development & Build
Running an exe you've downloaded of the internet can be understandably uncomfortable. If you'd like to build it from scratch yourself, you can, all the source code is provided. Just follow these steps. You'll need to be comfortable in Python to do so.

The project requires the `vJoyInterface.dll` to be copied across to project directory from your vJoy install directory to this project's `python\pyvjoy` directory. To install and run:
* `pip install -r requirements.txt`
* `python python/app.py`

Build using PyInstaller which requires you to have copied vJoyInterface.dll as above. Note the `\` and `/` might be diferent for you depending on what type of terminal you're using. 

`pyinstaller.exe --onefile --icon=images/icon.ico --add-binary='python\pyvjoy\vJoyInterface.dll:.' --name='AuthentiKit Trim Calibration' python/app.py`

Your newly built `.exe` file will be overwrite the one in the `dist/` directory.

# Credits
* pyvjoy - https://github.com/tidzo/pyvjoy
* vJoy - https://sourceforge.net/projects/vjoystick/
* AuthentiKit - https://www.authentikit.org

# License

This work was written by Ian Colman and is licensed under the Attribution-NonCommercial-NoDerivatives 4.0 International license. You are free to:

**Share** — copy and redistribute the material in any medium or format

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
