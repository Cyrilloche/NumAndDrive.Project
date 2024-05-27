using NumAndDrive.Models;
using System.ComponentModel.DataAnnotations;

namespace NumAndDrive.Areas.UserArea.ViewModels.Passenger
{
    public class PassengerIndexViewModel
    {
        public int SchoolId { get; set; }
        [Required(ErrorMessage ="Veuillez renseigner un point d'arrivée")]
        public string ResearchedCity { get; set; } = string.Empty;
        public IEnumerable<School> Schools { get; set; } = new List<School>();
        public List<ActivationDay> Days { get; set; } = new List<ActivationDay>();
        public List<TravelActivationDay> SelectedDays { get; set; } = new List<TravelActivationDay>();
        public TimeOnly SelectedTime { get; set; }

        public List<Travel> Travels { get; set; } = new List<Travel>();

    }
}
