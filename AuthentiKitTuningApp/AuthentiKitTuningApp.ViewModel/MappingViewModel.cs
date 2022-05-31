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
        private readonly IInputDetector _inputDetector;
        private readonly MappingDTO _mapping;
        private readonly ObservableCollection<InputButton> InputButtonsA;
        private readonly ObservableCollection<InputButton> InputButtonsB;
        private readonly ObservableCollection<InputAxis> InputAxes;
        private readonly ObservableCollection<OutputChannel> OutputAxes;
        private readonly ObservableCollection<OutputChannel> OutputButtons;

        public MappingViewModel(MappingDTO mapping, ObservableCollection<InputButton> inputButtonsA,
            ObservableCollection<InputButton> inputButtonsB,
            ObservableCollection<InputAxis> inputAxes,
            ObservableCollection<OutputChannel> outputAxes,
            ObservableCollection<OutputChannel> outputButtons)
        {
            InputButtonsA = inputButtonsA;
            InputButtonsB = inputButtonsB;
            InputAxes = inputAxes;
            OutputAxes = outputAxes;
            OutputButtons = outputButtons;
            _mappingProcessor = new MappingProcessor();
            _inputDetector = new InputDetector();
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
        public void DetectButtonInputA()
        {
            Deactivate();
            _mapping.InputButtonA = _inputDetector.DetectButton();
            RaisePropertyChanged();
            RaisePropertyChanged(nameof(InputButtonAHash));
            UpdateStatus();
        }
        public void DetectButtonInputB()
        {
            Deactivate();
            _mapping.InputButtonB = _inputDetector.DetectButton();
            RaisePropertyChanged();
            RaisePropertyChanged(nameof(InputButtonBHash));
            UpdateStatus();
        }
        public void DetectAxisInput()
        {
           Deactivate();
            _mapping.InputAxis = _inputDetector.DetectAxis();
            RaisePropertyChanged();
            RaisePropertyChanged(nameof(InputAxisHash));
            UpdateStatus();
        }

        public bool CanApply => !string.IsNullOrEmpty(Name) && Deactivated;
        public bool IsButtonToAxisMapping => TypeId == MappingType.BUTTON_TO_AXIS;
        public bool IsButtonToButtonMapping => TypeId == MappingType.BUTTON_TO_BUTTON;
        public bool IsEncoderToAxisMapping => TypeId == MappingType.ENCODER_TO_AXIS;
        public bool IsAxisToAxisMapping => TypeId == MappingType.AXIS_TO_AXIS;
        public bool IsAxisToButtonMapping => TypeId == MappingType.AXIS_TO_BUTTON;

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
                    RaisePropertyChanged();
                }
            }
        }

        public int InputButtonAHash
        {
            get => _mapping.InputButtonA.Hash;
            set
            {
                if (_mapping.InputButtonA.Hash != value)
                {
                    _mapping.InputButtonA = GetInputButtonA(value);
                    RaisePropertyChanged();
                }
            }
        }

        public int InputButtonBHash
        {
            get => _mapping.InputButtonB.Hash;
            set
            {
                if (_mapping.InputButtonB.Hash != value)
                {
                    _mapping.InputButtonB = GetInputButtonB(value);
                    RaisePropertyChanged();
                }
            }
        }

        public int InputAxisHash
        {
            get => _mapping.InputAxis.Hash;
            set
            {
                if (_mapping.InputAxis.Hash != value)
                {
                    _mapping.InputAxis = GetInputAxis(value);
                    RaisePropertyChanged();
                }
            }
        }
        public int OutputAxisHash
        {
            get => _mapping.OutputChannel.Hash;
            set
            {
                if (_mapping.OutputChannel.Hash != value)
                {
                    _mapping.OutputChannel = GetOutputAxis(value);
                    RaisePropertyChanged();
                }
            }
        }
        public int OutputButtonHash
        {
            get => _mapping.OutputChannel.Hash;
            set
            {
                if (_mapping.OutputChannel.Hash != value)
                {
                    _mapping.OutputChannel = GetOutputButton(value);
                    RaisePropertyChanged();
                }
            }
        }
        private InputButton GetInputButtonA(int hash)
        {
            foreach (var channel in InputButtonsA)
            {
                if (channel.Hash == hash)
                {
                    return channel;
                }
            }
            return new InputButton();
        }
        private InputButton GetInputButtonB(int hash)
        {
            foreach (var channel in InputButtonsB)
            {
                if (channel.Hash == hash)
                {
                    return channel;
                }
            }
            return new InputButton();
        }
        private InputAxis GetInputAxis(int hash)
        {
            foreach (var channel in InputAxes)
            {
                if (channel.Hash == hash)
                {
                    return channel;
                }
            }
            return new InputAxis();
        }

        private OutputChannel GetOutputAxis(int hash)
        {
            foreach (var channel in OutputAxes)
            {
                if (channel.Hash == hash)
                {
                    return channel;
                }
            }
            return new OutputChannel();
        }
        private OutputChannel GetOutputButton(int hash)
        {
            foreach (var channel in OutputButtons)
            {
                if (channel.Hash == hash)
                {
                    return channel;
                }
            }
            return new OutputChannel();
        }

        public int AxisSensitivity
        {
            get { return _mapping.AxisSensitivity; }
            set
            {
                if (_mapping.AxisSensitivity != value)
                {
                    Deactivate();
                    _mapping.AxisSensitivity = value;
                    RaisePropertyChanged();
                    UpdateStatus();
                }
            }
        }
        public int EncoderPPR
        {
            get { return _mapping.EncoderPPR; }
            set
            {
                if (_mapping.EncoderPPR != value)
                {
                    Deactivate();
                    _mapping.EncoderPPR = value;
                    RaisePropertyChanged();
                    UpdateStatus();
                }
            }
        }
        public float RevsInPerRevsOut
        {
            get { return _mapping.RevsInPerRevsOut; }
            set
            {
                if (_mapping.RevsInPerRevsOut != value)
                {
                    Deactivate();
                    _mapping.RevsInPerRevsOut = value;
                    RaisePropertyChanged();
                    UpdateStatus();
                }
            }
        }

        public int ButtonMultiplier
        {
            get { return _mapping.ButtonMultiplier; }
            set
            {
                if (_mapping.ButtonMultiplier != value)
                {
                    Deactivate();
                    _mapping.ButtonMultiplier = value;
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
