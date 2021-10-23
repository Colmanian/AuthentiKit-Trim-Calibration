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
    class EncoderAxisProcessor
    {
        int _encoderPPR;
        float _revsInPerRevsOut;
        vJoy _joystick;
        uint _vJoyId;
        uint _vJoyAxisNumber;
        long _maxAxisValue;
        int _axisPosition;
        int _positiveDirection;
        int _negativeDirection;

        public EncoderAxisProcessor(int encoderPPR, float revsInPerRevsOut, OutputAxis outputAxis)
        {
            Debug.WriteLine("Encoder PPR is {0} and Revs In per Out is {1}", encoderPPR, revsInPerRevsOut);
            _encoderPPR = encoderPPR;
            _revsInPerRevsOut = revsInPerRevsOut;
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
            int seqNumber = getEncoderSequenceNumber(buttonAState, buttonBState);

            if (seqNumber == _positiveDirection)
            {
                MoveAxisBy(200);
                Debug.WriteLine("Moving on UP!");

            } else if (seqNumber == _negativeDirection)
            {
                MoveAxisBy(-200);
                Debug.WriteLine("Moving on DOWN!");
            }

            // Work out what the next sequence number wil be if you extrapolate in the positve and negative directions
            _positiveDirection = seqNumber + 1;
            if (_positiveDirection > 3)
                _positiveDirection = 0;
            _negativeDirection = seqNumber - 1;
            if (_negativeDirection < 0)
                _negativeDirection = 3;
        }

        private int getEncoderSequenceNumber(bool buttonAState, bool buttonBState)
        {
            /*
             * This looks a little confusing but it's just a standard 2 bit encoder sequence
             * 00, 10, 11, 01, which I map to 0, 1, 2, 3 resectively 
             */
            int number = 0;
            if (buttonAState && buttonBState)
            {
                number = 2;
            }
            else if (buttonAState)
            {
                number = 1;
            }
            else if (buttonBState)
            {
                number = 3;
            }
            return number;
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
