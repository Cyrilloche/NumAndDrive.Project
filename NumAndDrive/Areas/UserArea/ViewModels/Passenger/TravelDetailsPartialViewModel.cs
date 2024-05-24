using NumAndDrive.Models;

namespace NumAndDrive.Areas.UserArea.ViewModels.Passenger
{
    public class TravelDetailsPartialViewModel
    {
        public Travel Travel { get; set; } = new Travel();
        public IEnumerable<ActivationDay> Days { get; set; } = new List<ActivationDay>();
    }
}
