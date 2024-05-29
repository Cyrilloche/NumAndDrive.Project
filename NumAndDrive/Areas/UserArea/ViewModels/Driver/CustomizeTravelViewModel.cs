using NumAndDrive.Models;

namespace NumAndDrive.Areas.UserArea.ViewModels.Driver
{
    public class CustomizeTravelViewModel
    {
        public Travel Travel { get; set; } = new Travel();
        public IEnumerable<ActivationDay> Days { get; set; } = new List<ActivationDay>();
        public IEnumerable<Reservation?> AcceptedUsers { get; set; } = new List<Reservation>();
        public IEnumerable<Reservation?> WaitingUsers { get; set; } = new List<Reservation>();
    }
}
