using NumAndDrive.Models;

namespace NumAndDrive.Areas.UserArea.ViewModels.Driver
{
    public class DriverIndexViewModel
    {
        public IEnumerable<Travel> Travels { get; set; } = new List<Travel>();
        public IEnumerable<ActivationDay> Days { get; set; } = new List<ActivationDay>();
    }
}
