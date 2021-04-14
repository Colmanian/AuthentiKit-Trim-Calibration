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
multiplier_map = {10:4, 11:4}

# Timing information
ticks = 0
HOLD_ON_THRESHOLD_MS = 100
active_button = None # (Only supports one button active at a time currently)

# Main Loop
done = False
while not done:

    sleep(0.001)
    ticks += 1

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

                # If we're still turning the active trim wheel, reset the timer
                if button == active_button:
                    ticks = 0

                # If we're starting to turn a trim wheel, then turn out the output 
                elif active_button == None and (button in button_map):
                    ticks = 0
                    active_button = button
                    j.set_button(button_map[active_button],1)
                
                # Else ignore all other events while we're dealing with this trim turn
    
    # If we're outputting but haven't seen an movement for the threshold time, then turn it off
    if (active_button != None) and (ticks > HOLD_ON_THRESHOLD_MS):
            j.set_button(button_map[active_button],0)
            active_button = None