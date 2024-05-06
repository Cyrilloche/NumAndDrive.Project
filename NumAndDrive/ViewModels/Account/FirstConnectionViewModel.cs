using NumAndDrive.Models;

namespace NumAndDrive.ViewModels.Account
{
    public class FirstConnectionViewModel
    {
        public string UserId { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string ConfirmationLink { get; set; } = string.Empty;
        public string UserProfilePicture { get; set; } = string.Empty;
        public int NewStatusId { get; set; }
        public int NewDriverTypeId { get; set; }
        public string NewFirstname { get; set; } = string.Empty;
        public string NewLastname { get; set; } = string.Empty;
        public IEnumerable<Status> Statuses { get; set; } = new List<Status>();
        public IEnumerable<DriverType> DriverTypes { get; set; } = new List<DriverType>();
    }
}
