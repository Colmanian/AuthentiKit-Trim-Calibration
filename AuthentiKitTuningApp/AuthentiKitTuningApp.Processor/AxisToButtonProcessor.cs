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
    class AxisToButtonProcessor
    {
        int _inputAxisId;
        int _inputMin;
        int _inputMax;
        int _priorInputPercent;

        List<int> _gateways;

        vJoy _joystick;
        uint _vJoyIdA;
        uint _vJoyButtonNumberA;
        uint _vJoyIdB;
        uint _vJoyButtonNumberB;

        const int PULSE_LENGTH = 500; //ms
        long _pulseStartA;
        long _pulseStartB;
        bool _isPulsingA;
        bool _isPulsingB;

        public AxisToButtonProcessor(InputAxis inputAxis,
            OutputButton outputButtonA,
            OutputButton outputButtonB,
            List<int> gateways)
        {
            // Initalise input variables
            _inputAxisId = inputAxis.AxisId;
            _inputMin = inputAxis.Min;
            _inputMax = inputAxis.Max;
            _priorInputPercent = 0;

            // Initialise the gatway settings
            gateways.Sort();
            _gateways = gateways;
            _pulseStartA = 0;
            _pulseStartB = 0;

            // Initialise the Output Buttons
            _vJoyIdA = outputButtonA.VJoyDevice;
            _vJoyButtonNumberA = outputButtonA.VJoyItem;
            _vJoyIdB = outputButtonB.VJoyDevice;
            _vJoyButtonNumberB = outputButtonB.VJoyItem;
            _joystick = new vJoy();
            if (!_joystick.vJoyEnabled())
            {
                Debug.WriteLine("vJoy driver not enabled: Failed Getting vJoy attributes.\n");
            }
            else
            {
                Debug.WriteLine("Vendor: {0}\nProduct :{1}\nVersion Number:{2}\n", _joystick.GetvJoyManufacturerString(), _joystick.GetvJoyProductString(), _joystick.GetvJoySerialNumberString());
            }
            // Acquire the target A
            VjdStat statusA = _joystick.GetVJDStatus(_vJoyIdA);
            if ((statusA == VjdStat.VJD_STAT_OWN) || ((statusA == VjdStat.VJD_STAT_FREE) && (!_joystick.AcquireVJD(_vJoyIdA))))
            {
                Debug.WriteLine("Failed to acquire vJoy device number {0}.", _vJoyIdA);
                return;
            }
            else
                Debug.WriteLine("Acquired: vJoy device number {0}.", _vJoyIdA);
            _joystick.ResetVJD(_vJoyIdA);
            // Acquire the target B if necessary
            if (_vJoyIdB != _vJoyIdA)
            {
                VjdStat statusB = _joystick.GetVJDStatus(_vJoyIdB);
                if ((statusB == VjdStat.VJD_STAT_OWN) || ((statusB == VjdStat.VJD_STAT_FREE) && (!_joystick.AcquireVJD(_vJoyIdB))))
                {
                    Debug.WriteLine("Failed to acquire vJoy device number {0}.", _vJoyIdB);
                    return;
                }
                else
                    Debug.WriteLine("Acquired: vJoy device number {0}.", _vJoyIdB);
                _joystick.ResetVJD(_vJoyIdB);
            }

            SetOutputA(false);
            SetOutputB(false);
        }
        internal void Process(int input, long elapsedMilliseconds)
        {
            int inputPercent = GetInputAsPercent(input);

            foreach (var gateway in _gateways)
            {
                if (inputPercent == _priorInputPercent)
                {
                    // There's been no transition and you might be resting on a gateway, so ignore this.
                }
                else if (_priorInputPercent <= gateway && gateway <= inputPercent)
                {
                    Debug.WriteLine("Moving >>> Through {0} from {1}%", gateway, inputPercent);
                    PulseOnA(elapsedMilliseconds);
                }
                else if (inputPercent <= gateway && gateway <= _priorInputPercent)
                {
                    Debug.WriteLine("Moving <<< Through {0} from {1}%", gateway, inputPercent);
                    SetOutputB(true);
                    PulseOnB(elapsedMilliseconds);
                }
                CheckPulseOffA(elapsedMilliseconds);
                CheckPulseOffB(elapsedMilliseconds);
            }
            _priorInputPercent = inputPercent;
        }

        private void PulseOnA(long elapsedMilliseconds)
        {
            SetOutputA(true);
            _isPulsingA = true;
            _pulseStartA = elapsedMilliseconds;
        }
        private void PulseOnB(long elapsedMilliseconds)
        {
            SetOutputB(true);
            _isPulsingB = true;
            _pulseStartB = elapsedMilliseconds;
        }
        private void CheckPulseOffA(long elapsedMilliseconds)
        {
            if (_isPulsingA && ((elapsedMilliseconds - _pulseStartA) > PULSE_LENGTH))
            {
                SetOutputA(false);
            }
        }
        private void CheckPulseOffB(long elapsedMilliseconds)
        {
            if (_isPulsingB && ((elapsedMilliseconds - _pulseStartB) > PULSE_LENGTH))
            {
                SetOutputB(false);
            }
        }

        private int GetInputAsPercent(int input)
        {
            double outputPercentage = 100.0 * (input - _inputMin) / (_inputMax - _inputMin);
            return (int)outputPercentage;
        }
        internal void CleanUp()
        {
            _joystick.RelinquishVJD(_vJoyIdA);
            if (_vJoyIdA != _vJoyIdB)
            {
                _joystick.RelinquishVJD(_vJoyIdB);
            }
        }
        public int getAxisId()
        {
            return _inputAxisId;
        }
        internal void SetOutputA(bool state)
        {
            if (_joystick != null)
            {
                _joystick.SetBtn(state, _vJoyIdA, _vJoyButtonNumberA);
            }
        }
        internal void SetOutputB(bool state)
        {
            if (_joystick != null)
            {
                _joystick.SetBtn(state, _vJoyIdB, _vJoyButtonNumberB);
            }
        }
    }
}
