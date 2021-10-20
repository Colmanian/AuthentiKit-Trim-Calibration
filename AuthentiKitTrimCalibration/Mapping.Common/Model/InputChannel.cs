using System;
using System.Diagnostics;

namespace MappingManager.Common.Model
{
    public class InputChannel
    {
        public Guid Guid { get; set; } // A unique ID for the device, that persists betweens sessions and unplugging
        public string Device { get; set; } // Name of device
        public int Button { get; set; } // Integer button number
        public string Name { get; set; } // Channel name as combination of device and button
        public int Hash { get => this.GetHashCode(); } // Used as a pseudo unique reference for a device and button combo
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                if (Device != null)
                {
                    for (int i = 0; i < Device.Length; i++)
                    {
                        hash *= 31 + Device[i];
                    }
                    hash *= 23 + Button;
                }
                return hash;
            }
        }

        override public string ToString()
        {
            return (String.Format("{0}: Button {1}", Device, (Button+1)));
        }
    }
}
