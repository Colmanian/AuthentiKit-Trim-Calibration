using AuthentiKitTuningApp.Common.Model;
using System.Collections.Generic;
using System.Diagnostics;
using vJoyInterfaceWrap;

namespace AuthentiKitTuningApp.Processor
{
    class RotaryProcessor
    {
        // Outputs
        vJoy _joystick;
        uint _vJoyId;
        List<uint> _vJoyButtonNumbers;

        // State Variables
        bool _inputPriorStateA = false;
        bool _inputPriorStateB = false;

        // Output Parameters
        const int PULSE_LENGTH = 1000; //ms
        bool _looping;
        uint _range;
        int _currentButtonIndex;
        long _pulseStart;
        private bool _firstRun;
        private bool _normalRunning = false;

        public RotaryProcessor(
            OutputButton rangeStart,
            OutputButton initialButton,
            int range,
            bool looping)
        {
            if (range < 3)
            {
                Debug.WriteLine("ERROR: Range must be at least 3");
                return;
            }
            _range = (uint)range;
            _looping = looping;

            // Initialise the vJoy Output Device
            if (rangeStart.VJoyDevice != initialButton.VJoyDevice)
            {
                Debug.WriteLine("ERROR: Output Buttons are on the different vJoy Devices. This is not supported.");
                return;
            }

            // Make sure default button is in range
            if ((initialButton.VJoyItem < rangeStart.VJoyItem) || (initialButton.VJoyItem >= rangeStart.VJoyItem + range))
            {
                Debug.WriteLine("ERROR: Default/inital button is not in range");
                return;
            }

            _vJoyId = rangeStart.VJoyDevice;
            _joystick = new vJoy();
            if (!_joystick.vJoyEnabled())
            {
                Debug.WriteLine("ERROR: vJoy driver not enabled: Failed Getting vJoy attributes.\n");
                return;
            }
            else
            {
                Debug.WriteLine("vJoy Enabled: {0}\nProduct :{1}\nVersion Number:{2}\n", _joystick.GetvJoyManufacturerString(), _joystick.GetvJoyProductString(), _joystick.GetvJoySerialNumberString());
            }
            VjdStat vJoyStatus = _joystick.GetVJDStatus(_vJoyId);
            bool vJoyAcquired = _joystick.AcquireVJD(_vJoyId);
            if (!vJoyAcquired)
            {
                Debug.WriteLine("ERROR: Failed to acquire vJoy device number {0} because {1}", _vJoyId, vJoyStatus.ToString());
                return;
            }
            else
            {
                Debug.WriteLine("Acquired vJoy device number {0}", _vJoyId);
            }

            // Initialize the output range
            _vJoyButtonNumbers = new List<uint>(range);
            for (uint i = 0; i < range; i++)
            {
                _vJoyButtonNumbers.Add(rangeStart.VJoyItem + i);
            }
            _currentButtonIndex = (int)(initialButton.VJoyItem - rangeStart.VJoyItem);

            foreach (var vJoyButtonNumber in _vJoyButtonNumbers)
            {
                SetOutputByVJoyButtonNumber(vJoyButtonNumber, false);
            }
            _firstRun = true;
        }

        internal void Process(bool buttonStateA, bool buttonStateB, long elapsedMilliseconds)
        {
            // Pulse the default output on first run
            if (!_normalRunning)
            {
                if (_firstRun)
                {
                    SetOutputByListIndex(_currentButtonIndex, true);
                    _pulseStart = elapsedMilliseconds;
                    _firstRun = false;
                }
                if (elapsedMilliseconds > (_pulseStart + PULSE_LENGTH))
                {
                    SetOutputByListIndex(_currentButtonIndex, false);
                    _normalRunning = true;
                }
            }
            else
            {
                // buttonStateA turns on so increment
                if (buttonStateA && !_inputPriorStateA)
                {
                    _currentButtonIndex = (_currentButtonIndex >= _vJoyButtonNumbers.Count - 1) ?
                                          (_looping ? 0 : _vJoyButtonNumbers.Count - 1) :
                                          _currentButtonIndex + 1;
                    Debug.WriteLine("Button A Pressed. Current index {0} (vJoy {1})\n", _currentButtonIndex, _vJoyButtonNumbers[_currentButtonIndex]);
                }

                // buttonStateB turns on so decrement
                if (buttonStateB && !_inputPriorStateB)
                {
                    _currentButtonIndex = (_currentButtonIndex == 0) ?
                                          (_looping ? _vJoyButtonNumbers.Count - 1 : 0) :
                                          _currentButtonIndex - 1;
                    Debug.WriteLine("Button B Pressed. Current index {0} (vJoy {1})\n", _currentButtonIndex, _vJoyButtonNumbers[_currentButtonIndex]);
                }

                // pass through to the relevant output to save having to pulse
                SetOutputByListIndex(_currentButtonIndex, buttonStateA || buttonStateB);

                _inputPriorStateA = buttonStateA;
                _inputPriorStateB = buttonStateB;
            }
        }

        internal void CleanUp()
        {
            _joystick.RelinquishVJD(_vJoyId);
        }

        internal void SetOutputByListIndex(int buttonIndex, bool state)
        {
            if (buttonIndex < _vJoyButtonNumbers.Count)
            {
                SetOutputByVJoyButtonNumber(_vJoyButtonNumbers[buttonIndex], state);
            }
        }

        internal void SetOutputByVJoyButtonNumber(uint vJoyButtonNumber, bool state)
        {
            _joystick?.SetBtn(state, _vJoyId, vJoyButtonNumber);
        }
    }
}
