import pygame
import keyboard
import pyvjoy
from time import sleep

# Author: Ian Colman
# License: Creative Commons BY NC ND 4.0
# Credits:  https://github.com/tidzo/pyvjoy for the vJoy DLL wrapper 
#           https://sourceforge.net/projects/vjoystick/ for the vJoy DLL

# Initialize the real joysticks
pygame.init()
pygame.joystick.init()
joystick_count = pygame.joystick.get_count()
for i in range(joystick_count):
        joystick = pygame.joystick.Joystick(i)
        joystick.init()

# Initialise the virtual joysticks
j = pyvjoy.VJoyDevice(1)

done = False
while not done:
    
    if keyboard.is_pressed('esc'):
            done = True 

    button_map = {10:1, 11:2}
    multiplier_map = {10:3, 11:3}

    for event in pygame.event.get():
        if event.type == pygame.JOYBUTTONDOWN:
            joystick = pygame.joystick.Joystick(event.joy)
            joystick.init()
            name = joystick.get_name()
            button = event.button
            print("{}".format(name), "Button {}".format(button))
            for n in range(0, multiplier_map[button]):
                j.set_button(button_map[event.button],1)
                sleep(0.05)
                j.set_button(button_map[event.button],0)
                sleep(0.05)