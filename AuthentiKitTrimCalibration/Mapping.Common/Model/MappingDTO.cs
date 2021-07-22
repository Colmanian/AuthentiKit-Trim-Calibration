using System;

namespace MappingManager.Common.Model
{
    //TODO Refactor to use polymorphism 
    public class MappingDTO 
    { 
        public enum MappingType
        {
            Button,
            Axis
        }

        public string Name { get; set; } // Both
        public MappingType Type { get; set; } // Both
        public bool Active { get; set; } // Both
        public int OutputId { get; set; } // Both
        public int Multiplier { get; set; } // Both
        public int InputID_A { get; set; } // Both
        public int InputID_B { get; set; } // Axis Only
        public string ResetCommand { get; set; } // Axis Only
        public int HoldThresholdStart { get; set; } // Button Only
        public int HoldThresholdStop { get; set; } // Button Only
        public bool Errored { get; set; }
        public string ErrorMessage { get; set; }
    }
}