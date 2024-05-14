namespace NumAndDrive.Models
{
    public class School
    {
        public int SchoolId { get; set; }
        public string Name { get; set; } = string.Empty;
        public int AddressId { get; set; }
        public Address SchoolAddress { get; set; }
        public ICollection<Classroom> Classrooms { get; set; } = new List<Classroom>();
    }
}
