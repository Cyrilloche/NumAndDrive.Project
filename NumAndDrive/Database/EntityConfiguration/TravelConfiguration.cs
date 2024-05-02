using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class TravelConfiguration : IEntityTypeConfiguration<Travel>
    {
        public void Configure(EntityTypeBuilder<Travel> builder)
        {
            builder.ToTable("travel");

            builder
                .Property(t => t.TimeDeparture)
                .HasColumnType("time");
            builder
                .Property(t => t.DateDeparture)
                .HasColumnType("date");
            builder
                .Property(t => t.CreationDate)
                .HasColumnType("datetime");
            builder
                .Property(t => t.AvailablePlace)
                .HasColumnType("tinyint");

            builder
                .HasOne<User>(t => t.PublisherUser)
                .WithMany(u => u.PublishedTravel)
                .HasForeignKey(t => t.PublisherUserId);

            builder
                .HasOne<Adress>(t => t.DepartureAdress)
                .WithMany(a => a.DepartureTravel)
                .HasForeignKey(t => t.DepartureAdressId);

            builder
                .HasOne<Adress>(t => t.ArrivalAdress)
                .WithMany(a => a.ArrivalTravel)
                .HasForeignKey(t => t.ArrivalAdressId);
        }
    }
}
