namespace NumAndDrive.Models
{
    public class Reward
    {
        public int RewardId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string IllustrationPath { get; set; } = string.Empty;
        public ICollection<UserReward> UserRewards { get; set; } = [];
    }
}
