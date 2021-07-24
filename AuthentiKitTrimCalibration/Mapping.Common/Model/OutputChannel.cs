using System;

namespace MappingManager.Common.Model
{
    public class OutputChannel
    {
        public int Id { get; set; }
        public uint VJoyDevice { get; set; }
        public uint VJoyItem { get; set; }
    }

    public class OutputAxis : OutputChannel
    {
        public enum AxisId
        {
            X = 48,
            Y = 49,
            Z = 50,
            RX = 51,
            RY = 52,
            RZ = 53,
            SL0 = 54,
            SL1 = 55,
            WHL = 56,
            POV = 57,
            AILERON = 176,
            RUDDER = 186,
            THROTTLE = 187,
            ACCELERATOR = 196,
            BRAKE = 197,
            CLUTCH = 198,
            STEERING = 200
        }
        override public string ToString()
        {
            return ("vJoy " + VJoyDevice + ": Axis " + (AxisId)VJoyItem);
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
