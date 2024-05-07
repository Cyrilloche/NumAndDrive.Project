using Microsoft.AspNetCore.Identity;

namespace NumAndDrive.Areas.Admin.ViewModels.UserManagement
{
    public class CreateUserManagementViewModel
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public IEnumerable<IdentityRole> Roles { get; set; } = new List<IdentityRole>();
        public string RoleName { get; set; } = string.Empty;
        public bool IsEmailAlreadyConfirmed { get; set; } = true; // Change to false after develop
    }
}
