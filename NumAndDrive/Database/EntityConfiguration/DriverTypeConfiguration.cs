using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class DriverTypeConfiguration : IEntityTypeConfiguration<DriverType>
    {
        public void Configure(EntityTypeBuilder<DriverType> builder)
        {
            builder.ToTable("drivertype");

            builder
               .Property(dt => dt.Name)
               .HasColumnType("varchar")
               .HasMaxLength(50);

            builder.HasData(
                new DriverType { DriverTypeId = 1, Name = "Mamie au volant" },
                new DriverType { DriverTypeId = 2, Name = "As du volant" }
            );
        }
    }
}
