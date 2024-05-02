using NumAndDrive.Models;

namespace NumAndDrive.ViewModels.UserProfile
{
    public class UserProfileViewModel
    {
        public string UserProfilePicturePath { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;
        public DriverType UserDriverType { get; set; } = new DriverType();
        public Status UserStatus { get; set; } = new Status();
        public ICollection<Travel> Travels { get; set; } = new List<Travel>();
    }
}
