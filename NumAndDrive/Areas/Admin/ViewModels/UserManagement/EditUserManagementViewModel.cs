using Microsoft.AspNetCore.Identity;
using NumAndDrive.Models;

namespace NumAndDrive.Areas.Admin.ViewModels.UserManagement
{
    public class EditUserManagementViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
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
