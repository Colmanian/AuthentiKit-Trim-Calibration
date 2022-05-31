using MappingManager.Common.Model;
using SharpDX.DirectInput;
using vJoyInterfaceWrap;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Collections.Generic;

namespace AuthentiKitTrimCalibration.DataAccess
{

    public static class HardwareInfo
    {
        private static List<JoystickOffset> joystickAxisOffsets = new List<JoystickOffset>() { JoystickOffset.X, JoystickOffset.Y, JoystickOffset.Z, JoystickOffset.RotationX, JoystickOffset.RotationY, JoystickOffset.RotationZ, JoystickOffset.Sliders0, JoystickOffset.Sliders1 };

        public static ObservableCollection<InputButton> GetInputButtons()
        {
            ObservableCollection<InputButton> inputButtons = new();
            var directInput = new DirectInput();
            foreach (var d in directInput.GetDevices())
            {
                if ((d.Subtype != 256) && (d.Type != DeviceType.Keyboard) && (d.Type != DeviceType.Mouse) && (!d.InstanceName.Contains("vJoy")))
                {
                    var joystick = new Joystick(directInput, d.InstanceGuid);
                    var buttons = joystick.Capabilities.ButtonCount;
                    for (int i = 0; i < buttons; i++)
                    {
                        inputButtons.Add(item: new InputButton { Guid = d.ProductGuid, Device = d.InstanceName, Button = i, Name = string.Format(d.InstanceName + ": Button " + (i + 1)) });

                    }
                }
            }
            return inputButtons;
        }


        public static ObservableCollection<InputAxis> GetInputAxes()
        {
            ObservableCollection<InputAxis> inputAxes = new();
            var directInput = new DirectInput();
            foreach (var d in directInput.GetDevices())

            {
                if ((d.Subtype != 256) && (d.Type != DeviceType.Keyboard) && (d.Type != DeviceType.Mouse) && (!d.InstanceName.Contains("vJoy")))
                {
                    var joystick = new Joystick(directInput, d.InstanceGuid);
                    var numberOfaxes = joystick.Capabilities.AxeCount;

                    for (int i = 0; i < numberOfaxes; i++)
                    {
                        try
                        {
                            var name = joystick.GetObjectInfoByName(joystickAxisOffsets[i].ToString()).Name;
                            Debug.WriteLine("+++ " + d.InstanceName + "    " + name);
                            inputAxes.Add(item: new InputAxis { Guid = d.ProductGuid, Device = d.InstanceName, Axis = i, Name = string.Format(d.InstanceName + ": Axis " + name) });
                        }
                        catch { }
                    }
                    /*for (int i = 0; i < buttons; i++)
                    {
                        inputAxes.Add(item: new InputButton { Guid = d.ProductGuid, Device = d.InstanceName, Button = i, Name = string.Format(d.InstanceName + ": Button " + (i + 1)) });

                    }*/
                }
            }
            return inputAxes;
        }

        public static ObservableCollection<OutputChannel> GetOutputAxes()
        {
            ObservableCollection<OutputChannel> outputChannels = new();
            vJoy joystick = new();
            int output_id = 0;
            for (uint vjoy_id = 1; vjoy_id <= 16; vjoy_id++)
            {
                // Axes
                VjdStat status = joystick.GetVJDStatus(vjoy_id);
                if (status == VjdStat.VJD_STAT_FREE)
                {
                    foreach (HID_USAGES axis in Enum.GetValues(typeof(HID_USAGES)))
                    {
                        if (joystick.GetVJDAxisExist(vjoy_id, axis))
                        {
                            outputChannels.Add(new OutputAxis
                            {
                                VJoyId = output_id++,
                                VJoyDevice = vjoy_id,
                                VJoyItem = (uint)axis
                            });
                        }
                    }
                }
            }
            return outputChannels;
        }

        public static ObservableCollection<OutputChannel> GetOutputButtons()
        {
            ObservableCollection<OutputChannel> outputChannels = new();
            vJoy joystick = new();
            int output_id = 0;
            for (uint vjoy_id = 1; vjoy_id <= 16; vjoy_id++)
            {
                // Buttons
                for (uint b = 1; b <= joystick.GetVJDButtonNumber(vjoy_id); b++)
                {
                    outputChannels.Add(new OutputButton
                    {
                        VJoyId = output_id++,
                        VJoyDevice = vjoy_id,
                        VJoyItem = b,
                    });
                }
            }
            return outputChannels;
        }
    }
}
