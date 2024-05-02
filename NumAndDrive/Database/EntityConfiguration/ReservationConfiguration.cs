using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("reservation");

            builder.HasKey(r => new { r.PassengerUserId, r.TravelId });

            builder
                .Property(ur => ur.ReservationDate)
                .HasColumnType("datetime");
            builder
                .Property(ur => ur.ResponseDate)
                .HasColumnType("datetime");
            builder
                .Property(ur => ur.Acceptation)
                .HasColumnType("tinyint(1)");

            builder
                .HasOne<User>(r => r.PassengerUser)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.PassengerUserId);

            builder
                .HasOne<Travel>(r => r.Travel)
                .WithMany(t => t.Reservations)
                .HasForeignKey(r => r.TravelId);
        }
    }
}
