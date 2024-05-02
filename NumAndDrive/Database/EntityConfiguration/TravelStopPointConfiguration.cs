using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class TravelStopPointConfiguration : IEntityTypeConfiguration<TravelStopPoint>
    {
        public void Configure(EntityTypeBuilder<TravelStopPoint> builder)
        {
            builder.ToTable("travel_stop");

            builder
                .HasKey(tsp => new { tsp.CurrentTravelId, tsp.CurrentAdressId });

            builder
                .HasOne<Travel>(tsp => tsp.CurrentTravel)
                .WithMany(t => t.TravelStopPoints)
                .HasForeignKey(tsp => tsp.CurrentTravelId);

            builder
                .HasOne<Adress>(tsp => tsp.CurrentAdress)
                .WithMany(t => t.TravelStopPoints)
                .HasForeignKey(tsp => tsp.CurrentAdressId);
        }
    }
}
