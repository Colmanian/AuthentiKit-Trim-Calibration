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
    class AxisProcessor
    {
        int _multiplier;
        vJoy _joystick;
        uint _vJoyId;
        uint _vJoyAxisNumber;
        bool _priorAState;
        bool _priorBState;

        public AxisProcessor(int multiplier, OutputAxis outputAxis)
        {
            _multiplier = multiplier;
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

        internal void Process(bool buttonAState, bool buttonBState)
        {

            if (_priorAState != buttonAState)
            {
                if (buttonAState)
                {
                    MoveAxisBy(_multiplier);
                }
                _priorAState = buttonAState;
            }

            if (_priorBState != buttonBState)
            {
                if (buttonBState)
                {
                    MoveAxisBy(-_multiplier);
                }
                _priorBState = buttonBState;
            }
        }

        internal void MoveAxisBy(int movement)
        {
            if (_joystick != null)
            {
                Debug.WriteLine("Moving vJoy {0} Axis {1} by {2}", _vJoyId, _vJoyAxisNumber, movement);
                //TODO
            }
        }

        internal void Centre()
        {
            if (_joystick != null)
            {
                Debug.WriteLine("Centring vJoy {0} Axis {1}", _vJoyId, _vJoyAxisNumber);
                //TODO
            }
        }
    }
}
