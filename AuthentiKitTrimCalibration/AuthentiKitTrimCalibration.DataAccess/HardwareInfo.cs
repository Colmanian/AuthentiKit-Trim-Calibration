using MappingManager.Common.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.DirectInput;

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
            Debug.WriteLine("LOAD DEVICES IS UNIMPLEMTNED");
            return new List<OutputChannel>
            {
                new OutputChannel{ Id = 0, VJoyDevice = 1, VJoyItem = 1 },
                new OutputChannel{ Id = 1, VJoyDevice = 1, VJoyItem = 2 },
                new OutputChannel{ Id = 1, VJoyDevice = 1, VJoyItem = 20},
            };
        }
    }
}
