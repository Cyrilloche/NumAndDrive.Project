using Microsoft.AspNetCore.Identity;
using NumAndDrive.Models;
using System.ComponentModel.DataAnnotations;

namespace NumAndDrive.Areas.Admin.ViewModels.UserManagement
{
    public class EditUserManagementViewModel
    {
        public string UserId { get; set; } = string.Empty;

        [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ' -]+$", ErrorMessage = "Invalid lastname format")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "The lastname must be between 3 and 50 characters.")]
        public string Lastname { get; set; } = string.Empty;

        [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ' -]+$", ErrorMessage = "Invalid firstname format")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The firstname must be between 3 and 30 characters.")]
        public string Firstname { get; set; } = string.Empty;

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;


        public string CurrentRole { get; set; } = string.Empty;
        public int? NewStatusId { get; set; }
        public int? NewDriverTypeId { get; set; }
        public string NewRoleId { get; set; } = string.Empty;
        public IEnumerable<Status> Statuses { get; set; } = new List<Status>();
        public IEnumerable<DriverType> DriverTypes { get; set; } = new List<DriverType>();
        public IEnumerable<IdentityRole> Roles { get; set; } = new List<IdentityRole>();
    }
}
