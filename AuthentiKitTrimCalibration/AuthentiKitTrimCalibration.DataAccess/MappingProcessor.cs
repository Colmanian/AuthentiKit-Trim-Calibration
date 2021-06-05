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
        private bool Running;

        private void MappingProcess()
        {
            Running = true;
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
                while (Running)
                {
                    Thread.Sleep(10);
                    if (button11 != joystick.GetCurrentState().Buttons[11])
                    {
                        button11 = joystick.GetCurrentState().Buttons[11];
                        Debug.WriteLine("Button 11 now {0} at {1}ms", button11, stopWatch.ElapsedMilliseconds);
                    }
                }
            }
            catch (ThreadAbortException e)
            {
                Debug.WriteLine("Thread Abort Exception: {0}", e);
            }
        }

        public IEnumerable<Mapping> LoadMappings()
        {
            return new List<Mapping>
            {
                new Mapping
                {
                  Name = "Elevator Trim (Up)",
                  InputId = 1,
                  OutputId = 2,
                  Multiplier = 3,
                  HoldThresholdStart = 200,
                  HoldThresholdStop = 200,
                  ResetCommand = "CTRL+T"
                },new Mapping
                {
                  Name = "Elevator Trim (Down)",
                  InputId = 2,
                  OutputId = 1,
                  Multiplier = 3,
                  HoldThresholdStart = 200,
                  HoldThresholdStop = 200,
                  ResetCommand = "CTRL+T"
                },new Mapping
                {
                  Name = "Rudder Trim (Left)",
                  InputId = 1,
                  OutputId = 2,
                  Multiplier = 3,
                  HoldThresholdStart = 200,
                  HoldThresholdStop = 200,
                  ResetCommand = "CTRL+T"
                },new Mapping
                {
                  Name = "Rudder Trim (Right)",
                  InputId = 3,
                  OutputId = 2,
                  Multiplier = 3,
                  HoldThresholdStart = 200,
                  HoldThresholdStop = 200,
                  ResetCommand = "CTRL+T"
                }
            };
        }

        public void ApplyMapping(Mapping mapping)
        {
            Debug.WriteLine($"APPLY IS UNIMPLEMTNED: {mapping.Name}");
        }

        public void Stop(Mapping mapping)
        {
            Debug.WriteLine($"Stopping Mapping: {mapping.Name}");
            Running = false;
        }

        public IEnumerable<InputChannel> GetInputChannels()
        {
            Debug.WriteLine("LOAD DEVICES IS UNIMPLEMTNED");
            return new List<InputChannel>
            {
                new InputChannel{ Id = 0, Device = "Dummy Device A", Button = 1, DisplayText = "Device A: Button 1" },
                new InputChannel{ Id = 1, Device = "Dummy Device A", Button = 2, DisplayText = "Device A: Button 2" },
                new InputChannel{ Id = 2, Device = "Dummy Device B", Button = 1, DisplayText = "Device B: Button 1" },
            };
        }

        public void Run()
        {
            if (_mappingThread == null)
            {
                var mappingThreadRef = new ThreadStart(MappingProcess);
                _mappingThread = new Thread(mappingThreadRef);
                _mappingThread.Start();
            }
        }
    public IEnumerable<OutputChannel> GetOutputChannels()
        {
            Debug.WriteLine("LOAD DEVICES IS UNIMPLEMTNED");
            return new List<OutputChannel>
            {
                new OutputChannel{ Id = 0, VJoyDevice = 1, VJoyItem = 1, DisplayText = "vJoy 1: Button 1" },
                new OutputChannel{ Id = 1, VJoyDevice = 1, VJoyItem = 2, DisplayText = "vJoy 1: Button 2" },
                new OutputChannel{ Id = 1, VJoyDevice = 1, VJoyItem = 20, DisplayText = "vJoy 1: Axis 1" },
            };
        }

        Mapping IMappingProcessor.GetDefaultMapping()
        {
            return new Mapping {Name = "New Mapping"};
        }
    }
}