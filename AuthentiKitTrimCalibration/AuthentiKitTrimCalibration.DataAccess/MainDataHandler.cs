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
                  Name = "Elevator Trim Axis",
                  Type = MappingDTO.MappingType.Axis,
                  Active = true,
                  InputID_A = 0,
                  InputID_B = 0,
                  OutputId = 0,
                  Multiplier = 3,
                  ResetCommand = "CTRL+T"
                },new MappingDTO
                {
                  Name = "Rudder Trim (Left)",
                  Type = MappingDTO.MappingType.Button,
                  Active = false,
                  InputID_A = 0,
                  OutputId = 0,
                  Multiplier = 3,
                  HoldThresholdStart = 200,
                  HoldThresholdStop = 200
                },new MappingDTO
                {
                  Name = "Rudder Trim (Right)",
                  Type = MappingDTO.MappingType.Button,
                  Active = true,
                  Errored = true,
                  InputID_A = 0,
                  OutputId = 0,
                  Multiplier = 3,
                  HoldThresholdStart = 200,
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
