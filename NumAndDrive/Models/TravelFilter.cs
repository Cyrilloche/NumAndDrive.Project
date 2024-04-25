namespace NumAndDrive.Models
{
    public class TravelFilter
    {
        public int TravelId { get; set; }
        public Travel Travel { get; set; }
        public int FilterId { get; set; }
        public Filter Filter { get; set; }
    }
}
