using MappingManager.Common.Model;
using SharpDX.DirectInput;
using vJoyInterfaceWrap;
using System;
using System.Collections.ObjectModel;

namespace AuthentiKitTrimCalibration.DataAccess
{
    public static class HardwareInfo
    {
        public static ObservableCollection<InputChannel> GetInputChannels()
        {
            ObservableCollection<InputChannel> inputChannels = new();
            var directInput = new DirectInput();
            foreach (var d in directInput.GetDevices())
            {

                if ((d.Subtype != 256) && (d.Type != DeviceType.Keyboard) && (d.Type != DeviceType.Mouse) && (!d.InstanceName.Contains("vJoy")))
                {
                    var joystick = new Joystick(directInput, d.InstanceGuid);
                    var buttons = joystick.Capabilities.ButtonCount;
                    for (int i = 0; i < buttons; i++)
                    {
                        inputChannels.Add(item: new InputChannel { Guid = d.InstanceGuid, Device = d.InstanceName, Button = i, DisplayString = string.Format(d.InstanceName + ": Button " + (i + 1)) });
                    }
                }
            }
            return inputChannels;
        }

        public static ObservableCollection<OutputChannel> GetOutputChannels()
        {
            ObservableCollection<OutputChannel> outputChannels = new();
            vJoy joystick = new vJoy();
            int output_id = 0;

            for (uint vjoy_id = 1; vjoy_id <= 16; vjoy_id++)
            {
                // Buttons
                for (uint b = 1; b <= joystick.GetVJDButtonNumber(vjoy_id); b++)
                {
                    outputChannels.Add(new OutputButton { VJoyId = output_id, VJoyDevice = vjoy_id, VJoyItem = b });
                }

                // Axes
                VjdStat status = joystick.GetVJDStatus(vjoy_id);
                if (status == VjdStat.VJD_STAT_FREE)
                {
                    foreach (HID_USAGES axis in Enum.GetValues(typeof(HID_USAGES)))
                    {
                        if (joystick.GetVJDAxisExist(vjoy_id, axis))
                        {
                            outputChannels.Add(new OutputAxis { VJoyId = output_id, VJoyDevice = vjoy_id, VJoyItem = (uint)axis });
                            output_id++;
                        }
                    }
                }
            }
            return outputChannels;
        }
    }
}
