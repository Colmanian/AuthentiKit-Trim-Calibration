namespace MappingManager.Common.Model
{
    public class MappingDTO
    {
        public MappingDTO()
        {
            Name = "";
            TypeId = MappingType.AXIS;
            Active = false;
            OutputChannel = new();
            ButtonMultiplier = 1;
            AxisSensitivity = 1;
            InputChannelA = new();
            InputChannelB = new();
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
        public InputChannel InputChannelA { get; set; } // Both
        public InputChannel InputChannelB { get; set; } // Axis Only
        public string ResetCommand { get; set; } // Axis Only
        public int HoldThresholdStart { get; set; } // Button Only
        public int HoldThresholdStop { get; set; } // Button Only
        public bool Errored { get; set; }
        public string ErrorMessage { get; set; }
    }
}