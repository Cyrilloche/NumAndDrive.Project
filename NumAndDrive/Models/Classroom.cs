namespace NumAndDrive.Models
{
    public class Classroom
    {
        public int ClassroomId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<User> Users { get; set; } = [];
    }
}
