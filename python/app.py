import pygame
import keyboard

# Initialize the joysticks.
pygame.init()
pygame.joystick.init()
joystick_count = pygame.joystick.get_count()
for i in range(joystick_count):
        joystick = pygame.joystick.Joystick(i)
        joystick.init()

done = False
while not done:
    
    if keyboard.is_pressed('esc'):
            done = True 

    key_map = {10:'NUM 1', 11:'NUM 7'}
    multiplier_map = {10:10, 11:10}

    for event in pygame.event.get():
        if event.type == pygame.JOYBUTTONDOWN:
            joystick = pygame.joystick.Joystick(event.joy)
            joystick.init()
            name = joystick.get_name()
            button = event.button
            print("{}".format(name), "Button {}".format(button))
            for n in range(0, multiplier_map[button]):
                keyboard.send(key_map[event.button])