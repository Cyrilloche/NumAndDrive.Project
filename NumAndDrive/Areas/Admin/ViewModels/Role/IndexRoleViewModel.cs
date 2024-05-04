using Microsoft.AspNetCore.Identity;

namespace NumAndDrive.Areas.Admin.ViewModels.Role
{
    public class IndexRoleViewModel
    {
        public List<IdentityRole> Roles { get; set; } = new List<IdentityRole>();
        public string NewNameRole { get; set; } = string.Empty;
    }
}
