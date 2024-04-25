namespace NumAndDrive.Models
{
    public class DriverType
    {
        public int DriverTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; } = [];
    }
}
