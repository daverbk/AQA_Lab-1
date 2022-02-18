namespace Drivers
{
    public class Vehicle
    {
        public string Model { get; set; }
     
        public int Year { get; set; }
        
        public Driver Owner { get; set; }
        
        public Engine Engine { get; set; }
    }
}
