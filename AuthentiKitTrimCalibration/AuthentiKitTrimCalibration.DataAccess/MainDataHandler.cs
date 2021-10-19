using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;

namespace AuthentiKitTrimCalibration.DataAccess
{
    public class MainDataHandler : IMainDataHandler
    {
        private readonly string FILENAME = "settings.xml";
        public MappingDTO GetDefaultMapping()
        {
            return new MappingDTO { Name = "New Mapping" };
        }

        public IEnumerable<MappingDTO> LoadMappings()
        {
            // Open the XML Document
            XmlDocument settingsFile = new();
            settingsFile.Load(FILENAME);
            XmlNode mappingsNode = settingsFile.SelectSingleNode("MAPPINGS");

            // Loop through each mapping
            List<MappingDTO> mappings = new();
            foreach (XmlNode mappingNode in mappingsNode.ChildNodes)
            {
                // Parse values from XML
                try
                {
                    string name = mappingNode.SelectSingleNode("NAME").InnerText;
                    int typeId = int.Parse(mappingNode.SelectSingleNode("TYPE_ID").InnerText);
                    bool active = bool.Parse(mappingNode.SelectSingleNode("ACTIVE").InnerText);
                    int multiplier = int.Parse(mappingNode.SelectSingleNode("MULTIPLIER").InnerText);
                    string resetCommand = mappingNode.SelectSingleNode("RESET_COMMAND").InnerText;

                    // Create Mapping from values and add to mappings list
                    mappings.Add(new MappingDTO
                    {
                        Name = name,
                        TypeId = typeId,
                        Active = active,
                        InputChannelA = new InputChannel(),
                        InputChannelB = new InputChannel(),
                        OutputChannel = new OutputChannel(),
                        Multiplier = multiplier,
                        ResetCommand = resetCommand
                    });
                }
                catch
                {
                    throw new Exception("Error reading or understanding settings.xml");
                }
            }
            return mappings;
        }

        /*
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
                          OutputChannel = new OutputChannel(),
                          Multiplier = 341, // 2 full turns Nose Up and 2 full turns Nose Down (use bodnar PW of 24ms)
                          ResetCommand = "CTRL+T"
                        },new MappingDTO
                        {
                          Name = "Rudder Trim Axis",
                          TypeId = MappingType.AXIS,
                          Active = false,
                          InputChannelA = new InputChannel(),
                          InputChannelB = new InputChannel(),
                          OutputChannel = new OutputChannel(),
                          Multiplier = 341, // 2 full turns Nose Up and 2 full turns Nose Down (use bodnar PW of 24ms)
                          ResetCommand = "CTRL+T"
                        }
                    };
                }*/

        public void SaveMappings(IEnumerable<MappingDTO> mappings)
        {
            Debug.WriteLine("*** SAVE MAPPINGS IS NOT YET IMPLEMENTED ***");
        }
    }
}
