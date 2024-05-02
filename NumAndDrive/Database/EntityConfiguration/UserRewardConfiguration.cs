using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class UserRewardConfiguration : IEntityTypeConfiguration<UserReward>
    {
        public void Configure(EntityTypeBuilder<UserReward> builder)
        {
            builder
                .ToTable("user_reward");

            builder
                .HasKey(ur => new { ur.UserId, ur.RewardId });

            builder
                .Property(ur => ur.WinOn)
                .HasColumnType("date");

            builder
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRewards)
                .HasForeignKey(ur => ur.UserId);
        }
    }
}
