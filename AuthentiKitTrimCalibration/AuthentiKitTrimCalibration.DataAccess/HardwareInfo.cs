using MappingManager.Common.Model;
using System.Collections.Generic;
using System.Diagnostics;
using SharpDX.DirectInput;
using vJoyInterfaceWrap;
using System;
using static MappingManager.Common.Model.OutputAxis;

namespace AuthentiKitTrimCalibration.DataAccess
{
    public static class HardwareInfo
    {
        public static IEnumerable<InputChannel> GetInputChannels()
        {
            List<InputChannel> inputChannels = new();
            var directInput = new DirectInput();
            foreach (var d in directInput.GetDevices())
            {

                if ((d.Subtype != 256) && (d.Type != DeviceType.Keyboard) && (d.Type != DeviceType.Mouse) && (!d.InstanceName.Contains("vJoy")))
                {
                    var joystick = new Joystick(directInput, d.InstanceGuid);
                    var buttons = joystick.Capabilities.ButtonCount;
                    for (int i = 1; i <= buttons; i++)
                    {
                        inputChannels.Add(item: new InputChannel { Id = d.InstanceGuid, Device = d.InstanceName, Button = i });
                    }
                }
            }
            return inputChannels;
        }

        public static IEnumerable<OutputChannel> GetOutputChannels()
        {
            List<OutputChannel> outputChannels = new();
            vJoy joystick = new vJoy();
            int output_id = 0;

            for (uint vjoy_id = 1; vjoy_id <= 16; vjoy_id++)
            {
                // Buttons
                for (uint b = 1; b <= joystick.GetVJDButtonNumber(vjoy_id); b++)
                {
                    outputChannels.Add(new OutputButton { Id = output_id, VJoyDevice = vjoy_id, VJoyItem = b});
                }

                // Axes
                VjdStat status = joystick.GetVJDStatus(vjoy_id);
                if (status == VjdStat.VJD_STAT_FREE)
                {
                    foreach (HID_USAGES axis in Enum.GetValues(typeof(HID_USAGES)))
                    {
                        if (joystick.GetVJDAxisExist(vjoy_id, axis))
                        {
                            outputChannels.Add(new OutputAxis { Id = output_id, VJoyDevice = vjoy_id, VJoyItem = (uint)axis });
                            output_id++;
                        }
                    }
                }
            }


            return outputChannels;
        }
    }
}
