using System;
using System.Collections.ObjectModel;

namespace AuthentiKitTuningApp.Common.Model
{
    public class MappingType
    {
        private const string AXIS_TO_STRING = "Remap Button to Virtual Axis";
        private const string BUTTON_TO_STRING = "Remap Button to Virtual Button";
        private const string ENCODER_TO_AXIS_STRING = "Remap Encoder to Virtual Axis";
        private const string ENCODER_TO_BUTTON_STRING = "Remap Encoder to Virtual Button";
        private const string AXIS_TO_AXIS_STRING = "Remap Axis to Virtual Axis";
        private const string AXIS_TO_BUTTON_STRING = "Remap Axis to Virtual Button";
        private const string ADVANCED_BUTTON_TO_STRING = "Remap Button to Multiple Buttons";
        private const string BUTTON_CHANGE_TO_PULSE_STRING = "Button Change to Pulse";

        public const int BUTTON_TO_AXIS = 0;
        public const int BUTTON_TO_BUTTON = 1;
        public const int ENCODER_TO_AXIS = 2;
        public const int ENCODER_TO_BUTTON = 3;
        public const int AXIS_TO_AXIS = 4;
        public const int AXIS_TO_BUTTON = 5;
        public const int ADVANCED_BUTTON_TO_BUTTON = 6;
        public const int BUTTON_CHANGE_TO_PULSE = 7;


        public int Id { get; set; }
        public string Name { get; set; }

        private MappingType(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public static ObservableCollection<MappingType> GetMappingTypes()
        {
            ObservableCollection<MappingType> types = new();
            types.Add(new MappingType(BUTTON_TO_AXIS, AXIS_TO_STRING));
            types.Add(new MappingType(BUTTON_TO_BUTTON, BUTTON_TO_STRING));
            types.Add(new MappingType(ENCODER_TO_AXIS, ENCODER_TO_AXIS_STRING));
            types.Add(new MappingType(AXIS_TO_AXIS, AXIS_TO_AXIS_STRING));
            types.Add(new MappingType(AXIS_TO_BUTTON, AXIS_TO_BUTTON_STRING));
            types.Add(new MappingType(ADVANCED_BUTTON_TO_BUTTON, ADVANCED_BUTTON_TO_STRING));
            types.Add(new MappingType(BUTTON_CHANGE_TO_PULSE, BUTTON_CHANGE_TO_PULSE_STRING));
            return types;
        }
    }
}
