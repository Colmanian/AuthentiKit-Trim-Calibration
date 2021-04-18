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
        self.NO_DEVICES_MSG = "No devices found"
        self.input_device = self.NO_DEVICES_MSG
        self.output_device = self.NO_DEVICES_MSG

        # Hard code mappings and multipliers (for proof ofs concept)
        self.button_map = {10:1, 11:2, 8:3, 9:4}
        self.multiplier_map = {10:3, 11:3, 8:3, 9:3}


    def stop(self):
        self.running = False

    def run(self):   

        # Timing information
        ticks = 0
        ticks_since_encoder_pulse = 0 
        HOLD_THRESHOLD = 500 #~ms
        OFF_THRESHOLD = 200 #~ms
        PULSE_WIDTH_SEC = 0.020 # 20 ms
        active_button = None # (Only supports one button active at a time currently)

        # Initalise PyGame
        pygame.init()
        pygame.joystick.init()
        joystick_count = pygame.joystick.get_count()
        for i in range(joystick_count):
                joystick = pygame.joystick.Joystick(i)
                joystick.init()

        def set_vJoy_button(button, value):
            j = pyvjoy.VJoyDevice(int(self.output_device))
            j.set_button(button, value)

        # Main Loop
        while self.running:

            if (self.input_device != self.NO_DEVICES_MSG) and (self.output_device != self.NO_DEVICES_MSG):
                sleep(0.001)
                ticks += 1
                ticks_since_encoder_pulse += 1

                j = pyvjoy.VJoyDevice(int(self.output_device))

                for event in pygame.event.get():

                    if event.type == pygame.JOYBUTTONDOWN:

                        joystick = pygame.joystick.Joystick(event.joy).get_name()
                        button = event.button
                        if (joystick == self.input_device):

                            if button == active_button:                    
                                ticks_since_encoder_pulse = 0
                                if ticks < HOLD_THRESHOLD:
                                    # Pulse vButton
                                    for _ in range(0, self.multiplier_map[active_button]):
                                        sleep(PULSE_WIDTH_SEC)
                                        set_vJoy_button(self.button_map[active_button],0)
                                        sleep(PULSE_WIDTH_SEC)
                                        ticks += int(PULSE_WIDTH_SEC*1000)
                                        set_vJoy_button(self.button_map[active_button],1)
                                    print ("BU0836 Button {}".format(active_button), "to vJoy1 Button {}".format(self.button_map[active_button]),  "(Pulsing)")
                                else:
                                    print ("BU0836 Button {}".format(active_button), "to vJoy1 Button {}".format(self.button_map[active_button]),  "(Holding on)")

                            elif active_button == None and (button in self.button_map):

                                # Turn On
                                ticks = 0
                                ticks_since_encoder_pulse = 0
                                active_button = button
                                # Pulse vButton
                                for n in range(0, self.multiplier_map[active_button]):
                                    sleep(PULSE_WIDTH_SEC)
                                    set_vJoy_button(self.button_map[active_button],0)
                                    sleep(PULSE_WIDTH_SEC)
                                    ticks += int(PULSE_WIDTH_SEC*1000)
                                    set_vJoy_button(self.button_map[active_button],1)
                                    print ("BU0836 Button {}".format(active_button), "to vJoy1 Button {}".format(self.button_map[active_button]),  "(Pulsing)")
                
                if (active_button != None) and (ticks_since_encoder_pulse > OFF_THRESHOLD):
                    # Turn Off
                    print ("BU0836 Button {}".format(active_button), "to vJoy1 Button {}".format(self.button_map[active_button]),  "(Turning off)")
                    set_vJoy_button(self.button_map[active_button],0)
                    active_button = None

    def get_input_list(self) -> list[str]:
        device_list = [self.input_device]
        
        # Get real joystick info
        try:
            pygame.init()
            pygame.joystick.init()
            joystick_count = pygame.joystick.get_count()
            if joystick_count > 0:
                device_list = []
                for i in range(joystick_count):
                        joystick = pygame.joystick.Joystick(i)
                        joystick.init()
                        if "vJoy" not in joystick.get_name():
                            device_list.append(joystick.get_name())
        except Exception:
            device_list = ["Problem getting devices"]

        return device_list

    def get_output_list(self) -> list[str]:
        device_list = []
        
        for i in range (1,17):
            try:
                pyvjoy.VJoyDevice(i)
                device_list.append(i)
            except:
                break

        if not device_list:
                device_list = [self.NO_DEVICES_MSG]
                
        return device_list
    
    def set_input_device(self, device):
        self.input_device = device

    def set_output_device(self, device):
        self.output_device = device

if __name__ == '__main__':
    mapping_thread = MappingThread()
    mapping_thread.start()

    # Initalise window 
    root = tk.Tk()
    root.title('AuthentiKit Trim Calibration')
    root.geometry("750x410")

    mainframe = tk.Frame(root, bg = "#f0f0f0")
    mainframe.grid(column=0,row=0, sticky=(tk.N, tk.W, tk.E, tk.S) )
    mainframe.columnconfigure(0, weight = 1)
    mainframe.rowconfigure(0, weight = 1)
    mainframe.pack(pady = 100, padx = 100)
    mainframe.pack()

    bottomFrame = tk.Frame(root)
    bottomFrame.pack(side=tk.BOTTOM)
    bottomFrame.pack()

    # Input Device List
    inputStringVar = tk.StringVar(root)
    input_list = mapping_thread.get_input_list()
    popupMenu = tk.OptionMenu(mainframe, inputStringVar, *input_list)
    tk.Label(mainframe, text="Input").grid(row = 1, column = 1)
    popupMenu.grid(row = 2, column =1)
    def input_callback(*args):
        mapping_thread.set_input_device(inputStringVar.get())
    inputStringVar.trace("w", input_callback)

    # Output Device List
    outputStringVar = tk.StringVar(root)
    output_list = mapping_thread.get_output_list()
    popupMenu = tk.OptionMenu(mainframe, outputStringVar, *output_list)
    tk.Label(mainframe, text="vJoy").grid(row = 1, column = 3)
    popupMenu.grid(row = 2, column =3)
    def output_callback(*args):
        mapping_thread.set_output_device(outputStringVar.get())
    outputStringVar.trace("w", output_callback)

    # Credits Bar
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