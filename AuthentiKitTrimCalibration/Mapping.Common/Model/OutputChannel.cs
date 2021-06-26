namespace MappingManager.Common.Model
{
    public class OutputChannel
    {
        public int Id { get; set; }
        public int VJoyDevice { get; set; }
        public int VJoyItem { get; set; }
        override public string ToString()
        {
            return ("vJoy " + VJoyDevice + ": " + VJoyItem);
        }
    }
}
