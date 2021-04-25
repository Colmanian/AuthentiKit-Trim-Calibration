using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AuthentiKitTrimCalibration.DataAccess
{
    public class MappingDataProvider : IMappingDataProvider
    {
        public IEnumerable<Mapping> LoadMappings()
        {
            return new List<Mapping>
            {
                new Mapping
                {
                  Name = "Elevator Trim (Up)",
                  Input = "Not Implemented",
                  Output = "Not Implemented",
                  Multiplier = 3,
                  HoldThresholdStart = 200,
                  HoldThresholdStop = 200,
                  ResetCommand = "CTRL+T"
                },new Mapping
                {
                  Name = "Elevator Trim (Down)",
                  Input = "Not Implemented",
                  Output = "Not Implemented",
                  Multiplier = 3,
                  HoldThresholdStart = 200,
                  HoldThresholdStop = 200,
                  ResetCommand = "CTRL+T"
                },new Mapping
                {
                  Name = "Rudder Trim (Left)",
                  Input = "Not Implemented",
                  Output = "Not Implemented",
                  Multiplier = 3,
                  HoldThresholdStart = 200,
                  HoldThresholdStop = 200,
                  ResetCommand = "CTRL+T"
                },new Mapping
                {
                  Name = "Rudder Trim (Right)",
                  Input = "Not Implemented",
                  Output = "Not Implemented",
                  Multiplier = 3,
                  HoldThresholdStart = 200,
                  HoldThresholdStop = 200,
                  ResetCommand = "CTRL+T"
                }
            };
        }

        public void ApplyMapping(Mapping mapping)
        {
            Debug.WriteLine($"APPLY IS UNIMPLEMTNED: {mapping.Name}");
        }

        public IEnumerable<Device> LoadDevices()
        {
            Debug.WriteLine("LOAD DEVICES IS UNIMPLEMTNED");
            return new List<Device>
            {
                new Device{ Id = 1, Name = "Dummy Device A" },
                new Device{ Id = 2, Name = "Dummy Device B" },
            };
        }
    }
}