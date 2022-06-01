using MappingManager.Common.Model;
using SharpDX.DirectInput;
using vJoyInterfaceWrap;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Collections.Generic;

namespace AuthentiKitTrimCalibration.DataAccess
{

    public static class HardwareInfo
    {
        public static ObservableCollection<InputButton> GetInputButtons()
        {
            ObservableCollection<InputButton> inputButtons = new();
            var directInput = new DirectInput();
            foreach (var d in directInput.GetDevices())
            {
                if ((d.Subtype != 256) && (d.Type != DeviceType.Keyboard) && (d.Type != DeviceType.Mouse) && (!d.InstanceName.Contains("vJoy")))
                {
                    var joystick = new Joystick(directInput, d.InstanceGuid);
                    var buttons = joystick.Capabilities.ButtonCount;
                    for (int i = 0; i < buttons; i++)
                    {
                        inputButtons.Add(item: new InputButton { Guid = d.ProductGuid, Device = d.InstanceName, Button = i, Name = string.Format(d.InstanceName + ": Button " + (i + 1)) });
                    }
                }
            }
            return inputButtons;
        }


        public static ObservableCollection<InputAxis> GetInputAxes()
        {
            ObservableCollection<InputAxis> inputAxes = new();
            var directInput = new DirectInput();
            foreach (var device in directInput.GetDevices())
            {
                if ((device.Subtype != 256) && (device.Type != DeviceType.Keyboard) && (device.Type != DeviceType.Mouse) && (!device.InstanceName.Contains("vJoy")))
                {
                    var joystick = new Joystick(directInput, device.InstanceGuid);
                    try
                    {
                        foreach (var instance in joystick.GetObjects())
                        {
                            var objectProperties = joystick.GetObjectPropertiesById(instance.ObjectId);
                            var objectInfo = joystick.GetObjectInfoById(instance.ObjectId);
                            int axisId = getAxisIdFromName(instance.Name);
                            int instanceOffset = getInstanceOffsetFromName(instance.Name);
                            var a = instance.ObjectType;
                            if (instance.ObjectId.Flags == DeviceObjectTypeFlags.AbsoluteAxis)
                            {
                                inputAxes.Add(item: new InputAxis
                                {
                                    Guid = device.ProductGuid,
                                    Device = device.InstanceName,
                                    AxisId = axisId,
                                    InstanceOffset = instanceOffset,
                                    Min = objectProperties.Range.Minimum,
                                    Max = objectProperties.Range.Maximum,
                                    Name = string.Format(device.InstanceName + " : " + instance.Name)
                                }) ;
                            }
                        }
                    }
                    catch { }
                }
            }

            // Debug print any calibrations found
            foreach (var axis in inputAxes) 
            {
                CalibrationDTO calibration = DataHandler.GetCalibrationFromRegistry(axis);
                if(calibration != null)
                    if (calibration.IsSet)
                        Debug.WriteLine("{0}/t Calibration: {1}", axis, calibration);
            }
            return inputAxes;
        }

        private static int getAxisIdFromName(String name)
        {
            int offset = 0;
            switch (name)
            {
                case "X Axis":
                    offset = 0;
                    break;
                case "Y Axis":
                    offset = 4;
                    break;
                case "Z Axis":
                    offset = 8;
                    break;
                case "X Rotation":
                    offset = 12;
                    break;
                case "Y Rotation":
                    offset = 0x10;
                    break;
                case "Z Rotation":
                    offset = 20;
                    break;
                case "Dial":
                    offset = 24;
                    break;
                case "Slider":
                    offset = 28;
                    break;
            }
            return offset;
        }

        private static int getInstanceOffsetFromName(String name)
        {
            int offset = 0;
            switch (name)
            {
                case "X Axis":
                    offset = 0;
                    break;
                case "Y Axis":
                    offset = 1;
                    break;
                case "Z Axis":
                    offset = 2;
                    break;
                case "X Rotation":
                    offset = 3;
                    break;
                case "Y Rotation":
                    offset = 4;
                    break;
                case "Z Rotation":
                    offset = 5;
                    break;
                case "Dial":
                    offset = 6;
                    break;
                case "Slider":
                    offset = 7;
                    break;
            }
            return offset;
        }

        public static ObservableCollection<OutputChannel> GetOutputAxes()
        {
            ObservableCollection<OutputChannel> outputChannels = new();
            vJoy joystick = new();
            int output_id = 0;
            for (uint vjoy_id = 1; vjoy_id <= 16; vjoy_id++)
            {
                // Axes
                VjdStat status = joystick.GetVJDStatus(vjoy_id);
                if (status == VjdStat.VJD_STAT_FREE)
                {
                    foreach (HID_USAGES axis in Enum.GetValues(typeof(HID_USAGES)))
                    {
                        if (joystick.GetVJDAxisExist(vjoy_id, axis))
                        {
                            outputChannels.Add(new OutputAxis
                            {
                                VJoyId = output_id++,
                                VJoyDevice = vjoy_id,
                                VJoyItem = (uint)axis
                            });
                        }
                    }
                }
            }
            return outputChannels;
        }

        public static ObservableCollection<OutputChannel> GetOutputButtons()
        {
            ObservableCollection<OutputChannel> outputChannels = new();
            vJoy joystick = new();
            int output_id = 0;
            for (uint vjoy_id = 1; vjoy_id <= 16; vjoy_id++)
            {
                // Buttons
                for (uint b = 1; b <= joystick.GetVJDButtonNumber(vjoy_id); b++)
                {
                    outputChannels.Add(new OutputButton
                    {
                        VJoyId = output_id++,
                        VJoyDevice = vjoy_id,
                        VJoyItem = b,
                    });
                }
            }
            return outputChannels;
        }
    }
}
