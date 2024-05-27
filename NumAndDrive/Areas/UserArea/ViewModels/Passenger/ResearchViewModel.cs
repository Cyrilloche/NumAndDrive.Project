using NumAndDrive.Models;

namespace NumAndDrive.Areas.UserArea.ViewModels.Passenger
{
    public class ResearchViewModel
    {
        public IEnumerable<Travel> Travels { get; set; } = new List<Travel>();
        public Travel DetailsTravel { get; set; } = new Travel();
        public List<ActivationDay> Days { get; set; } = new List<ActivationDay>();
        public bool NotFound { get; set; } = false;
        public string ResearchedCity { get; set; } = string.Empty;
        public TimeOnly ResearchedDepartureTime { get; set; }
        public School School { get; set; } = new School();
    }
}
