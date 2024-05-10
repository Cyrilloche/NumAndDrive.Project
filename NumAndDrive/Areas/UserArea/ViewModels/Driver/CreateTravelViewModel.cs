using NumAndDrive.Models;

namespace NumAndDrive.Areas.UserArea.ViewModels.Driver
{
    public class CreateTravelViewModel
    {
        public IEnumerable<Address> TravelStopPoint { get; set; } = new List<Address>();
        public TimeOnly DepartureTime { get; set; }
        public TimeOnly ArrivalTime { get; set; }
        public List<Filter> SelectedFilters { get; set; } = new List<Filter>();
        public List<ActivationDay> SelectedDays { get; set; } = new List<ActivationDay>();
        public int AvailablePlacesInCar { get; set; }
        public string DepartureAddress { get; set; } = string.Empty;
        public string ArrivalAddress { get; set; } = string.Empty;
    }
}
