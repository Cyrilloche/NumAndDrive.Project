namespace NumAndDrive.Models
{
    public class TravelActivationDay
    {
        public int ActivationDayId { get; set; }
        public ActivationDay ActivationDay { get; set; }
        public int TravelId { get; set; }
        public Travel Travel { get; set; }
    }
}
