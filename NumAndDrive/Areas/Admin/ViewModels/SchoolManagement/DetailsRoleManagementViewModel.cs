using NumAndDrive.Models;

namespace NumAndDrive.Areas.Admin.ViewModels.SchoolManagement
{
    public class DetailsRoleManagementViewModel
    {
        public School School { get; set; } = new School();
        public Address SchoolAdress { get; set; } = new Address();
    }
}
