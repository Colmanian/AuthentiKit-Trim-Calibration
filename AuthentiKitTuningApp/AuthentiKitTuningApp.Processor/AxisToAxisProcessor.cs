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
    class AxisToAxisProcessor
    {
        int _inputAxisId;
        int _inputMin;
        int _inputMax;

        vJoy _joystick;
        uint _vJoyId;
        uint _vJoyAxisNumber;
        long _outputMax;
        int _outputAxisPosition;

        bool _flipped;

        public AxisToAxisProcessor(InputAxis inputAxis, OutputAxis outputAxis, bool flipped)
        {
            _inputAxisId = inputAxis.AxisId;
            _inputMin = inputAxis.Min;
            _inputMax = inputAxis.Max;
            _flipped = flipped;
            Debug.WriteLine("Min: {0}, Max: {1}, Flipped: {2}", _inputMin, _inputMax, _flipped);

            // Acquire Output Axis
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

            _joystick.GetVJDAxisMax(_vJoyId, (HID_USAGES)_vJoyAxisNumber, ref _outputMax);
            Debug.WriteLine("Max value of VJID {0} axis {1} is {2}", _vJoyId, (HID_USAGES)_vJoyAxisNumber, _outputMax);

            // Initialise Output
            SetOutputAxisUsingToInputAxisScale(0);

        }
        internal void Process(int inputValue)
        {
            int outputValue = inputValue;
            if (_flipped)
            {
                outputValue = _inputMax - inputValue - _inputMin;
            }
            SetOutputAxisUsingToInputAxisScale(outputValue);
        }

        internal void CleanUp()
        {
            _joystick.RelinquishVJD(_vJoyId);
        }

        /*
         * e.g. if the input range was 0-100 but the output range was 0-1000, you'd call this function with the argument of 50, to set the output to 500.
         */
        internal void SetOutputAxisUsingToInputAxisScale(int setting)
        {
            if (_joystick != null)
            {
                // Scale the output relative to the input
                double outputPercentage = 1.0 * (setting - _inputMin) / (_inputMax - _inputMin);
                _outputAxisPosition = (int)(outputPercentage * _outputMax);
                if (_outputAxisPosition > _outputMax)
                {
                    _outputAxisPosition = (int)_outputMax;
                }
                else if (_outputAxisPosition < 0)
                {
                    _outputAxisPosition = 0;
                }
                _joystick.SetAxis(_outputAxisPosition, _vJoyId, (HID_USAGES)_vJoyAxisNumber);
                Debug.WriteLine("Moving vJoy {0} Axis {1} to {2}", _vJoyId, (HID_USAGES)_vJoyAxisNumber, _outputAxisPosition);
            }
        }
        public int getAxisId()
        {
            return _inputAxisId;
        }
    }
}
