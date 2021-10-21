using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Xml;
using static MappingManager.Common.Model.OutputAxis;

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
        private readonly string INPUT_CHANNEL_A_HASH = "INPUT_CHANNEL_A_HASH";
        private readonly string INPUT_CHANNEL_B_HASH = "INPUT_CHANNEL_B_HASH";
        private readonly string OUTPUT_CHANNEL_HASH = "OUTPUT_CHANNEL_HASH";
        private readonly string MULTIPLIER = "MULTIPLIER";
        private readonly string RESET_COMMAND = "RESET_COMMAND";

        public MappingDTO GetBlankMapping()
        {
            return new MappingDTO { Name = "New Mapping" };
        }

        public IEnumerable<MappingDTO> LoadMappings(ObservableCollection<InputChannel> inputChannelsA, ObservableCollection<InputChannel> inputChannelsB, ObservableCollection<OutputChannel> outputChannels)
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
                    int inputChannelAHash = int.Parse(mappingNode.SelectSingleNode(INPUT_CHANNEL_A_HASH).InnerText);
                    int inputChannelBHash = int.Parse(mappingNode.SelectSingleNode(INPUT_CHANNEL_B_HASH).InnerText);
                    int outputChannelHash = int.Parse(mappingNode.SelectSingleNode(OUTPUT_CHANNEL_HASH).InnerText);
                    int multiplier = int.Parse(mappingNode.SelectSingleNode(MULTIPLIER).InnerText);
                    string resetCommand = mappingNode.SelectSingleNode(RESET_COMMAND).InnerText;

                    // Create Mapping from values and add to mappings list
                    mappings.Add(new MappingDTO
                    {
                        Name = name,
                        TypeId = typeId,
                        Active = active,
                        InputChannelA = GetInputChannel(inputChannelAHash, inputChannelsA),
                        InputChannelB = GetInputChannel(inputChannelBHash, inputChannelsB),
                        OutputChannel = GetOutputChannel(outputChannelHash, outputChannels),
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
            XmlDocument doc = new();
            XmlElement mappingsNode = doc.CreateElement(MAPPINGS);

            foreach (var mapping in mappings)
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
                XmlElement inputChannelANode = doc.CreateElement(INPUT_CHANNEL_A_HASH);
                inputChannelANode.InnerText = String.Format("{0}", mapping.InputChannelA.Hash);
                mappingNode.AppendChild(inputChannelANode);

                // InputChannelB
                XmlElement inputChannelBNode = doc.CreateElement(INPUT_CHANNEL_B_HASH);
                inputChannelBNode.InnerText = String.Format("{0}", mapping.InputChannelB.Hash);
                mappingNode.AppendChild(inputChannelBNode);

                // OutputChannel
                XmlElement outputChannelNode = doc.CreateElement(OUTPUT_CHANNEL_HASH);
                outputChannelNode.InnerText = String.Format("{0}", mapping.OutputChannel.Hash);
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
        private static InputChannel GetInputChannel(int hash, ObservableCollection<InputChannel> inputChannels)
        {
            foreach (var channel in inputChannels)
            {
                if (channel.Hash == hash)
                {
                    return channel;
                }
            }
            return new InputChannel();
        }
        private static OutputChannel GetOutputChannel(int hash, ObservableCollection<OutputChannel> outputChannels)
        {
            foreach (var channel in outputChannels)
            {
                if (channel.Hash == hash)
                {
                    return channel;
                }
            }
            return new OutputChannel();
        }

        /// Returns an AuthentiKit or BU0836 input channel for the specified button, if available
        private InputChannel getAuthentiKitInputChannel(ObservableCollection<InputChannel> channels, int button)
        {
            foreach (var channel in channels)
                if ((channel.Button == button) && (channel.Device.Contains("AuthentiKit")))
                    return channel;

            foreach (var channel in channels)
                if ((channel.Button == button) && (channel.Device.Contains("BU0836")))
                    return channel;

            return new InputChannel();
        }

        /// Returns the specified vJoy output if available
        private OutputChannel getOutputChannel (ObservableCollection<OutputChannel> channels, uint vJoyItem)
        {
            foreach (var channel in channels)
                if (channel.VJoyItem == vJoyItem)
                    return channel;
            return new OutputAxis();
        }
        public IEnumerable<MappingDTO> GetDefaultMappings(Aircraft aircraft, ObservableCollection<InputChannel> inputChannelsA, ObservableCollection<InputChannel> inputChannelsB, ObservableCollection<OutputChannel> outputChannels)
        {
            ObservableCollection<MappingDTO> mappings = new();
            if (aircraft == Aircraft.SPITFIRE_MKIX)
            {
                // Elevator Trim Axis
                mappings.Add(new MappingDTO {
                    Name = "Elevator Trim (Axis)",
                    InputChannelA = getAuthentiKitInputChannel(inputChannelsA, 10),
                    InputChannelB = getAuthentiKitInputChannel(inputChannelsB, 11),
                    OutputChannel = getOutputChannel(outputChannels, (uint) AxisId.X),
                    Multiplier = 347,
                });

                // Rudder Trum Button
                //TODO
            }
            return mappings;
        }
    }
}
