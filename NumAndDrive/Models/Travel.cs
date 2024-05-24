namespace NumAndDrive.Models
{
    public class Travel
    {
        public int TravelId { get; set; }
        public TimeOnly DepartureTime { get; set; }
        public TimeOnly ArrivalTime { get; set; }
        public int AvailablePlace { get; set; }
        public DateTime CreationDate { get; set; }
        public string PublisherUserId { get; set; } = string.Empty;
        public User PublisherUser { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = [];
        public int PersonnalAddressId { get; set; }
        public Address PersonnalAdress { get; set; }
        public int SchoolAddressId { get; set; }
        public Address SchoolAddress { get; set; }
        public ICollection<TravelStopPoint> TravelStopPoints { get; set; } = [];
        public ICollection<TravelFilter> TravelFilters { get; set; } = [];
        public ICollection<TravelActivationDay> TravelActivationDays { get; set; } = [];
    }
}
