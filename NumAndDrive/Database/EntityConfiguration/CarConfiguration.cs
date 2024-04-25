using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("car");

            builder
                .Property(c => c.Brand)
                .HasColumnType("varchar")
                .HasMaxLength(25);
            builder
                .Property(c => c.Model)
                .HasColumnType("varchar")
                .HasMaxLength(25);
            builder
                .Property(c => c.PaintColor)
                .HasColumnType("varchar")
                .HasMaxLength(25);
            builder
                .Property(c => c.Registration)
                .HasColumnType("varchar")
                .HasMaxLength(25);
            builder
                .Property(c => c.PicturePath)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            builder
                .HasOne<Fuel>(c => c.FuelCar)
                .WithMany(f => f.Cars)
                .HasForeignKey(c => c.CarId);
        }
    }
}
