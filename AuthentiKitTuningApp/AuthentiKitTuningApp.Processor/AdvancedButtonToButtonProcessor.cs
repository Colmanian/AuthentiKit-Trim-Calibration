using AuthentiKitTuningApp.Common.Model;
using System.Diagnostics;
using vJoyInterfaceWrap;

namespace AuthentiKitTuningApp.Processor
{
    class AdvancedButtonToButtonProcessor
    {
        bool _latched;
        bool _holding;

        vJoy _joystick;
        uint _vJoyId;
        uint _vJoyButtonNumberA;
        uint _vJoyButtonNumberB;

        bool _priorInputButtonState;
        bool _outputtingOnA; // If true we're outputting on A, if false we're outputting on B
        bool _outputA; // Output A is On
        bool _outputB; // Output B is On

        const int PULSE_LENGTH = 60; //ms

        public AdvancedButtonToButtonProcessor(bool holding, OutputButton outputButtonA, OutputButton outputButtonB)
        {
            _outputA = false;
            _outputB = false;
            _latched = false; // This option would implement what I consider to be ordinary latching
            _holding = holding; // This option is what the Authentikit Project actually needed 
            if (_latched) { _outputA = true; }
            _vJoyId = outputButtonA.VJoyDevice;
            _vJoyButtonNumberA = outputButtonA.VJoyItem;
            _vJoyButtonNumberB = outputButtonB.VJoyItem;
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
                SetOutput(holding, false);
            }
        }

        internal void Process(bool inputButtonState, long elapsedMilliseconds)
        {
            // If button has turned on or off
            if (_priorInputButtonState != inputButtonState)
            {
                if (_holding)
                {
                    SetOutput(!inputButtonState, inputButtonState);
                }
                else
                {
                    // If button is now on
                    if (inputButtonState)
                    {
                        if (_outputtingOnA)
                        {
                            _outputA = true;
                            _outputB = false;
                        }
                        else
                        {
                            _outputA = false;
                            _outputB = true;
                        }
                    }
                    // Else if button is now off
                    else
                    {
                        _outputtingOnA = !_outputtingOnA;
                        if (!_latched)
                        {
                            _outputA = false;
                            _outputB = false;
                        }
                    }
                    SetOutput(_outputA, _outputB);
                }
                _priorInputButtonState = inputButtonState;
            }
        }
        internal void SetOutput(bool stateA, bool stateB)
        {
            _joystick?.SetBtn(stateA, _vJoyId, _vJoyButtonNumberA);
            _joystick?.SetBtn(stateB, _vJoyId, _vJoyButtonNumberB);
        }
    }
}
