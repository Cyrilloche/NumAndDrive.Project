namespace NumAndDrive.Models
{
    public class UserTravelPreference
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int TravelPreferenceId { get; set; }
        public TravelPreference TravelPreference { get; set; }
    }
}
