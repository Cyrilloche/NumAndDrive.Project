namespace NumAndDrive.Models
{
    public class Travel
    {
        public int TravelId { get; set; }
        public TimeOnly TimeDeparture { get; set; }
        public DateOnly DateDeparture { get; set; }
        public int AvailablePlace { get; set; }
        public DateTime CreationDate { get; set; }
        public string PublisherUserId { get; set; } = string.Empty;
        public User PublisherUser { get; set; }
        public ICollection<Reservation> Reservations { get; set; } = [];
        public int DepartureAdressId { get; set; }
        public Adress DepartureAdress { get; set; }
        public int ArrivalAdressId { get; set; }
        public Adress ArrivalAdress { get; set; }
        public ICollection<TravelStopPoint> TravelStopPoints { get; set; } = [];
        public ICollection<TravelFilter> TravelFilters { get; set; } = [];
        public ICollection<TravelActivationDay> TravelActivationDays { get; set; } = [];
    }
}
