using NumAndDrive.Models;

namespace NumAndDrive.Areas.UserArea.ViewModels.Driver
{
    public class CreateTravelViewModel
    {
        public IEnumerable<Address> TravelStopPoint { get; set; } = new List<Address>();
        public TimeOnly DepartureTime { get; set; }
        public List<Filter> SelectedFilters { get; set; } = new List<Filter>();
        public List<ActivationDay> SelectedDays { get; set; } = new List<ActivationDay>();
        public int AvailablePlacesInCar { get; set; }
        public string PersonnalAddress { get; set; } = string.Empty;
        public int SchoolAddressId { get; set; }
        public IEnumerable<School> Schools { get; set; } = new List<School>();
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
