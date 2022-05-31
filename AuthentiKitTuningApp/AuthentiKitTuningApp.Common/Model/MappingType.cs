using System;
using System.Collections.ObjectModel;

namespace MappingManager.Common.Model
{
    public class MappingType
    {
        private const string AXIS_TO_STRING = "Remap Button to Virtual Axis";
        private const string BUTTON_TO_STRING = "Remap Button to Virtual Button";
        private const string ENCODER_TO_AXIS_STRING = "Remap Encoder to Virtual Axis";
        private const string ENCODER_TO_BUTTON_STRING = "Remap Encoder to Virtual Button";
        private const string AXIS_TO_AXIS_STRING = "Remap Axis to Virtual Axis";
        private const string AXIS_TO_BUTTON_STRING = "Remap Axis to Virtual Button";

        public const int BUTTON_TO_AXIS = 0;
        public const int BUTTON_TO_BUTTON = 1;
        public const int ENCODER_TO_AXIS = 2;
        public const int ENCODER_TO_BUTTON = 3;
        public const int AXIS_TO_AXIS = 4;
        public const int AXIS_TO_BUTTON = 5;


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
            //types.Add(new MappingType(ENCODER_TO_BUTTON, ENCODER_TO_BUTTON_STRING));
            types.Add(new MappingType(AXIS_TO_AXIS, AXIS_TO_AXIS_STRING));
            types.Add(new MappingType(AXIS_TO_BUTTON, AXIS_TO_BUTTON_STRING));
            return types;
        }

        public static MappingType FromString(string s)
        {
            if (AXIS_TO_STRING.ToLower().Equals(s.ToLower()))
            {
                return new MappingType(BUTTON_TO_AXIS, AXIS_TO_STRING);
            }
            else if (BUTTON_TO_STRING.ToLower().Equals(s.ToLower()))
            {
                return new MappingType(BUTTON_TO_BUTTON, BUTTON_TO_STRING);
            }
            else if (ENCODER_TO_AXIS_STRING.ToLower().Equals(s.ToLower()))
            {
                return new MappingType(ENCODER_TO_AXIS, ENCODER_TO_AXIS_STRING);
            }
            throw new Exception(String.Format("Unsupported MappingType: {0}", s));
        }
    }
}
