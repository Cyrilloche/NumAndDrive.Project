using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace NumAndDrive.Areas.Admin.ViewModels.UserManagement
{
    public class CreateUserManagementViewModel
    {
        [Required(ErrorMessage = "Email field is required.")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password field is required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$", ErrorMessage = "Password must be at least 8 characters long, and include at least one uppercase letter, one lowercase letter, one digit, and one special character.")]

        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public IEnumerable<IdentityRole> Roles { get; set; } = new List<IdentityRole>();

        [Required(ErrorMessage = "Role field is required.")]
        public string RoleName { get; set; } = string.Empty;
        public bool IsEmailAlreadyConfirmed { get; set; } = true; // Change to false after develop
    }
}
