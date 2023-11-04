using AuthentiKitTuningApp.Common.Model;
using AuthentiKitTuningApp.Common.DataProvider;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vJoyInterfaceWrap;
using SharpDX.DirectInput;

namespace AuthentiKitTuningApp.Processor
{
    public class DiagnosticProcessor : IDiagnosticProcessor
    {
        public DiagnosticDTO RunDiagnostics()
        {
            DiagnosticDTO diagnostics = new();

            // Check vJoy is installed
            var joystick = new vJoy();
            if (!joystick.vJoyEnabled())
            {
                diagnostics.Message = "vJoy Driver cannot interface with vJoy. Is vJoy installed?\n";
            }
            else
            {
                diagnostics.Healthy = false; //TODO Set to true
                diagnostics.Message = String.Format("vJoy Enabled: {0}\nProduct :{1}\nVersion Number:{2}\n",
                    joystick.GetvJoyManufacturerString(),
                    joystick.GetvJoyProductString(),
                    joystick.GetvJoySerialNumberString());
            }

            Debug.WriteLine(diagnostics.Message);
            return diagnostics;
        }
    }
}