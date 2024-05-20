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
        public int DepartureAddressId { get; set; }
        public Address DepartureAddress { get; set; }
        public int ArrivalAddressId { get; set; }
        public Address ArrivalAddress { get; set; }
        public ICollection<TravelStopPoint> TravelStopPoints { get; set; } = [];
        public ICollection<TravelFilter> TravelFilters { get; set; } = [];
        public ICollection<TravelActivationDay> TravelActivationDays { get; set; } = [];
    }
}
