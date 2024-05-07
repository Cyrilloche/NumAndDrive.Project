namespace NumAndDrive.Areas.Admin.DTOs
{
    public class CreateUserDTO
    {
        public string Lastname { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string ProvisoryPaswword { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
