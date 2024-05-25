using AuthentiKitTuningApp.Common.DataProvider;
using AuthentiKitTuningApp.Common.Model;
using System.Diagnostics;
using System.Threading;
using System;
using SharpDX.DirectInput;

namespace AuthentiKitTuningApp.Processor
{
    public class MappingProcessor : IMappingProcessor
    {
        private Thread _mappingThread;
        private MappingDTO _mapping;
        private ButtonToButtonProcessor _buttonTobuttonProcessor;
        private ButtonToAxisProcessor _buttonToaxisProcessor;
        private EncoderToAxisProcessor _encoderToAxisProcessor;
        private AxisToAxisProcessor _axisToAxisProcessor;
        private AxisToButtonProcessor _axisToButtonProcessor;
        private AdvancedButtonToButtonProcessor _advancedButtonToButtonProcessor;
        private ButtonChangeToPulseProcessor _buttonChangeToPulseProcessor;
        bool _needToCentre;

        private void MappingProcess()
        {
            try
            {
                // Mappings based on Button Input
                if (_mapping.TypeId == MappingType.BUTTON_TO_BUTTON ||
                    _mapping.TypeId == MappingType.BUTTON_TO_AXIS ||
                    _mapping.TypeId == MappingType.ENCODER_TO_AXIS ||
                    _mapping.TypeId == MappingType.ENCODER_TO_BUTTON ||
                    _mapping.TypeId == MappingType.ADVANCED_BUTTON_TO_BUTTON ||
                    _mapping.TypeId == MappingType.BUTTON_CHANGE_TO_PULSE)
                {
                    // Input Event Generation
                    var directInput = new DirectInput();
                    var inputGuid = _mapping.InputButtonA.Guid;
                    var joystick = new Joystick(directInput, inputGuid);
                    joystick.Properties.BufferSize = 128;
                    joystick.Acquire();

                    bool buttonAState = false;
                    bool buttonBState = false;
                    Stopwatch stopWatch = new();
                    stopWatch.Start();
                    while (true)
                    {
                        Thread.Sleep(2); // Pole joystick state every this milliseconds

                        // Execute the relevent processor
                        if (_mapping.TypeId == MappingType.BUTTON_TO_BUTTON && _buttonTobuttonProcessor != null)
                        {
                            // Button A Polling
                            if (buttonAState != joystick.GetCurrentState().Buttons[_mapping.InputButtonA.Button])
                            {
                                buttonAState = joystick.GetCurrentState().Buttons[_mapping.InputButtonA.Button];
                            }
                            _buttonTobuttonProcessor.Process(buttonAState, stopWatch.ElapsedMilliseconds);
                        }
                        else if (_mapping.TypeId == MappingType.BUTTON_TO_AXIS & _buttonToaxisProcessor != null)
                        {
                            // Button A Polling
                            if (buttonAState != joystick.GetCurrentState().Buttons[_mapping.InputButtonA.Button])
                            {
                                buttonAState = joystick.GetCurrentState().Buttons[_mapping.InputButtonA.Button];
                            }
                            // Button B Polling
                            if (buttonBState != joystick.GetCurrentState().Buttons[_mapping.InputButtonB.Button])
                            {
                                buttonBState = joystick.GetCurrentState().Buttons[_mapping.InputButtonB.Button];
                            }
                            if (_needToCentre)
                            {
                                _buttonToaxisProcessor.Centre();
                                _needToCentre = false;
                            }
                            _buttonToaxisProcessor.Process(buttonAState, buttonBState, stopWatch.ElapsedMilliseconds);
                        }
                        else if (_mapping.TypeId == MappingType.ENCODER_TO_AXIS & _encoderToAxisProcessor != null)
                        {
                            // Button A Polling
                            if (buttonAState != joystick.GetCurrentState().Buttons[_mapping.InputButtonA.Button])
                            {
                                buttonAState = joystick.GetCurrentState().Buttons[_mapping.InputButtonA.Button];
                            }
                            // Button B Polling
                            if (buttonBState != joystick.GetCurrentState().Buttons[_mapping.InputButtonB.Button])
                            {
                                buttonBState = joystick.GetCurrentState().Buttons[_mapping.InputButtonB.Button];
                            }
                            if (_needToCentre)
                            {
                                _buttonToaxisProcessor.Centre();
                                _needToCentre = false;
                            }
                            _encoderToAxisProcessor.Process(buttonAState, buttonBState, stopWatch.ElapsedMilliseconds);
                        } else if (_mapping.TypeId == MappingType.ADVANCED_BUTTON_TO_BUTTON && _advancedButtonToButtonProcessor != null)
                        {
                            // Button A Polling
                            if (buttonAState != joystick.GetCurrentState().Buttons[_mapping.InputButtonA.Button])
                            {
                                buttonAState = joystick.GetCurrentState().Buttons[_mapping.InputButtonA.Button];
                            }
                            _advancedButtonToButtonProcessor.Process(buttonAState, stopWatch.ElapsedMilliseconds);
                        }
                        else if (_mapping.TypeId == MappingType.BUTTON_CHANGE_TO_PULSE && _buttonChangeToPulseProcessor != null)
                        {
                            // Button A Polling
                            if (buttonAState != joystick.GetCurrentState().Buttons[_mapping.InputButtonA.Button])
                            {
                                buttonAState = joystick.GetCurrentState().Buttons[_mapping.InputButtonA.Button];
                            }
                            _buttonChangeToPulseProcessor.Process(buttonAState, stopWatch.ElapsedMilliseconds);
                        }
                    }

                }
                // Mappings based on Axis Input
                else if (_mapping.TypeId == MappingType.AXIS_TO_AXIS || _mapping.TypeId == MappingType.AXIS_TO_BUTTON)
                {
                    // Input Event Generation
                    var directInput = new DirectInput();
                    var inputGuid = _mapping.InputAxis.Guid;
                    var joystick = new Joystick(directInput, inputGuid);
                    joystick.Properties.BufferSize = 128;
                    joystick.Acquire();
                    Stopwatch stopWatch = new();
                    stopWatch.Start();
                    while (true)
                    {
                        Thread.Sleep(2);
                        {
                            if (_mapping.TypeId == MappingType.AXIS_TO_AXIS & _axisToAxisProcessor != null)
                            {
                                JoystickOffset axisType = (JoystickOffset)_axisToAxisProcessor.getAxisId();
                                switch (axisType)
                                {
                                    case JoystickOffset.X:
                                        _axisToAxisProcessor.Process(joystick.GetCurrentState().X);
                                        break;
                                    case JoystickOffset.Y:
                                        _axisToAxisProcessor.Process(joystick.GetCurrentState().Y);
                                        break;
                                    case JoystickOffset.Z:
                                        _axisToAxisProcessor.Process(joystick.GetCurrentState().Z);
                                        break;
                                    case JoystickOffset.RotationX:
                                        _axisToAxisProcessor.Process(joystick.GetCurrentState().RotationX);
                                        break;
                                    case JoystickOffset.RotationY:
                                        _axisToAxisProcessor.Process(joystick.GetCurrentState().RotationY);
                                        break;
                                    case JoystickOffset.RotationZ:
                                        _axisToAxisProcessor.Process(joystick.GetCurrentState().RotationZ);
                                        break;
                                    case JoystickOffset.Sliders0:
                                        _axisToAxisProcessor.Process(joystick.GetCurrentState().Sliders[0]);
                                        break;
                                    case JoystickOffset.Sliders1:
                                        _axisToAxisProcessor.Process(joystick.GetCurrentState().Sliders[1]);
                                        break;
                                    default:
                                        break;
                                }
                            } else if (_mapping.TypeId == MappingType.AXIS_TO_BUTTON & _axisToButtonProcessor != null)
                            {
                                JoystickOffset axisType = (JoystickOffset)_axisToButtonProcessor.getAxisId();
                                switch (axisType)
                                {
                                    case JoystickOffset.X:
                                        _axisToButtonProcessor.Process(joystick.GetCurrentState().X, stopWatch.ElapsedMilliseconds);
                                        break;
                                    case JoystickOffset.Y:
                                        _axisToButtonProcessor.Process(joystick.GetCurrentState().Y, stopWatch.ElapsedMilliseconds);
                                        break;
                                    case JoystickOffset.Z:
                                        _axisToButtonProcessor.Process(joystick.GetCurrentState().Z, stopWatch.ElapsedMilliseconds);
                                        break;
                                    case JoystickOffset.RotationX:
                                        _axisToButtonProcessor.Process(joystick.GetCurrentState().RotationX, stopWatch.ElapsedMilliseconds);
                                        break;
                                    case JoystickOffset.RotationY:
                                        _axisToButtonProcessor.Process(joystick.GetCurrentState().RotationY, stopWatch.ElapsedMilliseconds);
                                        break;
                                    case JoystickOffset.RotationZ:
                                        _axisToButtonProcessor.Process(joystick.GetCurrentState().RotationZ, stopWatch.ElapsedMilliseconds);
                                        break;
                                    case JoystickOffset.Sliders0:
                                        _axisToButtonProcessor.Process(joystick.GetCurrentState().Sliders[0], stopWatch.ElapsedMilliseconds);
                                        break;
                                    case JoystickOffset.Sliders1:
                                        _axisToButtonProcessor.Process(joystick.GetCurrentState().Sliders[1], stopWatch.ElapsedMilliseconds);
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch (ThreadInterruptedException e)
            {
                Debug.WriteLine("Thread Interrupted Exception: {0}", _mapping.Name, e);
                _buttonToaxisProcessor?.CleanUp();
            }
            catch (Exception e)
            {
                _mapping.Errored = true;
                _mapping.ErrorMessage = e.Message;
                Debug.WriteLine(e.Message);
            }
        }

        public void Activate(MappingDTO mapping)
        {
            _mapping = mapping;
            Deactivate();
            Debug.WriteLine("Activating MappingProcessor with type {0}", _mapping.TypeId);
            if (_mapping.TypeId == MappingType.BUTTON_TO_BUTTON)
            {
                Debug.WriteLine("Which means button, and the output channel is " + _mapping.OutputChannelA.Name);
                if (_mapping.OutputChannelA is OutputButton outputButton)
                {
                    Debug.WriteLine("so creating new Button Processor...");
                    _buttonTobuttonProcessor = new ButtonToButtonProcessor(_mapping.ButtonMultiplier, _mapping.HoldThresholdStart, _mapping.HoldThresholdStop, outputButton);
                }
            }
            else if (_mapping.TypeId == MappingType.BUTTON_TO_AXIS)
            {
                Debug.WriteLine("Which means axis, and the output channel is " + _mapping.OutputChannelA.Name);
                if (_mapping.OutputChannelA is OutputAxis outputAxis)
                {
                    Debug.WriteLine("and creating new Axis Processor...");
                    _buttonToaxisProcessor = new ButtonToAxisProcessor(_mapping.AxisSensitivity, outputAxis);
                }
            }
            else if (_mapping.TypeId == MappingType.ENCODER_TO_AXIS)
            {
                Debug.WriteLine("Which means axis, and the output channel is " + _mapping.OutputChannelA.Name);
                if (_mapping.OutputChannelA is OutputAxis outputAxis)
                {
                    Debug.WriteLine("and creating new Encoder to Axis Processor...");
                    _encoderToAxisProcessor = new EncoderToAxisProcessor(_mapping.EncoderPPR, _mapping.RevsInPerRevsOut, outputAxis);
                }
            }
            else if (_mapping.TypeId == MappingType.AXIS_TO_AXIS)
            {
                Debug.WriteLine("Which means axis to axis, and the output channel is " + _mapping.OutputChannelA.Name);
                if (_mapping.OutputChannelA is OutputAxis outputAxis)
                {
                    Debug.WriteLine("and creating new Axis to Axis Processor...");
                    _axisToAxisProcessor = new AxisToAxisProcessor(inputAxis: _mapping.InputAxis, outputAxis: outputAxis, flipped: _mapping.Flipped);
                }
            }
            else if (_mapping.TypeId == MappingType.AXIS_TO_BUTTON)
            {
                Debug.WriteLine("Which means axis to button, and the output channels are {0} and {1}", _mapping.OutputChannelA.Name, _mapping.OutputChannelB.Name);
                if ((_mapping.OutputChannelA is OutputButton outputButtonA) && (_mapping.OutputChannelB is OutputButton outputButtonB))
                {
                    Debug.WriteLine("and creating new Axis to Button Processor...");
                    _axisToButtonProcessor = new AxisToButtonProcessor(inputAxis: _mapping.InputAxis,
                        outputButtonA: outputButtonA,
                        outputButtonB: outputButtonB,
                        gateways: _mapping.Gateways);
                }
            }
            else if(_mapping.TypeId == MappingType.ADVANCED_BUTTON_TO_BUTTON)
            {
                Debug.WriteLine("Which means advanced button, and the output channels are {0} and {1}", _mapping.OutputChannelA.Name, _mapping.OutputChannelB.Name);
                if ((_mapping.OutputChannelA is OutputButton outputButtonA) && (_mapping.OutputChannelB is OutputButton outputButtonB))
                {
                    Debug.WriteLine("so creating new Advanced Button Processor...");
                    _advancedButtonToButtonProcessor = new AdvancedButtonToButtonProcessor(_mapping.Latched, outputButtonA, outputButtonB);
                }
            }
            else if (_mapping.TypeId == MappingType.BUTTON_CHANGE_TO_PULSE)
            {
                Debug.WriteLine("Which means button change to pulse, and the output channels are {0} and {1}", _mapping.OutputChannelA.Name, _mapping.OutputChannelB.Name);
                if ((_mapping.OutputChannelA is OutputButton outputButtonA) && (_mapping.OutputChannelB is OutputButton outputButtonB))
                {
                    Debug.WriteLine("so creating new Button Change to PulseProcessor...");
                    _buttonChangeToPulseProcessor = new ButtonChangeToPulseProcessor(_mapping.Latched, outputButtonA, outputButtonB);
                }
            }
            else
            {
                return;
            }

            var mappingThreadRef = new ThreadStart(MappingProcess);
            _mappingThread = new Thread(mappingThreadRef);
            _mappingThread.Start();
            _mapping.Active = true;
        }

        public void Deactivate()
        {
            if (_mappingThread != null)
            {
                Debug.WriteLine($"Stopping Mapping: {_mapping.Name}");
                _mappingThread.Interrupt();
                _mappingThread = null;
            }
            if (_mapping != null)
            {
                _mapping.Active = false;
                _mapping.Errored = false;
            }
        }

        public bool IsRunning()
        {
            bool active = false;
            if (_mapping != null)
            {
                active = _mapping.Active;
            }
            return active;
        }

        public bool IsErrored()
        {
            bool errored = false;
            if (_mapping != null)
            {
                errored = _mapping.Errored;
            }
            return errored;
        }
        public void Centre()
        {
            _needToCentre = true;
        }
    }
}