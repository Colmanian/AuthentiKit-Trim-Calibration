using MappingManager.Common.DataProvider;
using MappingManager.Common.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using vJoyInterfaceWrap;

namespace AuthentiKitTrimCalibration.DataAccess
{
    public class MappingDataProvider : IMappingDataProvider
    {
        private Thread _mappingThread;

        public static void MappingProcess()
        {
            try
            {

                Debug.WriteLine("I've started mapping");
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

                // Output something
                int i = 0;
                while (true)
                {
                    Thread.Sleep(1000);
                    Debug.WriteLine(i);
                    i++;
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

        public IEnumerable<Device> LoadDevices()
        {
            Debug.WriteLine("LOAD DEVICES IS UNIMPLEMTNED");
            return new List<Device>
            {
                new Device{ Id = 1, Name = "Dummy Device A" },
                new Device{ Id = 2, Name = "Dummy Device B" },
            };
        }
    }
}