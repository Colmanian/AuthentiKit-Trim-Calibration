using System;

namespace MappingManager.Common.Model
{
    public class Mapping
    {
        public string Name { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public int Multiplier { get; set; }
        public int HoldThresholdStart { get; set; }
        public int HoldThresholdStop { get; set; }
        public string ResetCommand { get; set; }
    }
}