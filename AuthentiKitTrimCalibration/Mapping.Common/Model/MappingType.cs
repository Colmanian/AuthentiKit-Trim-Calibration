using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MappingManager.Common.Model
{
    public class MappingType
    {
        private const string AXIS_STRING = "Axis";
        private const string BUTTON_STRING = "Button";

        public const int AXIS = 0;
        public const int BUTTON = 1; // Just support axis for now

        public int Id { get; set; }
        public string Name { get; set; }
    
        private MappingType (int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

        public static ObservableCollection<MappingType> GetMappingTypes()
        {
            ObservableCollection<MappingType> types = new();
            types.Add(new MappingType(AXIS, AXIS_STRING));
            types.Add(new MappingType(BUTTON, "Button")); // Just support axis for now
            return types;
        }

        public static MappingType FromString(string s)
        {
            if (AXIS_STRING.ToLower().Equals(s.ToLower()))
            {
                return new MappingType(AXIS, AXIS_STRING);
            }
            else if(BUTTON_STRING.ToLower().Equals(s.ToLower()))
            {
                return new MappingType(BUTTON, BUTTON_STRING);
            }
            throw new Exception(String.Format("Unsupported MappingType: {0}", s));
        }
    }
}
