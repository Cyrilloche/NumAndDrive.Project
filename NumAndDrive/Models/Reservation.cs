namespace NumAndDrive.Models
{
    public class Reservation
    {
        public DateTime ReservationDate { get; set; }
        public DateTime ResponseDate { get; set; }
        public bool Acceptation { get; set; }
        public bool AwaitingResponse { get; set; }
        public int TravelId { get; set; }
        public Travel Travel { get; set; }
        public string PassengerUserId { get; set; } = string.Empty;
        public User PassengerUser { get; set; }
    }
}
