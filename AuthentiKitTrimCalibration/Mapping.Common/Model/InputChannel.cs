using System;

namespace MappingManager.Common.Model
{
    public class InputChannel
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Device { get; set; }
        public int Button { get; set; }
        public string Name { get; set; }
        override public string ToString()
        {
            return ("(ID: " + Id + ") "+ Device + ": Button " + (Button+1));
        }
    }
}
