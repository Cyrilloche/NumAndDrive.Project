namespace NumAndDrive.Models
{
    public class Reservation
    {
        public DateTime ReservationDate { get; set; }
        public DateTime ResponseDate { get; set; }
        public bool Acceptation { get; set; }
        public int TravelId { get; set; }
        public Travel Travel { get; set; }
        public int PassengerUserId { get; set; }
        public User PassengerUser { get; set; }
    }
}
