using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vJoyInterfaceWrap;

namespace AuthentiKitTrimCalibration.DataAccess
{
    class ButtonProcessor
    {
        int _multiplier;
        int _holdThresholdStart;
        int _holdThresholdStop;

        public ButtonProcessor(int multiplier, int holdThresholdStart, int holdThresholdStop)
        {
            _multiplier = multiplier;
            _holdThresholdStart = holdThresholdStart;
            _holdThresholdStop = holdThresholdStop;
        }

        internal void Process(bool buttonAState, long elapsedMilliseconds)
        {
            Debug.WriteLine("Button {0} now {1} at {2}ms", buttonAState, buttonAState, elapsedMilliseconds);
        }
    }
}
