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
                Debug.WriteLine("*** ATTEMPTING TO USE DirectX ***");
                var directInput = new DirectInput();
                var inputGuid = Guid.Empty;
                foreach (var d in directInput.GetDevices())
                {
                    Debug.WriteLine("_________________________________________________");
                    Debug.WriteLine(d.InstanceName);
                    Debug.WriteLine(d.InstanceGuid);

                    if (d.InstanceName.Contains("BU0836"))
                    {
                        inputGuid = d.InstanceGuid;
                        Debug.WriteLine("Choosing this one....");
                    }
                }
                if (inputGuid == Guid.Empty)
                {
                    Debug.WriteLine("No BU0836 Found!");
                    return;
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
                }

                // Monitor for Input
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
            }
            catch (ThreadInterruptedException e)
            {
                Debug.WriteLine("Thread Interrupted Exception: {0}", _mapping.Name, e);
                //TODO Clean Up
            }
        }

        public void ApplyMapping(MappingDTO mapping)
        {
            _mapping = mapping;
            Stop();
            var mappingThreadRef = new ThreadStart(MappingProcess);
            _mappingThread = new Thread(mappingThreadRef);
            _mappingThread.Start();
        }

        public void Stop()
        {
            if (_mappingThread != null)
            {
                Debug.WriteLine($"Stopping Mapping: {_mapping.Name}");
                _mappingThread.Interrupt();
                _mappingThread = null;
            }
        }

    }
}