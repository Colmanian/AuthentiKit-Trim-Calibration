﻿using System;

namespace AuthentiKitTuningApp.Common.Model
{
    public class CalibrationDTO
    {
        public CalibrationDTO(int min = 0, int cen = 0, int max = 0)
        {
            Min = min;
            Cen = cen;
            Max = max;
        }

        public int Min { get; set; }
        public int Max { get; set; }
        public int Cen { get; set; }

        override public string ToString()
        {
            return String.Format("Min: {0}, Cen: {1}, Max: {2}", Min, Cen, Max);
        }

        public bool IsSet => Max > 0;

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                CalibrationDTO b = (CalibrationDTO)obj;
                return (Min == b.Min) && (Cen == b.Cen) && (Max == b.Max);
            }
        }
    }
}