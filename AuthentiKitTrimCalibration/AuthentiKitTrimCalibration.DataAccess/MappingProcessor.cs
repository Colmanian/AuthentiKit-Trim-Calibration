using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System.Diagnostics;
using System.Threading;
using System;
using SharpDX.DirectInput;

namespace AuthentiKitTrimCalibration.DataAccess
{
    public class MappingProcessor : IMappingProcessor
    {
        private Thread _mappingThread;
        private MappingDTO _mapping;
        private ButtonProcessor _buttonProcessor;
        private AxisProcessor _axisProcessor;
        bool _needToCentre;

        private void MappingProcess()
        {
            try
            {
                // Input Event Generation
                var directInput = new DirectInput();
                var inputGuid = _mapping.InputChannelA.Guid;
                var joystickA = new Joystick(directInput, inputGuid);
                joystickA.Properties.BufferSize = 128;
                joystickA.Acquire();

                bool buttonAState = false;
                bool buttonBState = false;
                Stopwatch stopWatch = new();
                stopWatch.Start();
                while (true)
                {
                    Thread.Sleep(2); // Pole button state every this milliseconds

                    // Button A Polling
                    if (buttonAState != joystickA.GetCurrentState().Buttons[_mapping.InputChannelA.Button])
                    {
                        buttonAState = joystickA.GetCurrentState().Buttons[_mapping.InputChannelA.Button];
                    }

                    // Pass to relevent processor
                    if (_mapping.TypeId == MappingType.BUTTON && _buttonProcessor != null)
                    {
                        _buttonProcessor.Process(buttonAState, stopWatch.ElapsedMilliseconds);
                    }
                    else if (_mapping.TypeId == MappingType.AXIS & _axisProcessor != null)
                    {
                        // Button B Polling (Used for Axis Only)
                        if (buttonBState != joystickA.GetCurrentState().Buttons[_mapping.InputChannelB.Button])
                        {
                            buttonBState = joystickA.GetCurrentState().Buttons[_mapping.InputChannelB.Button];
                        }
                        if (_needToCentre)
                        {
                            _axisProcessor.Centre();
                            _needToCentre = false;
                        }
                        _axisProcessor.Process(buttonAState, buttonBState, stopWatch.ElapsedMilliseconds);
                    }
                }
            }
            catch (ThreadInterruptedException e)
            {
                Debug.WriteLine("Thread Interrupted Exception: {0}", _mapping.Name, e);
                if (_axisProcessor != null)
                {
                    _axisProcessor.CleanUp();
                }
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
            if (_mapping.TypeId == MappingType.BUTTON)
            {
                Debug.WriteLine("Which means button, and the output channel is " + _mapping.OutputChannel.Name);
                if (_mapping.OutputChannel is OutputButton outputButton)
                {
                    Debug.WriteLine("so creating new Button Processor...");
                    _buttonProcessor = new ButtonProcessor(_mapping.Multiplier, _mapping.HoldThresholdStart, _mapping.HoldThresholdStop, outputButton);
                }
            }
            else if (_mapping.TypeId == MappingType.AXIS)
            {
                Debug.WriteLine("Which means axis, and the output channel is " + _mapping.OutputChannel.Name);
                if (_mapping.OutputChannel is OutputAxis outputAxis)
                {
                    Debug.WriteLine("so creating new Axis Processor...");
                    _axisProcessor = new AxisProcessor(_mapping.Multiplier, outputAxis);
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