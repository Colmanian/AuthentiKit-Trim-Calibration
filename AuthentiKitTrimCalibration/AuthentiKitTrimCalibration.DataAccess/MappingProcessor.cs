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
                var inputGuid = _mapping.InputChannelA.Id;
                var joystickA = new Joystick(directInput, inputGuid);
                joystickA.Properties.BufferSize = 128;
                joystickA.Acquire();

                bool buttonAState = false;
                bool buttonBState = false;
                Stopwatch stopWatch = new();
                stopWatch.Start();
                while (true)
                {
                    Thread.Sleep(10); // Pole button state every this milliseconds

                    // Button A Polling
                    if (buttonAState != joystickA.GetCurrentState().Buttons[_mapping.InputChannelA.Button])
                    {
                        buttonAState = joystickA.GetCurrentState().Buttons[_mapping.InputChannelA.Button];
                    }

                    // Pass to relevent processor
                    if (_mapping.Type == MappingDTO.MappingType.Button && _buttonProcessor != null)
                    {
                        _buttonProcessor.Process(buttonAState, stopWatch.ElapsedMilliseconds);
                    } else if (_mapping.Type == MappingDTO.MappingType.Axis & _axisProcessor != null)
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
                        _axisProcessor.Process(buttonAState, buttonBState);
                    }
                }
            }
            catch (ThreadInterruptedException e)
            {
                Debug.WriteLine("Thread Interrupted Exception: {0}", _mapping.Name, e);
                //TODO Clean Up
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
            if (_mapping.Type == MappingDTO.MappingType.Button)
            {
                if (_mapping.OutputChannel is OutputButton)
                {
                    OutputButton outputButton = (OutputButton)_mapping.OutputChannel;
                    _buttonProcessor = new ButtonProcessor(_mapping.Multiplier, _mapping.HoldThresholdStart, _mapping.HoldThresholdStop, outputButton);
                }
            }
            else if (_mapping.Type == MappingDTO.MappingType.Axis)
            {
                if (_mapping.OutputChannel is OutputAxis)
                {
                    OutputAxis outputAxis = (OutputAxis)_mapping.OutputChannel;
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