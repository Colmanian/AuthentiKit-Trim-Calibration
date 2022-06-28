using AuthentiKitTuningApp.Common.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vJoyInterfaceWrap;

namespace AuthentiKitTuningApp.Processor
{
    class ButtonToAxisProcessor
    {
        int _sensitivity;
        vJoy _joystick;
        uint _vJoyId;
        uint _vJoyAxisNumber;
        long _maxAxisValue;
        int _axisPosition;
        bool _priorAState;
        bool _priorBState;

        long _previousATime;
        long _previousBTime;

        readonly long BUTTON_FILTER = 0; // Ignore new button presses less than this (ms)

        public ButtonToAxisProcessor(int axisSensitivity, OutputAxis outputAxis)
        {
            Debug.WriteLine("Multiplier is {0}", axisSensitivity);
            _sensitivity = axisSensitivity;
            _vJoyId = outputAxis.VJoyDevice;
            _vJoyAxisNumber = outputAxis.VJoyItem;
            _joystick = new vJoy();
            if (!_joystick.vJoyEnabled())
            {
                Debug.WriteLine("vJoy driver not enabled: Failed Getting vJoy attributes.\n");
            }
            else
            {
                Debug.WriteLine("Vendor: {0}\nProduct :{1}\nVersion Number:{2}\n", _joystick.GetvJoyManufacturerString(), _joystick.GetvJoyProductString(), _joystick.GetvJoySerialNumberString());
            }

            // Acquire the target (Not currently used really...)
            VjdStat status = _joystick.GetVJDStatus(_vJoyId);
            Debug.WriteLine("vJoy Status: " + status.ToString());
            if ((status == VjdStat.VJD_STAT_OWN) || ((status == VjdStat.VJD_STAT_FREE) && (!_joystick.AcquireVJD(_vJoyId))))
            {
                Debug.WriteLine("Failed to acquire vJoy device number {0}.", _vJoyId);
            }

            _joystick.GetVJDAxisMax(_vJoyId, (HID_USAGES)_vJoyAxisNumber, ref _maxAxisValue);
            Debug.WriteLine("Max value of VJID {0} axis {1} is {2}", _vJoyId, (HID_USAGES)_vJoyAxisNumber, _maxAxisValue);
            Centre();
        }
        internal void Process(bool buttonAState, bool buttonBState, long elapsedMilliseconds)
        {


            if (_priorAState != buttonAState)
            {
                var timeSinceLast = (elapsedMilliseconds - _previousATime);
                if (buttonAState && (timeSinceLast > BUTTON_FILTER)) // filter out spureous output
                {
                    MoveAxisBy(_sensitivity);
                    _previousATime = elapsedMilliseconds;
                    Debug.WriteLine("+{0} : {1}ms", _sensitivity, timeSinceLast);
                }
                _priorAState = buttonAState;
            }

            if (_priorBState != buttonBState)
            {
                var timeSinceLast = (elapsedMilliseconds - _previousBTime);
                if (buttonBState && (timeSinceLast > BUTTON_FILTER))
                {
                    MoveAxisBy(-_sensitivity);
                    _previousBTime = elapsedMilliseconds;
                    Debug.WriteLine("-{0} : {1}ms", _sensitivity, timeSinceLast);
                }
                _priorBState = buttonBState;
            }
        }

        internal void CleanUp()
        {
            _joystick.RelinquishVJD(_vJoyId);
        }

        internal void MoveAxisBy(int movement)
        {
            if (_joystick != null)
            {
                _axisPosition += movement;
                if (_axisPosition > _maxAxisValue)
                {
                    _axisPosition = (int)_maxAxisValue;
                }
                else if (_axisPosition < 0)
                {
                    _axisPosition = 0;
                }
                _joystick.SetAxis(_axisPosition, _vJoyId, (HID_USAGES)_vJoyAxisNumber);
                Debug.WriteLine("Moving vJoy {0} Axis {1} to {2}", _vJoyId, (HID_USAGES)_vJoyAxisNumber, _axisPosition);
            }
        }

        internal void Centre()
        {
            if (_joystick != null)
            {
                Debug.WriteLine("Centring vJoy {0} Axis {1} to half of {2}", _vJoyId, _vJoyAxisNumber, _maxAxisValue);
                _axisPosition = (int)(_maxAxisValue / 2);
                MoveAxisBy(0);
            }
        }
    }
}
