using AuthentiKitTuningApp.Processor;
using AuthentiKitTuningApp.Common.DataProvider;
using AuthentiKitTuningApp.Common.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using AuthentiKitTuningApp.Processor.Hardware;
using AuthentiKitTuningApp.Processor.Data;
using System.Runtime.InteropServices;

namespace AuthentiKitTuningApp.ViewModel
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
        private readonly ObservableCollection<OutputChannel> OutputButtonsA;
        private readonly ObservableCollection<OutputChannel> OutputButtonsB;

        public MappingViewModel(MappingDTO mapping, ObservableCollection<InputButton> inputButtonsA,
            ObservableCollection<InputButton> inputButtonsB,
            ObservableCollection<InputAxis> inputAxes,
            ObservableCollection<OutputChannel> outputAxes,
            ObservableCollection<OutputChannel> outputButtonsA,
            ObservableCollection<OutputChannel> outputButtonsB)
        {
            InputButtonsA = inputButtonsA;
            InputButtonsB = inputButtonsB;
            InputAxes = inputAxes;
            OutputAxes = outputAxes;
            OutputButtonsA = outputButtonsA;
            OutputButtonsB = outputButtonsB;
            _mappingProcessor = new MappingProcessor();
            _inputDetector = new InputDetector();
            _mapping = mapping;
            Deactivate();
        }

        public void UpdateStatus()
        {
            RaisePropertyChanged(nameof(Activated));
            RaisePropertyChanged(nameof(Deactivated));
            RaisePropertyChanged(nameof(Status));
            RaisePropertyChanged(nameof(StatusColour));
            RaisePropertyChanged(nameof(CalibrationDisplayString));
        }
        public void Activate()
        {
            if (CanApply)
            {
                _mappingProcessor.Activate(_mapping);
            }
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
            InputButton detected = _inputDetector.DetectButton();
            if (detected != null)
            {
                _mapping.InputButtonA = detected;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(InputButtonAHash));
                UpdateStatus();
            }
        }
        public void DetectButtonInputB()
        {
            Deactivate();
            InputButton detected = _inputDetector.DetectButton();
            if (detected != null)
            {
                _mapping.InputButtonB = detected;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(InputButtonBHash));
                UpdateStatus();
            }
        }
        public void DetectAxisInput()
        {
            Deactivate();
            _mapping.InputAxis = _inputDetector.DetectAxis();
            RaisePropertyChanged();
            RaisePropertyChanged(nameof(InputAxisHash));
            UpdateStatus();
        }

        public bool CanApply
        {
            get
            {
                if (string.IsNullOrEmpty(Name) || Activated)
                    return false;
                else
                {
                    bool inputButtonA = _mapping.InputButtonA.Device != null;
                    bool inputButtonB = _mapping.InputButtonB.Device != null;
                    bool inputAxis = _mapping.InputAxis.Device != null;
                    bool outputChannelA = _mapping.OutputChannelA.VJoyDevice > 0;
                    bool outputChannelB = _mapping.OutputChannelB.VJoyDevice > 0;
                    bool atLeastOneGateway = _mapping.Gateways.Count > 0;
                    bool latched = _mapping.Latched;

                    switch (_mapping.TypeId)
                    {
                        case MappingType.BUTTON_TO_AXIS:
                            return inputButtonA && inputButtonB && outputChannelA;
                        case MappingType.ENCODER_TO_AXIS:
                            return inputButtonA && inputButtonB && outputChannelA;
                        case MappingType.ENCODER_TO_BUTTON:
                            return inputButtonA && inputButtonB && outputChannelA;
                        case MappingType.AXIS_TO_AXIS:
                            return inputAxis && outputChannelA;
                        case MappingType.AXIS_TO_BUTTON:
                            return inputAxis && outputChannelA && outputChannelB && atLeastOneGateway;
                        case MappingType.BUTTON_TO_BUTTON:
                            return inputButtonA && outputChannelA;
                        case MappingType.ADVANCED_BUTTON_TO_BUTTON:
                            {
                                return inputButtonA && outputChannelA && outputChannelB;
                            }
                    }
                }
                return false;
            }
        }
        public bool Exists => true;
        public bool IsButtonToAxisMapping => TypeId == MappingType.BUTTON_TO_AXIS;
        public bool IsButtonToButtonMapping => TypeId == MappingType.BUTTON_TO_BUTTON;
        public bool IsEncoderToAxisMapping => TypeId == MappingType.ENCODER_TO_AXIS;
        public bool IsAxisToAxisMapping => TypeId == MappingType.AXIS_TO_AXIS;
        public bool IsAxisToButtonMapping => TypeId == MappingType.AXIS_TO_BUTTON;
        public bool IsAdvancedButtonToButtonMapping => TypeId == MappingType.ADVANCED_BUTTON_TO_BUTTON;

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
                    IsDirty = true;
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
                    IsDirty = true;
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
                    IsDirty = true;
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
                    IsDirty = true;
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
                    IsDirty = true;
                }
            }
        }
        public int OutputAxisHash
        {
            get => _mapping.OutputChannelA.Hash;
            set
            {
                if (_mapping.OutputChannelA.Hash != value)
                {
                    _mapping.OutputChannelA = GetOutputAxis(value);
                    RaisePropertyChanged();
                    IsDirty = true;
                }
            }
        }
        public int OutputButtonAHash
        {
            get => _mapping.OutputChannelA.Hash;
            set
            {
                if (_mapping.OutputChannelA.Hash != value)
                {
                    _mapping.OutputChannelA = GetOutputButtonA(value);
                    RaisePropertyChanged();
                    IsDirty = true;
                }
            }
        }
        public int OutputButtonBHash
        {
            get => _mapping.OutputChannelB.Hash;
            set
            {
                if (_mapping.OutputChannelB.Hash != value)
                {
                    _mapping.OutputChannelB = GetOutputButtonB(value);
                    RaisePropertyChanged();
                    IsDirty = true;
                }
            }
        }

        public string CalibrationDisplayString
        {
            get
            {
                CalibrationDTO savedCalibration = _mapping.Calibration;
                CalibrationDTO actualCalibration = DataHandler.GetAxisCalibration(_mapping.InputAxis);
                string returnString = "Axis not calibratied yet";

                if ((savedCalibration != null) && (actualCalibration != null))
                {
                    if (actualCalibration.IsSet && savedCalibration.Equals(actualCalibration))
                    {
                        returnString = actualCalibration.ToString();
                    }
                    else if (actualCalibration.IsSet && !savedCalibration.Equals(actualCalibration))
                    {
                        returnString = "* " + actualCalibration.ToString() + "  (unsaved)";
                    }
                }
                return returnString;
            }
        }
        public bool Flipped
        {
            get => _mapping.Flipped;
            set
            {
                if (_mapping.Flipped != value)
                {
                    _mapping.Flipped = value;
                    RaisePropertyChanged();
                    IsDirty = true;
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
        private OutputChannel GetOutputButtonA(int hash)
        {
            foreach (var channel in OutputButtonsA)
            {
                if (channel.Hash == hash)
                {
                    return channel;
                }
            }
            return new OutputChannel();
        }
        private OutputChannel GetOutputButtonB(int hash)
        {
            foreach (var channel in OutputButtonsB)
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
                    IsDirty = true;
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
                    IsDirty = true;
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
                    IsDirty = true;
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
                    IsDirty = true;
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
                    IsDirty = true;
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
                    IsDirty = true;
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
                    IsDirty = true;
                }
            }
        }

        public bool Activated
        {
            get { return _mappingProcessor.IsRunning(); }
        }
        public bool Deactivated => !Activated;

        // TECH DEBT. NEED A BETTER WAY OF DOING THIS
        public bool GatewayEnabled1
        {
            get { return _mapping.GatewayEnabled1; }
            set
            {
                if (_mapping.GatewayEnabled1 != value)
                {
                    Deactivate();
                    _mapping.GatewayEnabled1 = value;
                    RaisePropertyChanged();
                    UpdateStatus();
                    IsDirty = true;
                }
            }
        }
        public bool GatewayEnabled2
        {
            get { return _mapping.GatewayEnabled2; }
            set
            {
                if (_mapping.GatewayEnabled2 != value)
                {
                    Deactivate();
                    _mapping.GatewayEnabled2 = value;
                    RaisePropertyChanged();
                    UpdateStatus();
                    IsDirty = true;
                }
            }
        }
        public bool GatewayEnabled3
        {
            get { return _mapping.GatewayEnabled3; }
            set
            {
                if (_mapping.GatewayEnabled3 != value)
                {
                    Deactivate();
                    _mapping.GatewayEnabled3 = value;
                    RaisePropertyChanged();
                    UpdateStatus();
                    IsDirty = true;
                }
            }
        }
        public bool GatewayEnabled4
        {
            get { return _mapping.GatewayEnabled4; }
            set
            {
                if (_mapping.GatewayEnabled4 != value)
                {
                    Deactivate();
                    _mapping.GatewayEnabled4 = value;
                    RaisePropertyChanged();
                    UpdateStatus();
                    IsDirty = true;
                }
            }
        }
        public bool GatewayEnabled5
        {
            get { return _mapping.GatewayEnabled5; }
            set
            {
                if (_mapping.GatewayEnabled5 != value)
                {
                    Deactivate();
                    _mapping.GatewayEnabled5 = value;
                    RaisePropertyChanged();
                    UpdateStatus();
                    IsDirty = true;
                }
            }
        }
        public int Gateway1
        {
            get { return _mapping.Gateway1; }
            set
            {
                if (_mapping.Gateway1 != value)
                {
                    Deactivate();
                    _mapping.Gateway1 = value;
                    RaisePropertyChanged();
                    UpdateStatus();
                    IsDirty = true;
                }
            }
        }
        public int Gateway2
        {
            get { return _mapping.Gateway2; }
            set
            {
                if (_mapping.Gateway2 != value)
                {
                    Deactivate();
                    _mapping.Gateway2 = value;
                    RaisePropertyChanged();
                    UpdateStatus();
                    IsDirty = true;
                }
            }
        }
        public int Gateway3
        {
            get { return _mapping.Gateway3; }
            set
            {
                if (_mapping.Gateway3 != value)
                {
                    Deactivate();
                    _mapping.Gateway3 = value;
                    RaisePropertyChanged();
                    UpdateStatus();
                    IsDirty = true;
                }
            }
        }
        public int Gateway4
        {
            get { return _mapping.Gateway4; }
            set
            {
                if (_mapping.Gateway4 != value)
                {
                    Deactivate();
                    _mapping.Gateway4 = value;
                    RaisePropertyChanged();
                    UpdateStatus();
                    IsDirty = true;
                }
            }
        }
        public int Gateway5
        {
            get { return _mapping.Gateway5; }
            set
            {
                if (_mapping.Gateway5 != value)
                {
                    Deactivate();
                    _mapping.Gateway5 = value;
                    RaisePropertyChanged();
                    UpdateStatus();
                    IsDirty = true;
                }
            }
        }

        public bool Latched
        {
            get { return _mapping.Latched; }
            set
            {
                if (_mapping.Latched != value)
                {
                    Deactivate();
                    _mapping.Latched = value;
                    RaisePropertyChanged();
                    UpdateStatus();
                    IsDirty = true;
                }
            }
        }

        public bool IsDirty { get; set; }

    }
}
