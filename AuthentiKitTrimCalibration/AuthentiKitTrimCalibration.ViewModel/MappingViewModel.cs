using AuthentiKitTrimCalibration.DataAccess;
using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System;
using System.Collections.Generic;

namespace AuthentiKitTrimCalibration.ViewModel
{
    public class MappingViewModel : ViewModelBase
    {
        private IMappingProcessor _mappingProcessor;
        private MappingDTO _mapping;
        private readonly IEnumerable<InputChannel> _inputs;
        private readonly IEnumerable<OutputChannel> _outputs;

        public MappingViewModel(MappingDTO mapping, IEnumerable<InputChannel> inputs, IEnumerable<OutputChannel> outputs)
        {
            _inputs = inputs;
            _outputs = outputs;
            _mappingProcessor = new MappingProcessor();
            _mapping = mapping;
            Deactivate();
        }

        private void UpdateStatus()
        {
            RaisePropertyChanged(nameof(Activated));
            RaisePropertyChanged(nameof(Deactivated));
            RaisePropertyChanged(nameof(Status));
            RaisePropertyChanged(nameof(StatusColour));
        }
        public void Activate()
        {
            _mappingProcessor.Activate(_mapping);
            UpdateStatus();
        }
        public void Deactivate()
        {
            _mappingProcessor.Deactivate();
            UpdateStatus();
        }
        public void CentreAxis()
        {
            _mappingProcessor.Centre();
            UpdateStatus();
        }

        public bool CanApply => !string.IsNullOrEmpty(Name);
        public bool IsAxisMapping => TypeId == MappingType.AXIS;
        public bool IsButtonMapping => TypeId == MappingType.BUTTON;

        public string Name
        {
            get { return _mapping.Name; }
            set
            {
                if (_mapping.Name != value)
                {
                    Deactivate();
                    _mapping.Name = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(CanApply));
                    UpdateStatus();
                }
            }
        }

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }

        public string Status
        {
            get
            {
                string status = "Deactivated";
                if (_mappingProcessor.IsErrored())
                {
                    status = "Error!";
                }
                else if (_mappingProcessor.IsRunning())
                {
                    status = "Activated";
                }
                return status;
            }
        }

        public string StatusColour
        {
            get
            {
                string status = "Gray"; // Deactivated
                if (_mappingProcessor.IsErrored())
                {
                    status = "Salmon"; // Error
                }
                else if (_mappingProcessor.IsRunning())
                {
                    status = "Green"; // Activated
                }
                return status;
            }
        }

        public int TypeId
        {
            get => _mapping.TypeId;
            set
            {
                if (_mapping.TypeId != value)
                {
                    _mapping.TypeId = value;
                    RaisePropertyChanged();
                }
            }
        }
        private InputChannel getInputChannelFromString(string value)
        {
            InputChannel returnValue = new();
            foreach (var channel in _inputs)
            {
                if (value == channel.ToString())
                {
                    returnValue = channel;
                    break;
                }
            }
            return returnValue;
        }
        private OutputChannel getOutputChannelFromString(string value)
        {
            OutputChannel returnValue = new();
            foreach (var channel in _outputs)
            {
                if (value == channel.ToString())
                {
                    returnValue = channel;
                    break;
                }
            }
            return returnValue;
        }

        public string InputA
        {
            get
            {
                if (_mapping.InputChannelA != null)
                    return _mapping.InputChannelA.ToString();
                else
                    return "";
            }
            set
            {
                if (_mapping.InputChannelA != null)
                {
                    if (_mapping.InputChannelA.ToString() != value)
                    {
                        Deactivate();
                        _mapping.InputChannelA = getInputChannelFromString(value);
                        RaisePropertyChanged();
                        UpdateStatus();
                    }
                }
            }
        }
        public string InputB
        {
            get
            {
                if (_mapping.InputChannelB != null)
                    return _mapping.InputChannelB.ToString();
                else
                    return "";
            }
            set
            {
                if (_mapping.InputChannelB != null)
                {
                    if (_mapping.InputChannelB.ToString() != value)
                    {
                        Deactivate();
                        _mapping.InputChannelB = getInputChannelFromString(value);
                        RaisePropertyChanged();
                        UpdateStatus();
                    }
                }
            }
        }
        public string Output
        {
            get
            {
                if (_mapping.OutputChannel != null)
                    return _mapping.OutputChannel.ToString();
                else
                    return "";
            }
            set
            {
                if (_mapping.OutputChannel != null)
                {
                    if (_mapping.OutputChannel.ToString() != value)
                    {
                        Deactivate();
                        _mapping.OutputChannel = getOutputChannelFromString(value);
                        RaisePropertyChanged();
                        UpdateStatus();
                    }
                }
            }
        }

        public int Multiplier
        {
            get { return _mapping.Multiplier; }
            set
            {
                if (_mapping.Multiplier != value)
                {
                    Deactivate();
                    _mapping.Multiplier = value;
                    RaisePropertyChanged();
                    UpdateStatus();
                }
            }
        }
        public int HoldThresholdStart
        {
            get { return _mapping.HoldThresholdStart; }
            set
            {
                if (_mapping.HoldThresholdStart != value)
                {
                    Deactivate();
                    _mapping.HoldThresholdStart = value;
                    RaisePropertyChanged();
                    UpdateStatus();
                }
            }
        }
        public int HoldThresholdStop
        {
            get { return _mapping.HoldThresholdStop; }
            set
            {
                if (_mapping.HoldThresholdStop != value)
                {
                    Deactivate();
                    _mapping.HoldThresholdStop = value;
                    RaisePropertyChanged();
                    UpdateStatus();
                }
            }
        }
        public string ResetCommand
        {
            get { return _mapping.ResetCommand; }
            set
            {
                if (_mapping.ResetCommand != value)
                {
                    Deactivate();
                    _mapping.ResetCommand = value;
                    RaisePropertyChanged();
                    UpdateStatus();
                }
            }
        }

        public bool Activated
        {
            get { return _mappingProcessor.IsRunning(); }
        }
        public bool Deactivated => !Activated;

    }
}
