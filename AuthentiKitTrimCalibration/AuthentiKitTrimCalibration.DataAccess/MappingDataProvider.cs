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
    public class MappingDataProvider : IMappingDataProvider
    {
        private Thread _mappingThread;

        public static void MappingProcess()
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
            catch (ThreadAbortException e)
            {
                Debug.WriteLine("Thread Abort Exception: ", e);
            }
            finally
            {
                Debug.WriteLine("Something else went wrong");
            }

        }

        public IEnumerable<Mapping> LoadMappings()
        {
            return new List<Mapping>
            {
                new Mapping
                {
                  Name = "Elevator Trim (Up)",
                  Input = "Not Implemented",
                  Output = "Not Implemented",
                  Multiplier = 3,
                  HoldThresholdStart = 200,
                  HoldThresholdStop = 200,
                  ResetCommand = "CTRL+T"
                },new Mapping
                {
                  Name = "Elevator Trim (Down)",
                  Input = "Not Implemented",
                  Output = "Not Implemented",
                  Multiplier = 3,
                  HoldThresholdStart = 200,
                  HoldThresholdStop = 200,
                  ResetCommand = "CTRL+T"
                },new Mapping
                {
                  Name = "Rudder Trim (Left)",
                  Input = "Not Implemented",
                  Output = "Not Implemented",
                  Multiplier = 3,
                  HoldThresholdStart = 200,
                  HoldThresholdStop = 200,
                  ResetCommand = "CTRL+T"
                },new Mapping
                {
                  Name = "Rudder Trim (Right)",
                  Input = "Not Implemented",
                  Output = "Not Implemented",
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
            if(_mappingThread == null)
            {
                var mappingThreadRef = new ThreadStart(MappingProcess);
                _mappingThread = new Thread(mappingThreadRef);
                _mappingThread.Start();
            }
        }

        public IEnumerable<InputDevice> LoadDevices()
        {
            Debug.WriteLine("LOAD DEVICES IS UNIMPLEMTNED");
            return new List<InputDevice>
            {
                new InputDevice{ Id = 1, Name = "Dummy Device A" },
                new InputDevice{ Id = 2, Name = "Dummy Device B" },
            };
        }
    }
}