using System;

namespace MappingManager.Common.Model
{
    public class OutputChannel
    {
        public int VJoyId { get; set; }
        public uint VJoyDevice { get; set; }
        public uint VJoyItem { get; set; }
        public string Name { get => this.ToString(); }
        public int Hash { get => this.GetHashCode(); } // Used as a pseudo unique reference for storage

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 5381;
                hash = hash * 23 + (int)VJoyDevice;
                hash = hash * 83 + (int)VJoyItem;
                return hash;
            }
        }
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
            string s;
            if (VJoyItem <= (int)AxisId.Z)
            {
                s = (AxisId)VJoyItem + " Axis   (L-Axis " + (AxisId)VJoyItem + " in MSFS)";
            }
            else if (VJoyItem <= (int)AxisId.RZ)
            {
                s = (AxisId)VJoyItem + " Rotation   (R-Axis " + (AxisId)VJoyItem + " in MSFS)";
            }
            else
            {
                s = (AxisId)VJoyItem + "";
            }
            return "vJoy " + VJoyDevice + ": " + s;
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
