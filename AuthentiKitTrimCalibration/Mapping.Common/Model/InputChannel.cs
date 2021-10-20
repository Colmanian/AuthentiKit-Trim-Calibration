using System;

namespace MappingManager.Common.Model
{
    public class InputChannel
    {
        public int Id { get; set; } // Only used to enumerate the list of devices for display.
        public Guid Guid { get; set; } // A unique ID for the device, that persists betweens sessions and unplugging
        public string Device { get; set; } // Name of device
        public int Button { get; set; } // Integer button number
        public string Name { get; set; } // Channel name as combination of device and button
        public int Hash { get => this.GetHashCode(); } // Used as a pseudo unique reference for a device and button combo

        override public string ToString()
        {
            return (String.Format("{0}: Button {1}", Device, (Button+1)));
        }
    }
}
