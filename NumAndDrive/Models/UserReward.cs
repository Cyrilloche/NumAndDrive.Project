﻿namespace NumAndDrive.Models
{
    public class UserReward
    {
        public DateOnly WinOn { get; set; }
        public string UserId { get; set; } = string.Empty;
        public User User { get; set; }
        public int RewardId { get; set; }
        public Reward Reward { get; set; }
    }
}
