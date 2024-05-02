using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class UserTravelPreferenceConfiguration : IEntityTypeConfiguration<UserTravelPreference>
    {
        public void Configure(EntityTypeBuilder<UserTravelPreference> builder)
        {
            builder
                .ToTable("user_travelpreference");

            builder
                .HasKey(utp => new {utp.UserId, utp.TravelPreferenceId});

            builder
                .HasOne<User>(utp => utp.User)
                .WithMany(u => u.UserTravelPreferences)
                .HasForeignKey(utp => utp.UserId);

            builder
                .HasOne<TravelPreference>(utp => utp.TravelPreference)
                .WithMany(tp => tp.UserTravelPreferences)
                .HasForeignKey(utp => utp.TravelPreferenceId);
        }
    }
}
