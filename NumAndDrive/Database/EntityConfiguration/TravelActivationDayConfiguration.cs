using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class TravelActivationDayConfiguration : IEntityTypeConfiguration<TravelActivationDay>
    {
        public void Configure(EntityTypeBuilder<TravelActivationDay> builder)
        {
            builder
                .ToTable("travel_activationday");

            builder
                .HasKey(tad => new { tad.TravelId, tad.ActivationDayId });

            builder
                .HasOne<Travel>(tad => tad.Travel)
                .WithMany(t => t.TravelActivationDays)
                .HasForeignKey(tad => tad.TravelId);

            builder
                .HasOne<ActivationDay>(tad => tad.ActivationDay)
                .WithMany(ad => ad.TravelActivationDays)
                .HasForeignKey(tad => tad.ActivationDayId);

        }
    }
}
