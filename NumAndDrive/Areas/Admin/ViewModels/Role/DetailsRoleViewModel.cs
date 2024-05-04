using Microsoft.AspNetCore.Identity;

namespace NumAndDrive.Areas.Admin.ViewModels.Role
{
    public class DetailsRoleViewModel
    {
        public IdentityRole Role { get; set; }
        public int Users { get; set; }
    }
}
