using MappingManager.Common.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthentiKitTrimCalibration.DataAccess
{
    public static class HardwareInfo
    {
        public static IEnumerable<InputChannel> GetInputChannels()
        {
            Debug.WriteLine("LOAD DEVICES IS UNIMPLEMTNED");
            return new List<InputChannel>
            {
                new InputChannel{ Id = 0, Device = "Dummy Device A", Button = 1, DisplayText = "Device A: Button 1" },
                new InputChannel{ Id = 1, Device = "Dummy Device A", Button = 2, DisplayText = "Device A: Button 2" },
                new InputChannel{ Id = 2, Device = "Dummy Device B", Button = 1, DisplayText = "Device B: Button 1" },
            };
        }

        public static IEnumerable<OutputChannel> GetOutputChannels()
        {
            Debug.WriteLine("LOAD DEVICES IS UNIMPLEMTNED");
            return new List<OutputChannel>
            {
                new OutputChannel{ Id = 0, VJoyDevice = 1, VJoyItem = 1, DisplayText = "vJoy 1: Button 1" },
                new OutputChannel{ Id = 1, VJoyDevice = 1, VJoyItem = 2, DisplayText = "vJoy 1: Button 2" },
                new OutputChannel{ Id = 1, VJoyDevice = 1, VJoyItem = 20, DisplayText = "vJoy 1: Axis 1" },
            };
        }
    }
}
