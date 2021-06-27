using System;

namespace MappingManager.Common.Model
{
    public class OutputChannel
    {
        public int Id { get; set; }
        public int VJoyDevice { get; set; }
        public int VJoyItem { get; set; }
    }

    public class OutputAxis : OutputChannel
    {
        override public string ToString()
        {
            return ("vJoy " + VJoyDevice + ": Axis " + Math.Floor(VJoyItem / 20.0));
        }
    }
    public class OutputButton : OutputChannel
    {
        override public string ToString()
        {
            return "vJoy " + VJoyDevice + ": Button " + VJoyItem;
        }
    }
}
