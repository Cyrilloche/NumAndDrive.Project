namespace NumAndDrive.Models
{
    public class UserTravelPreference
    {
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; }
        public int TravelPreferenceId { get; set; }
        public TravelPreference TravelPreference { get; set; }
    }
}
