using NumAndDrive.Models;

namespace NumAndDrive.Areas.UserArea.ViewModels.UserProfile
{
    public class UserProfileViewModel
    {
        public string UserProfilePicturePath { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public string DriverType { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public ICollection<Travel> CompletedTravels { get; set; } = new List<Travel>();
        public ICollection<Travel> IncomingTravels { get; set; } = new List<Travel>();
    }
}
