using System.Collections.Generic;
using System.Linq;

namespace MappingManager.Common.Model
{
    public class MappingDTO
    {
        public MappingDTO()
        {
            Name = "";
            TypeId = MappingType.BUTTON_TO_AXIS;
            Active = false;
            OutputChannelA = new();
            OutputChannelB = new();
            ButtonMultiplier = 1;
            AxisSensitivity = 1;
            EncoderPPR = 24;
            RevsInPerRevsOut = 4;
            InputButtonA = new();
            InputButtonB = new();
            InputAxis = new();
            ResetCommand = "";
            HoldThresholdStart = 500;
            HoldThresholdStop = 1000;
            Flipped = false;
            Errored = false;
            ErrorMessage = "";
            GatewayEnabled1 = false;
            GatewayEnabled2 = false;
            GatewayEnabled3 = false;
            GatewayEnabled4 = false;
            GatewayEnabled5 = false;
            Gateway1 = 0;
            Gateway2 = 0;
            Gateway3 = 0;
            Gateway4 = 0;
            Gateway5 = 0;
        }

        public string Name { get; set; } // Both
        public int TypeId { get; set; } // Both
        public bool Active { get; set; } // Both
        public OutputChannel OutputChannelA { get; set; } // Both
        public OutputChannel OutputChannelB { get; set; } // Both
        public int OutputChannelAId { get; set; } // Both
        public int OutputChannelBId { get; set; } // Both
        public int ButtonMultiplier { get; set; } // Button Only
        public int AxisSensitivity { get; set; } // Axis Only
        public int EncoderPPR { get; set; } // Encoder Axis Only
        public float RevsInPerRevsOut { get; set; } // Encoder Axis Only
        public InputButton InputButtonA { get; set; } // Button and Axis
        public InputButton InputButtonB { get; set; } // Axis Only
        public InputAxis InputAxis { get; set; } // AxisToAxis Only
        public string ResetCommand { get; set; } // Axis Only
        public int HoldThresholdStart { get; set; } // Button Only
        public int HoldThresholdStop { get; set; } // Button Only
        public bool Flipped { get; set; }// AxisToAxis Only
        public bool Errored { get; set; }
        public string ErrorMessage { get; set; }
        public bool GatewayEnabled1 { get; set; }
        public bool GatewayEnabled2 { get; set; }
        public bool GatewayEnabled3 { get; set; }
        public bool GatewayEnabled4 { get; set; }
        public bool GatewayEnabled5 { get; set; }
        public int Gateway1 { get; set; }
        public int Gateway2 { get; set; }
        public int Gateway3 { get; set; }
        public int Gateway4 { get; set; }
        public int Gateway5 { get; set; }

        public List<int> Gateways
        {
            get
            {
                List<int> list = new List<int>();
                if ((GatewayEnabled1) && (1 <= Gateway1 && Gateway1 <= 100))
                    list.Add(Gateway1);
                if ((GatewayEnabled2) && (1 <= Gateway2 && Gateway2 <= 100))
                    list.Add(Gateway2);
                if ((GatewayEnabled3) && (1 <= Gateway3 && Gateway3 <= 100))
                    list.Add(Gateway3);
                if ((GatewayEnabled4) && (1 <= Gateway4 && Gateway4 <= 100))
                    list.Add(Gateway4);
                if ((GatewayEnabled5) && (1 <= Gateway5 && Gateway5 <= 100))
                    list.Add(Gateway5);
                list.Sort();
                return list.Distinct().ToList();
            }
        }
    }
}