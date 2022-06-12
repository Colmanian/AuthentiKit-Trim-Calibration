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
        private readonly string INPUT_AXIS = "INPUT_AXIS";
        private readonly string OUTPUT_CHANNEL_A_HASH = "OUTPUT_CHANNEL_HASH"; //(should be OUTPUT_CHANNEL_A_HASH  but can't rename due to it already being in users' XML save file)
        private readonly string OUTPUT_CHANNEL_B_HASH = "OUTPUT_CHANNEL_B_HASH";
        private readonly string AXIS_SENSITIVITY = "AXIS_SENSITIVITY";
        private readonly string ENCODER_PPR = "ENCODER_PPR";
        private readonly string REVS_IN_PER_REVS_OUT = "REVS_IN_PER_REVS_OUT";
        private readonly string BUTTON_MULTIPLIER = "BUTTON_MULTIPLIER";
        private readonly string RESET_COMMAND = "RESET_COMMAND";
        private readonly string FLIPPED = "FLIPPED";
        private readonly string GATEWAY1 = "GATEWAY1";
        private readonly string GATEWAY2 = "GATEWAY2";
        private readonly string GATEWAY3 = "GATEWAY3";
        private readonly string GATEWAY4 = "GATEWAY4";
        private readonly string GATEWAY5 = "GATEWAY5";
        private readonly string GATEWAY_ENABLED_1 = "GATEWAY_ENABLED_1";
        private readonly string GATEWAY_ENABLED_2 = "GATEWAY_ENABLED_2";
        private readonly string GATEWAY_ENABLED_3 = "GATEWAY_ENABLED_3";
        private readonly string GATEWAY_ENABLED_4 = "GATEWAY_ENABLED_4";
        private readonly string GATEWAY_ENABLED_5 = "GATEWAY_ENABLED_5";
        private readonly string CALIBRATION_MIN = "CALIBRATION_MIN";
        private readonly string CALIBRATION_CEN = "CALIBRATION_CEN";
        private readonly string CALIBRATION_MAX = "CALIBRATION_MAX";
        private readonly string REGISTRY_APP_SETTINGS = "SOFTWARE\\AuthentiKit"; //Under HKEY_CURRENT_USER
        private readonly string REGISTRY_SAVE_FILE_PATH = "SaveFileName";
        private readonly string REGISTRY_PERSIST_CALIBRATION_PATH = "PersistCalibration";
        private readonly string REGISTRY_START_ALL_ON_OPEN = "StartAllOnOpen";
        private readonly string REGISTRY_STARTUP_SETTINGS = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run"; //Under HKEY_CURRENT_USER
        private readonly string REGISTRY_STARTUP_APP_NAME = "AuthentiKit";
        private static readonly string REGISTRY_CALIBRATION_SETTINGS = "System\\CurrentControlSet\\Control\\MediaProperties\\PrivateProperties\\DirectInput\\"; //Under HKEY_CURRENT_USER

        private string SaveFilePath;
        private bool _persistCalibration;
        private bool _startAllOnOpen;

        public DataHandler()
        {
            // Get Save filepath from registry if there
            SaveFilePath = LoadFilePathFromRegistry();
            _persistCalibration = GetPersistCalibration();
            _startAllOnOpen = GetStartAllOnOpen();
        }

        public MappingDTO GetBlankMapping()
        {
            return new MappingDTO { Name = "New Mapping" };
        }

        public IEnumerable<MappingDTO> LoadMappings(ObservableCollection<InputButton> inputButtonsA,
            ObservableCollection<InputButton> inputButtonsB,
            ObservableCollection<InputAxis> inputAxes,
            ObservableCollection<OutputChannel> outputAxes,
            ObservableCollection<OutputChannel> outputButtonsA,
            ObservableCollection<OutputChannel> outputButtonsB)
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
                            int inputAxisHash = new InputAxis().Hash; // See below
                            int outputChannelAHash = int.Parse(mappingNode.SelectSingleNode(OUTPUT_CHANNEL_A_HASH).InnerText);
                            int outputChannelBHash = 0; // See below
                            int axisSensitivity = int.Parse(mappingNode.SelectSingleNode(AXIS_SENSITIVITY).InnerText);
                            int encoderPPR = int.Parse(mappingNode.SelectSingleNode(ENCODER_PPR).InnerText);
                            float revsInPerRevsOut = float.Parse(mappingNode.SelectSingleNode(REVS_IN_PER_REVS_OUT).InnerText);
                            int buttonMultiplier = int.Parse(mappingNode.SelectSingleNode(BUTTON_MULTIPLIER).InnerText);
                            string resetCommand = mappingNode.SelectSingleNode(RESET_COMMAND).InnerText;
                            bool flipped = false; // See below
                            int gateway1 = 0;
                            int gateway2 = 0;
                            int gateway3 = 0;
                            int gateway4 = 0;
                            int gateway5 = 0;
                            bool gatewayEnabled1 = false;
                            bool gatewayEnabled2 = false;
                            bool gatewayEnabled3 = false;
                            bool gatewayEnabled4 = false;
                            bool gatewayEnabled5 = false;
                            CalibrationDTO Calibration = new();

                            // Backwards compatability with earlier save files than 1.2
                            if (mappingNode.SelectSingleNode(INPUT_AXIS) != null)
                                inputAxisHash = int.Parse(mappingNode.SelectSingleNode(INPUT_AXIS).InnerText);
                            if (mappingNode.SelectSingleNode(FLIPPED) != null)
                                flipped = bool.Parse(mappingNode.SelectSingleNode(FLIPPED).InnerText);
                            if (mappingNode.SelectSingleNode(GATEWAY1) != null)
                                gateway1 = int.Parse(mappingNode.SelectSingleNode(GATEWAY1).InnerText);
                            if (mappingNode.SelectSingleNode(GATEWAY2) != null)
                                gateway2 = int.Parse(mappingNode.SelectSingleNode(GATEWAY2).InnerText);
                            if (mappingNode.SelectSingleNode(GATEWAY3) != null)
                                gateway3 = int.Parse(mappingNode.SelectSingleNode(GATEWAY3).InnerText);
                            if (mappingNode.SelectSingleNode(GATEWAY4) != null)
                                gateway4 = int.Parse(mappingNode.SelectSingleNode(GATEWAY4).InnerText);
                            if (mappingNode.SelectSingleNode(GATEWAY5) != null)
                                gateway5 = int.Parse(mappingNode.SelectSingleNode(GATEWAY5).InnerText);
                            if (mappingNode.SelectSingleNode(GATEWAY_ENABLED_1) != null)
                                gatewayEnabled1 = bool.Parse(mappingNode.SelectSingleNode(GATEWAY_ENABLED_1).InnerText);
                            if (mappingNode.SelectSingleNode(GATEWAY_ENABLED_2) != null)
                                gatewayEnabled2 = bool.Parse(mappingNode.SelectSingleNode(GATEWAY_ENABLED_2).InnerText);
                            if (mappingNode.SelectSingleNode(GATEWAY_ENABLED_3) != null)
                                gatewayEnabled3 = bool.Parse(mappingNode.SelectSingleNode(GATEWAY_ENABLED_3).InnerText);
                            if (mappingNode.SelectSingleNode(GATEWAY_ENABLED_4) != null)
                                gatewayEnabled4 = bool.Parse(mappingNode.SelectSingleNode(GATEWAY_ENABLED_4).InnerText);
                            if (mappingNode.SelectSingleNode(GATEWAY_ENABLED_5) != null)
                                gatewayEnabled5 = bool.Parse(mappingNode.SelectSingleNode(GATEWAY_ENABLED_5).InnerText);
                            if (mappingNode.SelectSingleNode(OUTPUT_CHANNEL_B_HASH) != null)
                                outputChannelBHash = int.Parse(mappingNode.SelectSingleNode(OUTPUT_CHANNEL_B_HASH).InnerText);
                            if (mappingNode.SelectSingleNode(CALIBRATION_MIN) != null)
                                Calibration.Min = int.Parse(mappingNode.SelectSingleNode(CALIBRATION_MIN).InnerText);
                            if (mappingNode.SelectSingleNode(CALIBRATION_CEN) != null)
                                Calibration.Cen = int.Parse(mappingNode.SelectSingleNode(CALIBRATION_CEN).InnerText);
                            if (mappingNode.SelectSingleNode(CALIBRATION_MAX) != null)
                                Calibration.Max = int.Parse(mappingNode.SelectSingleNode(CALIBRATION_MAX).InnerText);

                            // Create Mapping from values and add to mappings list
                            mappings.Add(new MappingDTO
                            {
                                Name = name,
                                TypeId = typeId,
                                Active = active,
                                InputButtonA = GetInputButton(inputButtonAHash, inputButtonsA),
                                InputButtonB = GetInputButton(inputButtonBHash, inputButtonsB),
                                InputAxis = GetInputAxis(inputAxisHash, inputAxes),
                                OutputChannelA = GetOutputChannel(outputChannelAHash, outputAxes, outputButtonsA),
                                OutputChannelB = GetOutputChannel(outputChannelBHash, outputAxes, outputButtonsB),
                                AxisSensitivity = axisSensitivity,
                                EncoderPPR = encoderPPR,
                                RevsInPerRevsOut = revsInPerRevsOut,
                                ButtonMultiplier = buttonMultiplier,
                                ResetCommand = resetCommand,
                                Flipped = flipped,
                                Gateway1 = gateway1,
                                Gateway2 = gateway2,
                                Gateway3 = gateway3,
                                Gateway4 = gateway4,
                                Gateway5 = gateway5,
                                GatewayEnabled1 = gatewayEnabled1,
                                GatewayEnabled2 = gatewayEnabled2,
                                GatewayEnabled3 = gatewayEnabled3,
                                GatewayEnabled4 = gatewayEnabled4,
                                GatewayEnabled5 = gatewayEnabled5,
                                Calibration = Calibration
                            });

                            // If we're to load in the calibration settings then do so
                            if (_persistCalibration)
                            {
                                if (Calibration.IsSet)
                                {
                                    WriteCalibrationToRegistry(GetInputAxis(inputAxisHash, inputAxes), Calibration);
                                }
                            }
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

        public static void WriteCalibrationToRegistry(InputAxis inputAxis, CalibrationDTO calibration)
        {
            int min = calibration.Min;
            int cen = calibration.Cen;
            int max = calibration.Max;
            Byte[] calibrationBytes = {
                (byte)(min % 256),
                (byte)(min / 256),
                (byte)0,
                (byte)0,
                (byte)(cen % 256),
                (byte)(cen / 256),
                (byte)0,
                (byte)0,
                (byte)(max % 256),
                (byte)(max / 256),
                (byte)0,
                (byte)0,
            };
            string registryPath = GetRegistryPath(inputAxis);
            RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath, true);
            key.SetValue("Calibration", calibrationBytes);
        }

        public static CalibrationDTO ReadCalibrationFromRegistry(InputAxis inputAxis)
        {
            string registryPath = GetRegistryPath(inputAxis);

            RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath);

            //if it does exist, retrieve the stored calibration   
            Byte[] calibrationBytes = { };
            if (key != null)
            {
                if (key.GetValue("Calibration", "EMPTY") != null)
                {
                    calibrationBytes = key.GetValue("Calibration", "EMPTY") as Byte[];
                }
                key.Close();
            }

            int min = 0;
            int cen = 0;
            int max = 0;
            if (calibrationBytes != null)
            {
                if (calibrationBytes.Length == 12)
                {
                    min = 256 * calibrationBytes[1] + calibrationBytes[0];
                    cen = 256 * calibrationBytes[5] + calibrationBytes[4];
                    max = 256 * calibrationBytes[9] + calibrationBytes[8];
                }
            }
            return new CalibrationDTO(min, cen, max);
        }

        // Ref: https://stackoverflow.com/a/51824114
        public static string GetRegistryPath(InputAxis inputAxis)
        {
            string registryName = string.Empty;
            string guid = inputAxis.Guid.ToString().ToUpper();
            registryName = string.Concat("VID_", guid.AsSpan(4, 4), "&PID_", guid.AsSpan(0, 4));

            string registryPath = REGISTRY_CALIBRATION_SETTINGS
                + registryName
                + "\\Calibration\\0\\Type\\Axes\\"
                + inputAxis.InstanceOffset;

            return registryPath;
        }

        public void SaveMappings(IEnumerable<MappingDTO> mappings, string filePath, ObservableCollection<InputAxis> inputAxes)
        {
            SetSaveFilePath(filePath);
            SaveMappings(mappings, inputAxes);
        }
        public void SaveMappings(IEnumerable<MappingDTO> mappings, ObservableCollection<InputAxis> inputAxes)
        {
            XmlDocument doc = new();
            XmlElement configNode = doc.CreateElement(CONFIG);
            XmlElement groupNode = doc.CreateElement(GROUP);

            foreach (var mapping in mappings)
            {
                // If we're to persist calibration info then get it from the registry
                if (_persistCalibration)
                {
                    CalibrationDTO calibration = ReadCalibrationFromRegistry(GetInputAxis(mapping.InputAxis.Hash, inputAxes));
                    mapping.Calibration = calibration;
                }

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

                // inputAxis
                XmlElement inputAxisNode = doc.CreateElement(INPUT_AXIS);
                inputAxisNode.InnerText = String.Format("{0}", mapping.InputAxis.Hash);
                mappingNode.AppendChild(inputAxisNode);

                // OutputChannelA
                XmlElement outputChannelANode = doc.CreateElement(OUTPUT_CHANNEL_A_HASH);
                outputChannelANode.InnerText = String.Format("{0}", mapping.OutputChannelA.Hash);
                mappingNode.AppendChild(outputChannelANode);

                // OutputChannelB
                XmlElement outputChannelBNode = doc.CreateElement(OUTPUT_CHANNEL_B_HASH);
                outputChannelBNode.InnerText = String.Format("{0}", mapping.OutputChannelB.Hash);
                mappingNode.AppendChild(outputChannelBNode);

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

                // Flipped
                XmlElement flippedNode = doc.CreateElement(FLIPPED);
                flippedNode.InnerText = String.Format("{0}", mapping.Flipped);
                mappingNode.AppendChild(flippedNode);

                // Gateway1
                XmlElement gateway1 = doc.CreateElement(GATEWAY1);
                gateway1.InnerText = String.Format("{0}", mapping.Gateway1);
                mappingNode.AppendChild(gateway1);

                // Gateway2
                XmlElement gateway2 = doc.CreateElement(GATEWAY2);
                gateway2.InnerText = String.Format("{0}", mapping.Gateway2);
                mappingNode.AppendChild(gateway2);

                // Gateway3
                XmlElement gateway3 = doc.CreateElement(GATEWAY3);
                gateway3.InnerText = String.Format("{0}", mapping.Gateway3);
                mappingNode.AppendChild(gateway3);

                // Gateway4
                XmlElement gateway4 = doc.CreateElement(GATEWAY4);
                gateway4.InnerText = String.Format("{0}", mapping.Gateway4);
                mappingNode.AppendChild(gateway4);

                // Gateway5
                XmlElement gateway5 = doc.CreateElement(GATEWAY5);
                gateway5.InnerText = String.Format("{0}", mapping.Gateway5);
                mappingNode.AppendChild(gateway5);

                // GatewayEnabled1
                XmlElement gatewayEnabled1 = doc.CreateElement(GATEWAY_ENABLED_1);
                gatewayEnabled1.InnerText = String.Format("{0}", mapping.GatewayEnabled1);
                mappingNode.AppendChild(gatewayEnabled1);

                // GatewayEnabled2
                XmlElement gatewayEnabled2 = doc.CreateElement(GATEWAY_ENABLED_2);
                gatewayEnabled2.InnerText = String.Format("{0}", mapping.GatewayEnabled2);
                mappingNode.AppendChild(gatewayEnabled2);

                // Gateway3
                XmlElement gatewayEnabled3 = doc.CreateElement(GATEWAY_ENABLED_3);
                gatewayEnabled3.InnerText = String.Format("{0}", mapping.GatewayEnabled3);
                mappingNode.AppendChild(gatewayEnabled3);

                // Gateway4
                XmlElement gatewayEnabled4 = doc.CreateElement(GATEWAY_ENABLED_4);
                gatewayEnabled4.InnerText = String.Format("{0}", mapping.GatewayEnabled4);
                mappingNode.AppendChild(gatewayEnabled4);

                // Gateway5
                XmlElement gatewayEnabled5 = doc.CreateElement(GATEWAY_ENABLED_5);
                gatewayEnabled5.InnerText = String.Format("{0}", mapping.GatewayEnabled5);
                mappingNode.AppendChild(gatewayEnabled5);

                // CalibrationMin
                XmlElement calibrationMin = doc.CreateElement(CALIBRATION_MIN);
                calibrationMin.InnerText = String.Format("{0}", mapping.Calibration.Min);
                mappingNode.AppendChild(calibrationMin);

                // CalibrationCen
                XmlElement calibrationCen = doc.CreateElement(CALIBRATION_CEN);
                calibrationCen.InnerText = String.Format("{0}", mapping.Calibration.Cen);
                mappingNode.AppendChild(calibrationCen);

                // CalibrationMax
                XmlElement calibrationMax = doc.CreateElement(CALIBRATION_MAX);
                calibrationMax.InnerText = String.Format("{0}", mapping.Calibration.Max);
                mappingNode.AppendChild(calibrationMax);

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
        private static InputAxis GetInputAxis(int hash, ObservableCollection<InputAxis> inputAxes)
        {
            foreach (var channel in inputAxes)
            {
                if (channel.Hash == hash)
                {
                    return channel;
                }
            }
            return new InputAxis();
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
        public IEnumerable<MappingDTO> GetDefaultMappings(Preset preset,
            ObservableCollection<InputButton> inputButtonsA,
            ObservableCollection<InputButton> inputButtonsB,
            ObservableCollection<OutputChannel> outputAxes,
            ObservableCollection<OutputChannel> outputButtonsA,
            ObservableCollection<OutputChannel> outputButtonsB)
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
                    OutputChannelA = getOutputChannel(outputAxes, (uint)AxisId.X),
                    AxisSensitivity = 90,
                });

                // Rudder Trim Button Left
                mappings.Add(new MappingDTO
                {
                    Name = "Rudder Trim Left",
                    TypeId = MappingType.BUTTON_TO_BUTTON,
                    InputButtonA = getAuthentiKitInputButton(inputButtonsA, 9),
                    OutputChannelA = getOutputChannel(outputButtonsA, 1),
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
                    OutputChannelA = getOutputChannel(outputButtonsA, 2),
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
                    OutputChannelA = getOutputChannel(outputButtonsA, 3),
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
                    OutputChannelA = getOutputChannel(outputButtonsA, 4),
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
                    OutputChannelA = getOutputChannel(outputAxes, (uint)AxisId.X),
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
        public void SetPersistCalibration(bool persist)
        {
            _persistCalibration = persist;
            RegistryKey key = Registry.CurrentUser.CreateSubKey(REGISTRY_APP_SETTINGS);
            key.SetValue(REGISTRY_PERSIST_CALIBRATION_PATH, persist);
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
        public bool GetPersistCalibration()
        {
            _persistCalibration = false;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(REGISTRY_APP_SETTINGS);

            //if it does exist, retrieve the stored value  
            string persistString = "";
            if (key != null)
            {
                if (key.GetValue(REGISTRY_PERSIST_CALIBRATION_PATH) != null)
                {
                    persistString = key.GetValue(REGISTRY_PERSIST_CALIBRATION_PATH).ToString();
                }
                key.Close();
            }
            try
            {
                _persistCalibration = bool.Parse(persistString);
            }
            catch { }
            return _persistCalibration;
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
        public bool GetRunOnStartup()
        {
            bool runOnStartup = false;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(REGISTRY_APP_SETTINGS);

            //if it does exist, retrieve the stored value  
            string runOnStartupString = "";
            if (key != null)
            {
                if (key.GetValue(REGISTRY_STARTUP_SETTINGS) != null)
                {
                    runOnStartupString = key.GetValue(REGISTRY_STARTUP_SETTINGS).ToString();
                }
                key.Close();
            }
            try
            {
                _persistCalibration = bool.Parse(runOnStartupString);
            }
            catch { }
            return runOnStartup;
        }

            public void SetStartAllOnOpen(bool startAllOnOpen)
        {
            _startAllOnOpen = startAllOnOpen;
            RegistryKey key = Registry.CurrentUser.CreateSubKey(REGISTRY_APP_SETTINGS);
            key.SetValue(REGISTRY_START_ALL_ON_OPEN, startAllOnOpen);
            key.Close();
        }
        public bool GetStartAllOnOpen()
        {
            _startAllOnOpen = false;
            RegistryKey key = Registry.CurrentUser.OpenSubKey(REGISTRY_APP_SETTINGS);

            //if it does exist, retrieve the stored value  
            string startAllOnOpenString = "";
            if (key != null)
            {
                if (key.GetValue(REGISTRY_START_ALL_ON_OPEN) != null)
                {
                    startAllOnOpenString = key.GetValue(REGISTRY_START_ALL_ON_OPEN).ToString();
                }
                key.Close();
            }
            try
            {
                _startAllOnOpen = bool.Parse(startAllOnOpenString);
            }
            catch { }
            return _startAllOnOpen;
        }

    }
}
