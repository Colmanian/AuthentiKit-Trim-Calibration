import pygame
import keyboard
import pyvjoy
import os
from tkinter import *
from time import sleep

# Author: Ian Colman
# License: Creative Commons BY NC ND 4.0
# Credits:  https://github.com/tidzo/pyvjoy for the vJoy DLL wrapper 
#           https://sourceforge.net/projects/vjoystick/ for the vJoy DLL


# # Initalise GUI Window
# root = Tk()
# root.title('AuthentiKit Trim Calibration')
# root.iconbitmap(os.path.join(os.path.dirname(os.path.realpath(__file__)), "..\images\icon.ico"))
# root.geometry("800x800")

# # Add drop downs to the GUI
# clicked = StringVar()
# outputButton1 = OptionMenu(root, clicked, "vJoy1:Button1", "vJoy1:Button2")
# outputButton1.pack()

# # Run the GUI
# root.mainloop()

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
done = False
while not done:

    sleep(0.001)
    ticks += 1
    ticks_since_encoder_pulse += 1

    if keyboard.is_pressed('esc'):
            done = True 

    # for event in pygame.event.get():
    #     if event.type == pygame.JOYBUTTONDOWN:
    #         #joystick = pygame.joystick.Joystick(event.joy)
    #         #joystick.init()
    #         #name = joystick.get_name()
    #         button = event.button
    #         #print("{}".format(name), "Button {}".format(button))
    #         for n in range(0, multiplier_map[button]):
    #             j.set_button(button_map[event.button],1)
    #             sleep(0.02)
    #             j.set_button(button_map[event.button],0)
    #             sleep(0.02)

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
                        print ("Button {} ".format(active_button), " PULSE x{}".format(multiplier_map[active_button]),  "ticks: {}".format(ticks))
                    else:
                        print ("Button {} ".format(active_button), " HOLD, ticks: {}".format(ticks))

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
                    print ("Button {} ".format(active_button), " ON, ticks: {}".format(ticks))
    
    if (active_button != None) and (ticks_since_encoder_pulse > OFF_THRESHOLD):
        # Turn Off
        print ("Button {} ".format(active_button), " OFF, ticks: {}".format(ticks))
        j.set_button(button_map[active_button],0)
        active_button = None
               