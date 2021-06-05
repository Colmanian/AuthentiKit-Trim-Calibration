using System;

namespace MappingManager.Common.Model
{
    public class Mapping
    {
        public string Name { get; set; }
        public int InputId { get; set; }
        public int OutputId { get; set; }
        public int Multiplier { get; set; }
        public int HoldThresholdStart { get; set; }
        public int HoldThresholdStop { get; set; }
        public string ResetCommand { get; set; }
        public bool Enabled { get; set; }
    }
}