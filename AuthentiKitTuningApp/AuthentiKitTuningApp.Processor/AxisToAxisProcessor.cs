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
        
        vJoy _joystick;
        uint _vJoyId;
        uint _vJoyAxisNumber;
        long _maxOutputAxisValue;
        int _outputAxisPosition;        
       
        bool _flipped;

        public AxisToAxisProcessor(InputAxis inputAxis, OutputAxis outputAxis, bool flipped)
        {
            _inputAxisId = inputAxis.AxisId;
            _flipped = flipped;
            Debug.WriteLine("Flipped: {0}", _flipped);

            // Acquire Input Axis
            //TODO

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

            _joystick.GetVJDAxisMax(_vJoyId, (HID_USAGES)_vJoyAxisNumber, ref _maxOutputAxisValue);
            Debug.WriteLine("Max value of VJID {0} axis {1} is {2}", _vJoyId, (HID_USAGES)_vJoyAxisNumber, _maxOutputAxisValue);
            Centre();
        }
        internal void Process(int inputAxisValue)
        {
           Debug.WriteLine(inputAxisValue);
        }

        internal void CleanUp()
        {
            _joystick.RelinquishVJD(_vJoyId);
        }

        internal void MoveAxisBy(int movement)
        {
            if (_joystick != null)
            {
                _outputAxisPosition += movement;
                if (_outputAxisPosition > _maxOutputAxisValue)
                {
                    _outputAxisPosition = (int)_maxOutputAxisValue;
                }
                else if (_outputAxisPosition < 0)
                {
                    _outputAxisPosition = 0;
                }
                _joystick.SetAxis(_outputAxisPosition, _vJoyId, (HID_USAGES)_vJoyAxisNumber);
                Debug.WriteLine("Moving vJoy {0} Axis {1} to {2}", _vJoyId, (HID_USAGES)_vJoyAxisNumber, _outputAxisPosition);
            }
        }

        internal void Centre()
        {
            if (_joystick != null)
            {
                Debug.WriteLine("Centring vJoy {0} Axis {1} to half of {2}", _vJoyId, _vJoyAxisNumber, _maxOutputAxisValue);
                _outputAxisPosition = (int)(_maxOutputAxisValue / 2);
                MoveAxisBy(0);
            }
        }
        public int getAxisId()
        {
            return _inputAxisId;
        }
    }
}
