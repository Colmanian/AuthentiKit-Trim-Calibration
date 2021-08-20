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
            types.Add(new MappingType(AXIS, "Axis"));
            // types.Add(new MappingType(BUTTON, "Button")); // Just support axis for now
            return types;
        }
    }
}
