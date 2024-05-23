using NumAndDrive.Models;

namespace NumAndDrive.Areas.UserArea.ViewModels.Passenger
{
    public class ResearchViewModel
    {
        public IEnumerable<Travel> Travels { get; set; } = new List<Travel>();
        public Travel DetailsTravel { get; set; } = new Travel();
    }
}
