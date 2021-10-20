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
        private readonly string MAPPINGS = "MAPPINGS";
        private readonly string MAPPING = "MAPPING";
        private readonly string NAME = "NAME";
        private readonly string TYPE_ID = "TYPE_ID";
        private readonly string ACTIVE = "ACTIVE";
        private readonly string INPUT_CHANNEL_A = "INPUT_CHANNEL_A";
        private readonly string INPUT_CHANNEL_B = "INPUT_CHANNEL_B";
        private readonly string OUTPUT_CHANNEL = "OUTPUT_CHANNEL";
        private readonly string MULTIPLIER = "MULTIPLIER";
        private readonly string RESET_COMMAND = "RESET_COMMAND";

        public MappingDTO GetBlankMapping()
        {
            return new MappingDTO { Name = "New Mapping" };
        }

        public IEnumerable<MappingDTO> GetDefaultMappings()
        {
            //TODO Load in standard setup for Spit MkIX, and if AuthentiKit is detected, select appropriate inputs.
            throw new NotImplementedException();
        }

        public IEnumerable<MappingDTO> LoadMappings()
        {
            // Open the XML Document
            XmlDocument settingsFile = new();
            settingsFile.Load(FILENAME);
            XmlNode mappingsNode = settingsFile.SelectSingleNode(MAPPINGS);

            // Loop through each mapping
            List<MappingDTO> mappings = new();
            foreach (XmlNode mappingNode in mappingsNode.ChildNodes)
            {
                // Parse values from XML
                try
                {
                    string name = mappingNode.SelectSingleNode(NAME).InnerText;
                    int typeId = int.Parse(mappingNode.SelectSingleNode(TYPE_ID).InnerText);
                    bool active = bool.Parse(mappingNode.SelectSingleNode(ACTIVE).InnerText);
                    int multiplier = int.Parse(mappingNode.SelectSingleNode(MULTIPLIER).InnerText);
                    string resetCommand = mappingNode.SelectSingleNode(RESET_COMMAND).InnerText;

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
                    throw new Exception("Error finding or reading settings.xml");
                }
            }
            return mappings;
        }
        public void SaveMappings(IEnumerable<MappingDTO> mappings)
        {
            XmlDocument doc = new ();
            XmlElement mappingsNode = doc.CreateElement(MAPPINGS);

            foreach(var mapping in mappings)
            {
                XmlElement mappingNode = doc.CreateElement(MAPPING);

                // Name
                XmlElement nameNode = doc.CreateElement(NAME);
                nameNode.InnerText = mapping.Name;
                mappingNode.AppendChild(nameNode);

                // TypeId
                XmlElement typeIdNode = doc.CreateElement(TYPE_ID);
                typeIdNode.InnerText = String.Format("{0}", mapping.TypeId);
                mappingNode.AppendChild(typeIdNode);

                // Active
                XmlElement activeNode = doc.CreateElement(ACTIVE);
                activeNode.InnerText = String.Format("{0}", mapping.Active);
                mappingNode.AppendChild(activeNode);

                // InputChannelA
                XmlElement inputChannelANode = doc.CreateElement(INPUT_CHANNEL_A);
                inputChannelANode.InnerText = " ";
                mappingNode.AppendChild(inputChannelANode);

                // InputChannelB
                XmlElement inputChannelBNode = doc.CreateElement(INPUT_CHANNEL_B);
                inputChannelBNode.InnerText = " ";
                mappingNode.AppendChild(inputChannelBNode);

                // OutputChannel
                XmlElement outputChannelNode = doc.CreateElement(OUTPUT_CHANNEL);
                outputChannelNode.InnerText = " ";
                mappingNode.AppendChild(outputChannelNode);

                // Multiplier
                XmlElement multiplierNode = doc.CreateElement(MULTIPLIER);
                multiplierNode.InnerText = String.Format("{0}", mapping.Multiplier);
                mappingNode.AppendChild(multiplierNode);

                // ResetCommand
                XmlElement resetCommandNode = doc.CreateElement(RESET_COMMAND);
                resetCommandNode.InnerText = mapping.ResetCommand;
                mappingNode.AppendChild(resetCommandNode);
                mappingsNode.AppendChild(mappingNode);
            }

            doc.AppendChild(mappingsNode);
            doc.Save(FILENAME);
        }
    }
}
