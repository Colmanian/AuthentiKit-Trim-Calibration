using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Xml;
using static MappingManager.Common.Model.OutputAxis;

namespace AuthentiKitTrimCalibration.DataAccess
{
    public class DataHandler : IDataHandler
    {
        private readonly string CONFIG = "CONFIG";
        private readonly string GROUP = "GROUP";
        private readonly string MAPPING = "MAPPING";
        private readonly string NAME = "NAME";
        private readonly string TYPE_ID = "TYPE_ID";
        private readonly string ACTIVE = "ACTIVE";
        private readonly string INPUT_BUTTON_A_HASH = "INPUT_CHANNEL_A_HASH"; //(should be BUTTON rather than CHANNEL, but can't rename due to it already being in users' XML save file)
        private readonly string INPUT_BUTTON_B_HASH = "INPUT_CHANNEL_B_HASH"; //(should be BUTTON rather than CHANNEL, but can't rename due to it already being in users' XML save file)
        private readonly string OUTPUT_CHANNEL_HASH = "OUTPUT_CHANNEL_HASH";
        private readonly string AXIS_SENSITIVITY = "AXIS_SENSITIVITY";
        private readonly string ENCODER_PPR = "ENCODER_PPR";
        private readonly string REVS_IN_PER_REVS_OUT = "REVS_IN_PER_REVS_OUT";
        private readonly string BUTTON_MULTIPLIER = "BUTTON_MULTIPLIER";
        private readonly string RESET_COMMAND = "RESET_COMMAND";
        private readonly string REGISTRY_APP_SETTINGS = "SOFTWARE\\AuthentiKit"; //Under HKEY_CURRENT_USER
        private readonly string REGISTRY_SAVE_FILE_PATH = "SaveFileName";
        private readonly string REGISTRY_STARTUP_SETTINGS = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run"; //Under HKEY_CURRENT_USER
        private readonly string REGISTRY_STARTUP_APP_NAME = "AuthentiKit";

        private string SaveFilePath;

        public DataHandler()
        {
            // Get Save filepath from registry if there
            SaveFilePath = LoadFilePathFromRegistry();
        }

        public MappingDTO GetBlankMapping()
        {
            return new MappingDTO { Name = "New Mapping" };
        }

        public IEnumerable<MappingDTO> LoadMappings(ObservableCollection<InputButton> inputButtonsA, ObservableCollection<InputButton> inputButtonsB, ObservableCollection<OutputChannel> outputAxes, ObservableCollection<OutputChannel> outputButtons)
        {
            List<MappingDTO> mappings = new();
            if (File.Exists(SaveFilePath))
            {
                // Open the XML Document
                XmlDocument settingsFile = new();
                settingsFile.Load(SaveFilePath);

                // Parse values from XML
                XmlNode config = settingsFile.SelectSingleNode(CONFIG);
                try
                {
                    // Loop through each group
                    foreach (XmlNode groupNode in config.SelectNodes(GROUP))
                    {
                        var groupName = groupNode.Attributes[NAME];
                        if (groupName != null)
                        {
                            Debug.WriteLine("Reading Group: " + groupName.Value);
                        }

                        // Loop through each mapping
                        foreach (XmlNode mappingNode in groupNode.SelectNodes(MAPPING))
                        {
                            // Parse values from XML
                            string name = mappingNode.SelectSingleNode(NAME).InnerText;
                            int typeId = int.Parse(mappingNode.SelectSingleNode(TYPE_ID).InnerText);
                            bool active = bool.Parse(mappingNode.SelectSingleNode(ACTIVE).InnerText);
                            int inputButtonAHash = int.Parse(mappingNode.SelectSingleNode(INPUT_BUTTON_A_HASH).InnerText);
                            int inputButtonBHash = int.Parse(mappingNode.SelectSingleNode(INPUT_BUTTON_B_HASH).InnerText);
                            int outputChannelHash = int.Parse(mappingNode.SelectSingleNode(OUTPUT_CHANNEL_HASH).InnerText);
                            int axisSensitivity = int.Parse(mappingNode.SelectSingleNode(AXIS_SENSITIVITY).InnerText);
                            int encoderPPR = int.Parse(mappingNode.SelectSingleNode(ENCODER_PPR).InnerText);
                            float revsInPerRevsOut = float.Parse(mappingNode.SelectSingleNode(REVS_IN_PER_REVS_OUT).InnerText);
                            int buttonMultiplier = int.Parse(mappingNode.SelectSingleNode(BUTTON_MULTIPLIER).InnerText);
                            string resetCommand = mappingNode.SelectSingleNode(RESET_COMMAND).InnerText;

                            // Create Mapping from values and add to mappings list
                            mappings.Add(new MappingDTO
                            {
                                Name = name,
                                TypeId = typeId,
                                Active = active,
                                InputButtonA = GetInputButton(inputButtonAHash, inputButtonsA),
                                InputButtonB = GetInputButton(inputButtonBHash, inputButtonsB),
                                OutputChannel = GetOutputChannel(outputChannelHash, outputAxes, outputButtons),
                                AxisSensitivity = axisSensitivity,
                                EncoderPPR = encoderPPR,
                                RevsInPerRevsOut = revsInPerRevsOut,
                                ButtonMultiplier = buttonMultiplier,
                                ResetCommand = resetCommand
                            });
                        }
                    }
                }
                catch
                {
                    throw new Exception("Error finding or reading settings.xml");
                }
            }
            return mappings;
        }

        public void SaveMappings(IEnumerable<MappingDTO> mappings, string filePath)
        {
            SetSaveFilePath(filePath);
            SaveMappings(mappings);
        }
        public void SaveMappings(IEnumerable<MappingDTO> mappings)
        {
            XmlDocument doc = new();
            XmlElement configNode = doc.CreateElement(CONFIG);
            XmlElement groupNode = doc.CreateElement(GROUP);

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

                // inputButtonA
                XmlElement inputButtonANode = doc.CreateElement(INPUT_BUTTON_A_HASH);
                inputButtonANode.InnerText = String.Format("{0}", mapping.InputButtonA.Hash);
                mappingNode.AppendChild(inputButtonANode);

                // inputButtonB
                XmlElement inputButtonBNode = doc.CreateElement(INPUT_BUTTON_B_HASH);
                inputButtonBNode.InnerText = String.Format("{0}", mapping.InputButtonB.Hash);
                mappingNode.AppendChild(inputButtonBNode);

                // OutputChannel
                XmlElement outputChannelNode = doc.CreateElement(OUTPUT_CHANNEL_HASH);
                outputChannelNode.InnerText = String.Format("{0}", mapping.OutputChannel.Hash);
                mappingNode.AppendChild(outputChannelNode);

                // AxisSensitivity
                XmlElement axisSensitivityNode = doc.CreateElement(AXIS_SENSITIVITY);
                axisSensitivityNode.InnerText = String.Format("{0}", mapping.AxisSensitivity);
                mappingNode.AppendChild(axisSensitivityNode);

                // encoderPPRNode
                XmlElement encoderPPRNode = doc.CreateElement(ENCODER_PPR);
                encoderPPRNode.InnerText = String.Format("{0}", mapping.EncoderPPR);
                mappingNode.AppendChild(encoderPPRNode);

                // revsInPerRevsOut
                XmlElement revsInPerRevsOut = doc.CreateElement(REVS_IN_PER_REVS_OUT);
                revsInPerRevsOut.InnerText = String.Format("{0}", mapping.RevsInPerRevsOut);
                mappingNode.AppendChild(revsInPerRevsOut);

                // ButtonMultiplier
                XmlElement buttoMultiplierNode = doc.CreateElement(BUTTON_MULTIPLIER);
                buttoMultiplierNode.InnerText = String.Format("{0}", mapping.ButtonMultiplier);
                mappingNode.AppendChild(buttoMultiplierNode);

                // ResetCommand
                XmlElement resetCommandNode = doc.CreateElement(RESET_COMMAND);
                resetCommandNode.InnerText = mapping.ResetCommand;
                mappingNode.AppendChild(resetCommandNode);

                // Add to group
                groupNode.AppendChild(mappingNode);
            }

            configNode.AppendChild(groupNode);
            doc.AppendChild(configNode);
            doc.Save(SaveFilePath);
        }
        private static InputButton GetInputButton(int hash, ObservableCollection<InputButton> inputButtons)
        {
            foreach (var channel in inputButtons)
            {
                if (channel.Hash == hash)
                {
                    return channel;
                }
            }
            return new InputButton();
        }
        private static OutputChannel GetOutputChannel(int hash, ObservableCollection<OutputChannel> outputAxes, ObservableCollection<OutputChannel> outputButtons)
        {
            foreach (var channel in outputAxes)
            {
                if (channel.Hash == hash)
                {
                    return channel;
                }
            }
            foreach (var channel in outputButtons)
            {
                if (channel.Hash == hash)
                {
                    return channel;
                }
            }
            return new OutputChannel();
        }

        /// Returns an AuthentiKit or BU0836 input channel for the specified button, if available
        private InputButton getAuthentiKitInputButton(ObservableCollection<InputButton> inputButtons, int button)
        {
            foreach (var channel in inputButtons)
                if ((channel.Button == button) && (channel.Device.Contains("AuthentiKit")))
                    return channel;

            foreach (var channel in inputButtons)
                if ((channel.Button == button) && (channel.Device.Contains("BU0836")))
                    return channel;

            return new InputButton();
        }

        /// Returns the specified vJoy output if available
        private OutputChannel getOutputChannel(ObservableCollection<OutputChannel> channels, uint vJoyItem)
        {
            foreach (var channel in channels)
                if (channel.VJoyItem == vJoyItem)
                    return channel;
            return new OutputAxis();
        }
        public IEnumerable<MappingDTO> GetDefaultMappings(Preset preset, ObservableCollection<InputButton> inputButtonsA, ObservableCollection<InputButton> inputButtonsB, ObservableCollection<OutputChannel> outputAxes, ObservableCollection<OutputChannel> outputButtons)
        {
            
            ObservableCollection<MappingDTO> mappings = new();
            if (preset == Preset.SPITFIRE_MKIX)
            {
                // Elevator Trim Axis
                mappings.Add(new MappingDTO
                {
                    Name = "Elevator Trim",
                    TypeId = MappingType.BUTTON_TO_AXIS,
                    InputButtonA = getAuthentiKitInputButton(inputButtonsA, 10),
                    InputButtonB = getAuthentiKitInputButton(inputButtonsB, 11),
                    OutputChannel = getOutputChannel(outputAxes, (uint)AxisId.X),
                    AxisSensitivity = 90,
                });

                // Rudder Trim Button Left
                mappings.Add(new MappingDTO
                {
                    Name = "Rudder Trim Left",
                    TypeId = MappingType.BUTTON_TO_BUTTON,
                    InputButtonA = getAuthentiKitInputButton(inputButtonsA, 9),
                    OutputChannel = getOutputChannel(outputButtons, 1),
                    ButtonMultiplier = 5,
                    HoldThresholdStart = 150,
                    HoldThresholdStop = 150,
                });

                // Rudder Trim Button Right
                mappings.Add(new MappingDTO
                {
                    Name = "Rudder Trim Right",
                    TypeId = MappingType.BUTTON_TO_BUTTON,
                    InputButtonA = getAuthentiKitInputButton(inputButtonsA, 8),
                    OutputChannel = getOutputChannel(outputButtons, 2),
                    ButtonMultiplier = 5,
                    HoldThresholdStart = 150,
                    HoldThresholdStop = 150,
                });

                // Flaps Up
                mappings.Add(new MappingDTO
                {
                    Name = "Flaps Up",
                    TypeId = MappingType.BUTTON_TO_BUTTON,
                    InputButtonA = getAuthentiKitInputButton(inputButtonsA, 6),
                    OutputChannel = getOutputChannel(outputButtons, 3),
                    ButtonMultiplier = 1,
                    HoldThresholdStart = 0,
                    HoldThresholdStop = 500,
                });

                // Flaps Down
                mappings.Add(new MappingDTO
                {
                    Name = "Flaps Down",
                    TypeId = MappingType.BUTTON_TO_BUTTON,
                    InputButtonA = getAuthentiKitInputButton(inputButtonsA, 7),
                    OutputChannel = getOutputChannel(outputButtons, 4),
                    ButtonMultiplier = 1,
                    HoldThresholdStart = 0,
                    HoldThresholdStop = 500,
                });

                /* // Experimental Encoder based Elevator Trim
                 mappings.Add(new MappingDTO
                 {
                     Name = "EXPERIMENTAL: Elevator Trim (Axis)",
                     TypeId = MappingType.ENCODER_AXIS,
                     InputButtonA = getAuthentiKitInputButton(inputButtonsA, 10),
                     InputButtonB = getAuthentiKitInputButton(inputButtonsB, 11),
                     OutputChannel = getOutputChannel(outputAxes, (uint)AxisId.X),
                     EncoderPPR = 24,
                     RevsInPerRevsOut = 4
                 });*/
            }
            else if (preset == Preset.HONEYCOMB_BRAVO)
            {
                mappings.Add(new MappingDTO
                {
                    Name = "Elevator Axis",
                    TypeId = MappingType.BUTTON_TO_AXIS,
                    InputButtonA = GetInputButton(-102191463, inputButtonsA),
                    InputButtonB = GetInputButton(-102191464, inputButtonsB),
                    OutputChannel = getOutputChannel(outputAxes, (uint)AxisId.X),
                    AxisSensitivity = 360,
                });
            }
            return mappings;
        }

        public string GetSaveFilePath()
        {
            return SaveFilePath;
        }

        public void SetSaveFilePath(string filePath)
        {
            SaveFilePath = filePath;
            RegistryKey key = Registry.CurrentUser.CreateSubKey(REGISTRY_APP_SETTINGS);
            key.SetValue(REGISTRY_SAVE_FILE_PATH, SaveFilePath);
            key.Close();
        }
        private string LoadFilePathFromRegistry()
        {
            SaveFilePath = "";
            RegistryKey key = Registry.CurrentUser.OpenSubKey(REGISTRY_APP_SETTINGS);

            //if it does exist, retrieve the stored values  
            string filePath = "";
            if (key != null)
            {
                if (key.GetValue(REGISTRY_SAVE_FILE_PATH) != null)
                {
                    filePath = key.GetValue(REGISTRY_SAVE_FILE_PATH).ToString();
                }
                key.Close();
            }
            if (File.Exists(filePath))
            {
                SaveFilePath = filePath;
            }
            return SaveFilePath;
        }

        public void SetRunOnStartup(bool runOnStartup)
        {
            RegistryKey startUpKey = Registry.CurrentUser.OpenSubKey(REGISTRY_STARTUP_SETTINGS, true);
            bool valueSet = !(startUpKey.GetValue(REGISTRY_STARTUP_APP_NAME) == null);
            if (runOnStartup && !valueSet)
            {
                string path = Process.GetCurrentProcess().MainModule.FileName;
                startUpKey.SetValue(REGISTRY_STARTUP_APP_NAME, path);
            }
            else if (!runOnStartup && valueSet)
            {
                startUpKey.DeleteValue(REGISTRY_STARTUP_APP_NAME, false);
            }
        }
    }
}
