using MappingManager.Common.Model;
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
        vJoy _joystick;
        uint _vJoyId;
        uint _vJoyButtonNumber;
        bool _priorState;

        const int OUT_PULSE_LENGTH = 30; //ms

        public ButtonProcessor(int multiplier, int holdThresholdStart, int holdThresholdStop, OutputButton outputButton)
        {
            _multiplier = multiplier;
            _holdThresholdStart = holdThresholdStart;
            _holdThresholdStop = holdThresholdStop;
            _vJoyId = outputButton.VJoyDevice;
            _vJoyButtonNumber = outputButton.VJoyItem;
            _joystick = new vJoy();
            if (!_joystick.vJoyEnabled())
            {
                Debug.WriteLine("vJoy driver not enabled: Failed Getting vJoy attributes.\n");
            }
            else
            {
                Debug.WriteLine("Vendor: {0}\nProduct :{1}\nVersion Number:{2}\n", _joystick.GetvJoyManufacturerString(), _joystick.GetvJoyProductString(), _joystick.GetvJoySerialNumberString());
            }
            // Acquire the target
            VjdStat status = _joystick.GetVJDStatus(_vJoyId);
            if ((status == VjdStat.VJD_STAT_OWN) || ((status == VjdStat.VJD_STAT_FREE) && (!_joystick.AcquireVJD(_vJoyId))))
            {
                Console.WriteLine("Failed to acquire vJoy device number {0}.", _vJoyId);
                return;
            }
            else
                Console.WriteLine("Acquired: vJoy device number {0}.", _vJoyId);
            _joystick.ResetVJD(_vJoyId);
        }

        internal void Process(bool buttonAState, long elapsedMilliseconds)
        {
            if (_priorState != buttonAState)
            {
                Debug.WriteLine("Button {0} now {1} at {2}ms", _vJoyButtonNumber, buttonAState, elapsedMilliseconds);
                SetOutput(buttonAState);
                _priorState = buttonAState;
            }
        }

        internal void SetOutput(bool state)
        {
            if (_joystick != null)
            {
                Debug.WriteLine("Setting vJoy {0} Button {1} to {2}", _vJoyId, _vJoyButtonNumber, state);
                _joystick.SetBtn(state, _vJoyId, _vJoyButtonNumber);
            }                
        }
    }
}
