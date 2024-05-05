using NumAndDrive.Models;

namespace NumAndDrive.Areas.Admin.ViewModels.UserManagement
{
    public class IndexUserViewModel
    {
        public IEnumerable<User> Users { get; set; } = new List<User>();
    }
}
