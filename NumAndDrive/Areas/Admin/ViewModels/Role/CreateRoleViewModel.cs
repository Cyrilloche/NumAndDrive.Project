using System.ComponentModel.DataAnnotations;

namespace NumAndDrive.Areas.Admin.ViewModels.Role
{
    public class CreateRoleViewModel
    {
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The role must be between 3 and 30 characters")]
        public string RoleName { get; set; } = string.Empty;
    }
}
