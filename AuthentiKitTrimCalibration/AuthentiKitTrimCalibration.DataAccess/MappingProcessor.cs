using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System;
using vJoyInterfaceWrap;
using SharpDX.DirectInput;

namespace AuthentiKitTrimCalibration.DataAccess
{
    public class MappingProcessor : IMappingProcessor
    {
        private Thread _mappingThread;
        private MappingDTO _mapping;

        private void MappingProcess()
        {
            try
            {
                /*
                // Input Event Generation
                var directInput = new DirectInput();
                var inputGuid = _mapping.InputID_A;
                var joystick = new Joystick(directInput, inputGuid);
                joystick.Properties.BufferSize = 128;
                joystick.Acquire();
                bool button11 = false;
                Stopwatch stopWatch = new();
                stopWatch.Start();
                while (true)
                {
                    Thread.Sleep(10);
                    if (button11 != joystick.GetCurrentState().Buttons[11])
                    {
                        button11 = joystick.GetCurrentState().Buttons[11];
                        Debug.WriteLine("Button 11 now {0} at {1}ms", button11, stopWatch.ElapsedMilliseconds);
                    }
                }

                Debug.WriteLine("*** ATTEMPTING TO USE VJOY *** ");
                var vJoystick = new vJoy();
                if (!vJoystick.vJoyEnabled())
                {
                    Debug.WriteLine("vJoy driver not enabled: Failed Getting vJoy attributes.\n");
                }
                else
                {
                    Debug.WriteLine("Vendor: {0}\nProduct :{1}\nVersion Number:{2}\n", vJoystick.GetvJoyManufacturerString(), vJoystick.GetvJoyProductString(), vJoystick.GetvJoySerialNumberString());
                } */
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