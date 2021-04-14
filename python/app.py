import pygame
import pyvjoy
import threading
import tkinter as tk
from time import sleep

# Author: Ian Colman
# License: Creative Commons BY NC ND 4.0
# Credits:  https://github.com/tidzo/pyvjoy for the vJoy DLL wrapper 
#           https://sourceforge.net/projects/vjoystick/ for the vJoy DLL


# Mapping Thread
class MappingThread (threading.Thread):

    def __init__(self, *args, **kwargs):
        super(MappingThread, self).__init__(*args, **kwargs)
        self.running = True

    def stop(self):
        self.running = False

    def run(self):   
        # Get real joystick info
        pygame.init()
        pygame.joystick.init()
        joystick_count = pygame.joystick.get_count()
        for i in range(joystick_count):
                joystick = pygame.joystick.Joystick(i)
                joystick.init()
                print(joystick.get_name())

        # Get virtual joystick info
        j = pyvjoy.VJoyDevice(1)


        # Hard code mappings and multipliers (for proof of concept)
        button_map = {10:1, 11:2}
        multiplier_map = {10:3, 11:3}

        # Timing information
        ticks = 0
        ticks_since_encoder_pulse = 0 
        HOLD_THRESHOLD = 500 #~ms
        OFF_THRESHOLD = 200 #~ms
        PULSE_WIDTH_SEC = 0.020 # 20 ms
        active_button = None # (Only supports one button active at a time currently)
        holding = True # If we pass the HOLD_ON_THRESHOLD then we keep the button on to max out control speed in msfs

        # Main Loop
        while self.running:

            sleep(0.001)
            ticks += 1
            ticks_since_encoder_pulse += 1

            for event in pygame.event.get():
                if event.type == pygame.JOYBUTTONDOWN:
                    joystick = pygame.joystick.Joystick(event.joy).get_name()
                    button = event.button

                    if (joystick == "BU0836 Interface"):

                        if button == active_button:                    
                            ticks_since_encoder_pulse = 0
                            if ticks < HOLD_THRESHOLD:
                                # Pulse vButton
                                for n in range(0, multiplier_map[active_button]):
                                    sleep(PULSE_WIDTH_SEC)
                                    j.set_button(button_map[active_button],0)
                                    sleep(PULSE_WIDTH_SEC)
                                    ticks += int(PULSE_WIDTH_SEC*1000)
                                    j.set_button(button_map[active_button],1)
                                print ("BU0836 Button {}".format(active_button), "to vJoy1 Button {}".format(button_map[active_button]),  "(Pulsing)")
                            else:
                                print ("BU0836 Button {}".format(active_button), "to vJoy1 Button {}".format(button_map[active_button]),  "(Holding on)")

                        elif active_button == None and (button in button_map):

                            # Turn On
                            ticks = 0
                            ticks_since_encoder_pulse = 0
                            active_button = button
                            # Pulse vButton
                            for n in range(0, multiplier_map[active_button]):
                                sleep(PULSE_WIDTH_SEC)
                                j.set_button(button_map[active_button],0)
                                sleep(PULSE_WIDTH_SEC)
                                ticks += int(PULSE_WIDTH_SEC*1000)
                                j.set_button(button_map[active_button],1)
                                print ("BU0836 Button {}".format(active_button), "to vJoy1 Button {}".format(button_map[active_button]),  "(Pulsing)")
            
            if (active_button != None) and (ticks_since_encoder_pulse > OFF_THRESHOLD):
                # Turn Off
                print ("BU0836 Button {}".format(active_button), "to vJoy1 Button {}".format(button_map[active_button]),  "(Turning off)")
                j.set_button(button_map[active_button],0)
                active_button = None

if __name__ == '__main__':
    mapping_thread = MappingThread()
    mapping_thread.start()

    # Initalise window 
    root = tk.Tk()
    root.title('AuthentiKit Trim Calibration')
    root.geometry("750x410")
    topFrame = tk.Frame(root)
    topFrame.pack()
    bottomFrame = tk.Frame(root)
    bottomFrame.pack(side=tk.BOTTOM)

    # Add description Text to Top Frame
    info = tk.Text(topFrame, width=750)
    info.pack()
    info.insert(tk.END, "\
This is a proof of concept tool for calibrating Authentikit Trim Controls for use in\n\
Microsoft Flight Simulator 2020. \n\
\n\
Maps BU0836 Interface Buttons 11 and 12 to calibrated output buttons 1 and 2 in vJoy:1\n\
\n\
 1. Set up your AuthentiKit controls as per the instructions https://authentikit.org/ \n\
 2. Install vJoy, including the option to install vJoy Monitor: https://sourceforge.net/projects/vjoystick/ \n\
 3. Run vJoy Monitor and verify buttons 1 and 2  \n\
 4. Leave this window running and open up MSFS \n\
 5. Ensure the AuthentKit trim wheel isn't bound to anything in MSFS directly \n\
 6. Map button 1 and 2 of your vJoy device in MSFS to Elevator Trim Up and Down \n\
\n\
Limitations: \n\
 - Elevator trim wheel is expected at Buttons 11 and 12 of the 'BU0836 Interface' \n\
 - Elevator trim outputs are be mapped across to vJoy buttons 1 and 2 \n\
")
    info.config(state=tk.DISABLED)

    credit = tk.Label(bottomFrame, text="By Ian Colman for AuthentiKit. Free to use under Creative Commons License BY NC ND 4.0",
		 fg = "orange",
         bg = "black",
		 font = "Verdana 10 bold",
         width = 750)
    credit.pack()

    # Run the GUI
    root.mainloop()

    # On window close
    mapping_thread.stop()