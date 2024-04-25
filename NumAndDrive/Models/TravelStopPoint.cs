namespace NumAndDrive.Models
{
    public class TravelStopPoint
    {
        public int CurrentTravelId { get; set; }
        public Travel CurrentTravel { get; set; }
        public int CurrentAdressId { get; set; }
        public Adress CurrentAdress { get; set; }
    }
}
