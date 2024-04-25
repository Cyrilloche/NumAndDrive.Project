namespace NumAndDrive.Models
{
    public class TravelPreference
    {
        public int TravelPreferenceId { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<UserTravelPreference> UserTravelPreferences { get; set; } = [];
    }
}
