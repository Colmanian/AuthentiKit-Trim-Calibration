namespace MappingManager.Common.Model
{
    public class MappingDTO
    {
        public MappingDTO()
        {
            Name = "";
            TypeId = MappingType.BUTTON_TO_AXIS;
            Active = false;
            OutputChannel = new();
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
            Errored = false;
            ErrorMessage = "";
        }

        public string Name { get; set; } // Both
        public int TypeId { get; set; } // Both
        public bool Active { get; set; } // Both
        public OutputChannel OutputChannel { get; set; } // Both
        public int OutputChannelId { get; set; } // Both
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
        public bool Errored { get; set; }
        public string ErrorMessage { get; set; }
    }
}