using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                  Name = "Elevator Trim (Up)",
                  InputId = 1,
                  OutputId = 2,
                  Multiplier = 3,
                  HoldThresholdStart = 200,
                  HoldThresholdStop = 200,
                  ResetCommand = "CTRL+T"
                },new MappingDTO
                {
                  Name = "Elevator Trim (Down)",
                  InputId = 2,
                  OutputId = 1,
                  Multiplier = 3,
                  HoldThresholdStart = 200,
                  HoldThresholdStop = 200,
                  ResetCommand = "CTRL+T"
                },new MappingDTO
                {
                  Name = "Rudder Trim (Left)",
                  InputId = 1,
                  OutputId = 2,
                  Multiplier = 3,
                  HoldThresholdStart = 200,
                  HoldThresholdStop = 200,
                  ResetCommand = "CTRL+T"
                },new MappingDTO
                {
                  Name = "Rudder Trim (Right)",
                  InputId = 3,
                  OutputId = 2,
                  Multiplier = 3,
                  HoldThresholdStart = 200,
                  HoldThresholdStop = 200,
                  ResetCommand = "CTRL+T"
                }
            };
        }

        public void SaveMappings(IEnumerable<MappingDTO> mappings)
        {
            Debug.WriteLine("*** SAVE MAPPINGS IS NOT YET IMPLEMENTED ***");
        }
    }
}
