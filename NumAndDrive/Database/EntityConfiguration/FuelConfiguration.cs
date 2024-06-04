using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class FuelConfiguration : IEntityTypeConfiguration<Fuel>
    {
        public void Configure(EntityTypeBuilder<Fuel> builder)
        {
            builder.ToTable("fuel");

            builder.HasKey(f => f.FuelId);

            builder
                .Property(f => f.Name)
                .HasColumnType("varchar")
                .HasMaxLength(25);

            builder
                .HasData(
                new Fuel { FuelId = 1, Name = "Essence" },
                new Fuel { FuelId = 2, Name = "Diesel" },
                new Fuel { FuelId = 3, Name = "Hybride" },
                new Fuel { FuelId = 4, Name = "Électrique" }
            );
        }
    }
}
