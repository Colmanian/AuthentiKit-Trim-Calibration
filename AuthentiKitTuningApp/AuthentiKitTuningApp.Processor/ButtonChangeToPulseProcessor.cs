using AuthentiKitTuningApp.Common.Model;
using System;
using System.Diagnostics;
using vJoyInterfaceWrap;

namespace AuthentiKitTuningApp.Processor
{
    class ButtonChangeToPulseProcessor
    {
        private vJoy _joystick;
        private uint _vJoyId;
        private uint _vJoyButtonNumberA;
        private uint _vJoyButtonNumberB;
        private int _pulseDuration; //ms

        private bool _priorInputButtonState;
        private bool _pulsing;
        private long _pulseStart;

        public ButtonChangeToPulseProcessor(OutputButton outputButtonA, OutputButton outputButtonB, int pulseDuration)
        {
            _pulseDuration = pulseDuration; // ms
            _vJoyId = outputButtonA.VJoyDevice;
            _vJoyButtonNumberA = outputButtonA.VJoyItem;
            _vJoyButtonNumberB = outputButtonB.VJoyItem;
            _pulsing = false;
            _pulseStart = 0;
            _joystick = new vJoy();
            if (!_joystick.vJoyEnabled())
            {
                Debug.WriteLine("vJoy driver not enabled: Failed Getting vJoy attributes.\n");
            }
            else
            {
                Debug.WriteLine("vJoy Enabled: {0}\nProduct :{1}\nVersion Number:{2}\n", _joystick.GetvJoyManufacturerString(), _joystick.GetvJoyProductString(), _joystick.GetvJoySerialNumberString());
            }


            // Acquire the target A
            VjdStat status = _joystick.GetVJDStatus(_vJoyId);
            bool acquired = _joystick.AcquireVJD(_vJoyId);
            if (!acquired)
            {
                Debug.WriteLine("Failed to acquire vJoy device number {0} because {1}", _vJoyId, status.ToString());
                return;
            }
            else
            {
                Debug.WriteLine("Acquired vJoy device number {0}", _vJoyId);

                // Initalise
                SetOutputs(false, false);
            }
        }

        internal void Process(bool inputButtonState, long elapsedMilliseconds)
        {
            if ((inputButtonState == _priorInputButtonState) && !_pulsing)
                return;

            if (!_pulsing)
            {
                // Start Pulsing 
                _pulsing = true;
                _pulseStart = elapsedMilliseconds;
                if (inputButtonState)
                {
                    // Button has tranistioned from OFF to ON
                    SetOutputs(true, false);
                }
                else
                {
                    // Button has tranistioned from ON to OFF
                    SetOutputs(false, true);
                }
            }
            else if (elapsedMilliseconds > (_pulseStart + _pulseDuration))
            {
                // Stop Pulsing
                _pulsing = false;
                SetOutputs(false, false);
            }
            _priorInputButtonState = inputButtonState;
        }
        internal void SetOutputs(bool stateA, bool stateB)
        {
            _joystick.SetBtn(stateA, _vJoyId, _vJoyButtonNumberA);
            _joystick.SetBtn(stateB, _vJoyId, _vJoyButtonNumberB);
        }
    }
}
