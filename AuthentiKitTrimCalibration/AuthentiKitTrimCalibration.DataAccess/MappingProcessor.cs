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

                    // Button B Polling (Used for Axis Only)
                    // TODO

                    // Pass to relevent processor
                    if (_mapping.Type == MappingDTO.MappingType.Button)
                    {
                        _buttonProcessor.Process(buttonAState, stopWatch.ElapsedMilliseconds);
                    }
                }

                /*Debug.WriteLine("*** ATTEMPTING TO USE VJOY *** ");
                var vJoystick = new vJoy();
                if (!vJoystick.vJoyEnabled())
                {
                    Debug.WriteLine("vJoy driver not enabled: Failed Getting vJoy attributes.\n");
                }
                else
                {
                    Debug.WriteLine("Vendor: {0}\nProduct :{1}\nVersion Number:{2}\n", vJoystick.GetvJoyManufacturerString(), vJoystick.GetvJoyProductString(), vJoystick.GetvJoySerialNumberString());
                }*/
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
            if(_mapping.Type == MappingDTO.MappingType.Button)
            {
                _buttonProcessor = new ButtonProcessor(_mapping.Multiplier, _mapping.HoldThresholdStart, _mapping.HoldThresholdStop);
            }else if (_mapping.Type == MappingDTO.MappingType.Axis)
            {
                return; // Not implemented

            } else
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
    }
}