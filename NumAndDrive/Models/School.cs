namespace NumAndDrive.Models
{
    public class School
    {
        public int SchoolId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Address> Addresses { get; set; } = [];
    }
}
