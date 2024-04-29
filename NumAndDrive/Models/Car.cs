namespace NumAndDrive.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string PaintColor { get; set; } = string.Empty;
        public string Registration { get; set; } = string.Empty;
        public string? PicturePath { get; set; }

        public string UserId { get; set; } = string.Empty;
        public User Owner { get; set; }
        public int FuelId { get; set; }
        public Fuel FuelCar { get; set; }
    }
}
