using System;
using System.Collections.ObjectModel;

namespace MappingManager.Common.Model
{
    public class MappingType
    {
        private const string AXIS_STRING = "Axis";
        private const string BUTTON_STRING = "Button";
        private const string ENCODER_AXIS_STRING = "Axis (from raw encoder)";
        private const string ENCODER_BUTTON_STRING = "Button (from raw encoder)";
        private const string AXIS_AXIS_STRING = "Axis (from axis)";

        public const int AXIS = 0;
        public const int BUTTON = 1;
        public const int ENCODER_AXIS = 2;
        public const int ENCODER_BUTTON = 3;
        public const int AXIS_AXIS = 4;


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
            types.Add(new MappingType(AXIS, AXIS_STRING));
            types.Add(new MappingType(BUTTON, BUTTON_STRING));
            types.Add(new MappingType(ENCODER_AXIS, ENCODER_AXIS_STRING));
            //types.Add(new MappingType(ENCODER_BUTTON, ENCODER_BUTTON_STRING));
            //types.Add(new MappingType(AXIS_AXIS, AXIS_AXIS_STRING));
            return types;
        }

        public static MappingType FromString(string s)
        {
            if (AXIS_STRING.ToLower().Equals(s.ToLower()))
            {
                return new MappingType(AXIS, AXIS_STRING);
            }
            else if (BUTTON_STRING.ToLower().Equals(s.ToLower()))
            {
                return new MappingType(BUTTON, BUTTON_STRING);
            }
            else if (ENCODER_AXIS_STRING.ToLower().Equals(s.ToLower()))
            {
                return new MappingType(ENCODER_AXIS, ENCODER_AXIS_STRING);
            }
            throw new Exception(String.Format("Unsupported MappingType: {0}", s));
        }
    }
}
