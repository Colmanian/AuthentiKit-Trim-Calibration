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
        uint _vJoyId;
        uint _vJoyAxisNumber;
        long _outputMax;
        int _outputAxisPosition;

        bool _flipped;

        public AxisToButtonProcessor(InputAxis inputAxis,
            OutputButton outputButtonA,
            OutputButton outputButtonB,
            List<int> gateways)
        {
            _inputAxisId = inputAxis.AxisId;
            _inputMin = inputAxis.Min;
            _inputMax = inputAxis.Max;
            _priorInputPercent = 0;

            Debug.WriteLine("Min: {0}, Max: {1}", _inputMin, _inputMax);

            gateways.Sort();
            _gateways = gateways;
        }
        internal void Process(int input)
        {
            int inputPercent = GetInputAsPercent(input);

            foreach (var gateway in _gateways)
            {
                if (inputPercent == _priorInputPercent)
                {
                    // There's been no transition and you might be resting on a gateway, so ignore this.
                }
                else if (inputPercent <= gateway && gateway <= _priorInputPercent)
                {
                    Debug.WriteLine("Moving <<< Through {0}", gateway);
                }
                else if (_priorInputPercent <= gateway && gateway <= inputPercent)
                {
                    Debug.WriteLine("Moving >>> Through {0}", gateway);
                }
            }
            Debug.WriteLine("{0}%", inputPercent);
            _priorInputPercent = inputPercent;
        }

        private int GetInputAsPercent(int input)
        {
            double outputPercentage = 100.0 * (input - _inputMin) / (_inputMax - _inputMin);
            return (int)outputPercentage;
        }

        internal void CleanUp()
        {
            _joystick.RelinquishVJD(_vJoyId);
        }

        public int getAxisId()
        {
            return _inputAxisId;
        }
    }
}
