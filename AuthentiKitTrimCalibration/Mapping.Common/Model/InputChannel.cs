using System;

namespace MappingManager.Common.Model
{
    public class InputChannel
    {
        public Guid Id { get; set; }
        public string Device { get; set; }
        public int Button { get; set; }
        override public string ToString()
        {
            return (Device + ": Button " + (Button+1));
        }
    }
}
