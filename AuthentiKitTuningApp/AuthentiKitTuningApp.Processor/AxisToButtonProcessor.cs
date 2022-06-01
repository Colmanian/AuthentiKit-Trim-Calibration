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

            Debug.WriteLine("Min: {0}, Max: {1}", _inputMin, _inputMax);

            gateways.Sort();
            foreach (var gateway in gateways)
            {
                if ((gateway > 0) && (gateway < 100))
                {
                    Debug.WriteLine("Gateway: {0}", gateway);
                }
            }


        }
        internal void Process(int inputValue)
        {
            Debug.WriteLine("I'm alive but useless");
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
