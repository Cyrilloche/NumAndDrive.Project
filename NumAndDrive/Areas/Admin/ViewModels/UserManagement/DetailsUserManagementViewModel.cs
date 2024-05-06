namespace NumAndDrive.Areas.Admin.ViewModels.UserManagement
{
    public class DetailsUserManagementViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NormalizeEmail { get; set; } = string.Empty;
        public bool IsEmailConfirmed { get; set; }
        public bool IsPhoneNumberConfirmed { get; set; }
        public int AccessFaildCount { get; set; }
        public string CurrentStatus { get; set; } = string.Empty;
        public string CurrentDriverType { get; set; } = string.Empty;
        public string CurrentRole { get; set; } = string.Empty;

    }
}
