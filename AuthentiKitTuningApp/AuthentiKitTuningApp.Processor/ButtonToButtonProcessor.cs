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
    class ButtonToButtonProcessor
    {
        int _multiplier;
        int _holdThresholdStart;
        int _holdThresholdStop;
        vJoy _joystick;
        uint _vJoyId;
        uint _vJoyButtonNumber;
        bool _priorState;
        long _priorButtonPressTime;
        bool _holdingOn;
        long _pulseStartTime;
        int _pulsesLeft;

        const int PULSE_LENGTH = 60; //ms

        public ButtonToButtonProcessor(int multiplier, int holdThresholdStart, int holdThresholdStop, OutputButton outputButton)
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
                Debug.WriteLine("Failed to acquire vJoy device number {0}.", _vJoyId);
                return;
            }
            else
                Debug.WriteLine("Acquired: vJoy device number {0}.", _vJoyId);
            _joystick.ResetVJD(_vJoyId);
        }

        internal void Process(bool buttonAState, long elapsedMilliseconds)
        {
            // If button has turned on or off
            if (_priorState != buttonAState)
            {
                // If button is now on
                if (buttonAState)
                {
                    var timeSinceLast = elapsedMilliseconds - _priorButtonPressTime;

                    if (!_holdingOn)
                    {
                        // Start Holding
                        if (_holdThresholdStart == 0)
                        {
                            Debug.WriteLine("*********** HOLD ON *********** ({0}ms)", timeSinceLast);
                            _holdingOn = true;
                            SetOutput(true);
                            _pulsesLeft = 0;
                        }
                        // Pulse
                        else if (timeSinceLast > _holdThresholdStart)
                        {
                            Debug.WriteLine("*********** PULSE ***********", timeSinceLast);
                            _pulsesLeft = _multiplier;
                            _pulseStartTime = elapsedMilliseconds;
                            SetOutput(true);
                            Debug.WriteLine("{0} ({1}ms)", _pulsesLeft, 0);
                        }
                        // Start Holding
                        else
                        {
                            Debug.WriteLine("*********** HOLD ON *********** ({0}ms)", timeSinceLast);
                            _holdingOn = true;
                            SetOutput(true);
                            _pulsesLeft = 0;
                        }
                    }
                    _priorButtonPressTime = elapsedMilliseconds;
                }
                _priorState = buttonAState;
            }

            // Ouptut Pulses
            if (_pulsesLeft > 0)
            {
                var timeSincePulseStart = elapsedMilliseconds - _pulseStartTime;
                if (timeSincePulseStart > 2 * PULSE_LENGTH)
                {
                    _pulsesLeft--;
                    if (_pulsesLeft > 0)
                    {
                        _pulseStartTime = elapsedMilliseconds;
                        SetOutput(true);
                        Debug.WriteLine("{0} on  ({1}ms)", _pulsesLeft, 0);
                    }
                }
                else if (timeSincePulseStart > PULSE_LENGTH)
                {
                    SetOutput(false);
                    Debug.WriteLine("{0} off ({1}ms)", _pulsesLeft, timeSincePulseStart);
                }
                else
                {
                    Debug.WriteLine("{0} mid pulse ({1}ms)", _pulsesLeft, timeSincePulseStart);
                }
            }

            // Check if holding should be turned off
            if (_holdingOn && ((elapsedMilliseconds - _priorButtonPressTime) > _holdThresholdStop))
            {
                Debug.WriteLine("*********** HOLD OFF *********** ({0}ms)", (elapsedMilliseconds - _priorButtonPressTime));
                _holdingOn = false;
                SetOutput(false);
            }
        }

        internal void SetOutput(bool state)
        {
            if (_joystick != null)
            {
                _joystick.SetBtn(state, _vJoyId, _vJoyButtonNumber);
            }
        }
    }
}
