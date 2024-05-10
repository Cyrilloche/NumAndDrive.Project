namespace NumAndDrive.Models
{
    public class TravelStopPoint
    {
        public int CurrentTravelId { get; set; }
        public Travel CurrentTravel { get; set; }
        public int CurrentAddressId { get; set; }
        public Address CurrentAdress { get; set; }
    }
}
