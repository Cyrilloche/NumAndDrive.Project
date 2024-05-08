namespace NumAndDrive.Models
{
    public class ActivationDay
    {
        public int ActivationDayId { get; set; }
        public string Day { get; set; } = string.Empty;
        public bool IsSelected { get; set; } = false;
        public ICollection<TravelActivationDay> TravelActivationDays { get; set; } = [];
    }
}
