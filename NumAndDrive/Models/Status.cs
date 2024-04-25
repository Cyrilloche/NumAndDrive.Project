namespace NumAndDrive.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; } = [];
    }
}
