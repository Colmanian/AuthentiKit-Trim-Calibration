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
using AuthentiKitTuningApp.Processor.Hardware;

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
                diagnostics.Healthy = false;
                diagnostics.Message = "vJoy Driver cannot interface with vJoy.\nCheck vJoy is installed and enabled.";

            }
            else
            {
                diagnostics.Healthy = true;
                diagnostics.Message = String.Format("vJoy Enabled: {0}\nvJoy Version Number: {1}\n",
                    joystick.vJoyEnabled(),
                    joystick.GetvJoySerialNumberString());

                // Check there are output buttons available
                var virtualButtons = HardwareInfo.GetOutputButtons();
                diagnostics.Message += String.Format("Virtual Buttons: {0}\n", virtualButtons.Count);

                // Check there are output axes available
                var virtualAxes = HardwareInfo.GetOutputAxes();
                diagnostics.Message += String.Format("Virtual Axes: {0}\n", virtualAxes.Count);

                if ((virtualButtons.Count == 0) && (virtualAxes.Count == 0)){
                    diagnostics.Healthy = false;
                    diagnostics.Message = "Ensure that you have at least one virtual button or axis available in vJoy\n\n" + diagnostics.Message;
                }

            }



            Debug.WriteLine(diagnostics.Message);
            return diagnostics;
        }
    }
}