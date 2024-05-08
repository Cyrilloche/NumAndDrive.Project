using NumAndDrive.Models;

namespace NumAndDrive.Areas.UserArea.ViewModels.Driver
{
    public class CreateTravelViewModel
    {
        public Adress DepartureAddress { get; set; } = new Adress();
        public Adress ArrivalAddress { get; set; } = new Adress();
        public List<Adress> TravelStopPoint { get; set; } = new List<Adress>();
        public TimeOnly DepartureTime { get; set; }
        public TimeOnly ArrivalTime { get; set; }
        public List<Filter> Filters { get; set; } = new List<Filter>();
        public List<Filter> SelectedFilters { get; set; } = new List<Filter>();
        public List<ActivationDay> ActivationDays { get; set; } = new List<ActivationDay>();
        public List<ActivationDay> SelectedDays { get; set; } = new List<ActivationDay>();
        public int AvailablePlacesInCar { get; set; }

    }
}
