using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System.Collections.Generic;
using System.Diagnostics;

namespace AuthentiKitTrimCalibration.DataAccess
{
    public class MainDataHandler : IMainDataHandler
    {
        public MappingDTO GetDefaultMapping()
        {
            return new MappingDTO { Name = "New Mapping" };
        }

        public IEnumerable<MappingDTO> LoadMappings()
        {
            return new List<MappingDTO>
            {
                new MappingDTO
                {
                  Name = "Elevator Trim Axis",
                  TypeId = MappingType.AXIS,
                  Active = true,
                  InputChannelA = new InputChannel(),
                  InputChannelB = new InputChannel(),
                  OutputChannel = new OutputAxis(),
                  Multiplier = 341, // 2 full turns Nose Up and 2 full turns Nose Down (use bodnar PW of 24ms)
                  ResetCommand = "CTRL+T"
                },new MappingDTO
                {
                  Name = "Rudder Trim (Left)",
                  TypeId = MappingType.BUTTON,
                  Active = false,
                  InputChannelA = new InputChannel(),
                  InputChannelB = new InputChannel(),
                  OutputChannel = new OutputButton(),
                  Multiplier = 3,
                  HoldThresholdStart = 500,
                  HoldThresholdStop = 200
                },new MappingDTO
                {
                  Name = "Rudder Trim (Right)",
                  TypeId = MappingType.BUTTON,
                  Active = true,
                  Errored = true,
                  InputChannelA = new InputChannel(),
                  InputChannelB = new InputChannel(),
                  OutputChannel = new OutputButton(),
                  Multiplier = 3,
                  HoldThresholdStart = 500,
                  HoldThresholdStop = 200
                }
            };
        }

        public void SaveMappings(IEnumerable<MappingDTO> mappings)
        {
            Debug.WriteLine("*** SAVE MAPPINGS IS NOT YET IMPLEMENTED ***");
        }
    }
}
