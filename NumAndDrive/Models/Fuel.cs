namespace NumAndDrive.Models
{
    public class Fuel
    {
        public int FuelId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Car> Cars { get; set; } = [];
    }
}
