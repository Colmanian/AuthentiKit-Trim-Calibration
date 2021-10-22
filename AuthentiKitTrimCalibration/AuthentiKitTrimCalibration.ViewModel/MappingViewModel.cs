using AuthentiKitTrimCalibration.DataAccess;
using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace AuthentiKitTrimCalibration.ViewModel
{
    public class MappingViewModel : ViewModelBase
    {
        private readonly IMappingProcessor _mappingProcessor;
        private readonly MappingDTO _mapping;
        private readonly ObservableCollection<InputChannel> InputChannelsA;
        private readonly ObservableCollection<InputChannel> InputChannelsB;
        private readonly ObservableCollection<OutputChannel> OutputChannels;

        public MappingViewModel(MappingDTO mapping, ObservableCollection<InputChannel> inputsA, ObservableCollection<InputChannel> inputsB, ObservableCollection<OutputChannel> outputs)
        {
            InputChannelsA = inputsA;
            InputChannelsB = inputsB;
            OutputChannels = outputs;
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

        public bool CanApply => !string.IsNullOrEmpty(Name) && Deactivated;
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

        internal MappingDTO getMappingDTO()
        {
            return _mapping;
        }

        public int TypeId
        {
            get => _mapping.TypeId;
            set
            {
                if (_mapping.TypeId != value)
                {
                    _mapping.TypeId = value;
                    Debug.WriteLine("RAISING PROPERTY CHANGED to {0}", _mapping.TypeId);
                    RaisePropertyChanged();
                }
            }
        }

        public int InputChannelAHash
        {
            get => _mapping.InputChannelA.Hash;
            set
            {
                if (_mapping.InputChannelA.Hash != value)
                {
                    _mapping.InputChannelA = GetInputChannelA(value);
                    RaisePropertyChanged();
                }
            }
        }

        public int InputChannelBHash
        {
            get => _mapping.InputChannelB.Hash;
            set
            {
                if (_mapping.InputChannelB.Hash != value)
                {
                    _mapping.InputChannelB = GetInputChannelB(value);
                    RaisePropertyChanged();
                }
            }
        }
        public int OutputChannelHash
        {
            get => _mapping.OutputChannel.Hash;
            set
            {
                if (_mapping.OutputChannel.Hash != value)
                {
                    _mapping.OutputChannel = GetOutputChannel(value);
                    RaisePropertyChanged();
                }
            }
        }
        private InputChannel GetInputChannelA(int hash)
        {
            foreach (var channel in InputChannelsA)
            {
                if (channel.Hash == hash)
                {
                    return channel;
                }
            }
            return new InputChannel();
        }
        private InputChannel GetInputChannelB(int hash)
        {
            foreach (var channel in InputChannelsB)
            {
                if (channel.Hash == hash)
                {
                    return channel;
                }
            }
            return new InputChannel();
        }

        private OutputChannel GetOutputChannel(int hash)
        {
            foreach (var channel in OutputChannels)
            {
                if (channel.Hash == hash)
                {
                    return channel;
                }
            }
            return new OutputChannel();
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
