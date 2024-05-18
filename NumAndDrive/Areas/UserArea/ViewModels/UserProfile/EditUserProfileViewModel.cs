using NumAndDrive.Models;

namespace NumAndDrive.Areas.UserArea.ViewModels.UserProfile
{
    public class EditUserProfileViewModel
    {
        public string UserProfilePicture { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public int DriverTypeId { get; set; }
        public IEnumerable<Status> Statuses { get; set; } = new List<Status>();
        public IEnumerable<DriverType> DriverTypes { get; set; } = new List<DriverType>();
    }
}
