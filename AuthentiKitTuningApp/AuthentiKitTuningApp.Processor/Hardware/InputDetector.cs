using AuthentiKitTuningApp.Common.DataProvider;
using AuthentiKitTuningApp.Common.Model;
using System.Diagnostics;
using System.Threading;
using System;
using SharpDX.DirectInput;
using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace AuthentiKitTuningApp.Processor.Hardware
{
    public class InputDetector : IInputDetector
    {
        public InputAxis DetectAxis()
        {
            throw new NotImplementedException();
        }

        public InputButton DetectButton()
        {
            InputButton detected = new();
            var directInput = new DirectInput();
            var allDevices = directInput.GetDevices();
            var joysticks = new ObservableCollection<Joystick>();
            var currentStates = new ObservableCollection<bool[]>();
            var priorStates = new ObservableCollection<bool[]>();
            var devices = new ObservableCollection<DeviceInstance>();


            // For each device
            foreach (var d in allDevices)
            {
                if (d.Subtype != 256 && d.Type != DeviceType.Keyboard && d.Type != DeviceType.Mouse && !d.InstanceName.Contains("vJoy"))
                {
                    Debug.WriteLine("Creating Joystick object for" + d.InstanceName);
                    devices.Add(d);
                    var joystick = new Joystick(directInput, d.InstanceGuid);
                    joystick.Properties.BufferSize = 128;
                    joystick.Acquire();
                    joysticks.Add(joystick);
                }
            }

            if (devices.Count < 1)
            {
                return null;
            }

            // Create state arrays
            foreach (var j in joysticks)
            {
                currentStates.Add(new bool[j.GetCurrentState().Buttons.Length]);
                priorStates.Add(new bool[j.GetCurrentState().Buttons.Length]);
            }

            // Initial State
            for (int i = 0; i < joysticks.Count; i++)
            {
                joysticks[i].GetCurrentState().Buttons.CopyTo(currentStates[i], 0);
                currentStates[i].CopyTo(priorStates[i], 0);
            }

            // Detect Loop
            bool found = false;
            while (!found)
            {
                for (int i = 0; i < joysticks.Count; i++)
                {
                    Thread.Sleep(2); // Pole button state every this milliseconds

                    joysticks[i].GetCurrentState().Buttons.CopyTo(currentStates[i], 0);
                    for (int button = 0; button < currentStates[i].Length; button++)
                    {
                        if (currentStates[i][button] != priorStates[i][button])
                        {
                            Debug.WriteLine(devices[i].InstanceName + ": Button " + button);
                            detected = new InputButton
                            {
                                Guid = devices[i].ProductGuid,
                                Device = devices[i].InstanceName,
                                Button = button,
                                Name = string.Format(devices[i].InstanceName + ": Button " + (button + 1))
                            };
                            found = true;
                            break;
                        }
                    }
                    currentStates[i].CopyTo(priorStates[i], 0);
                }
            }

            foreach (var joystick in joysticks)
            {
                joystick.Unacquire();
            }

            return detected;
        }
    }
}