using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;
using System.Reflection.Emit;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class DriverTypeConfiguration : IEntityTypeConfiguration<DriverType>
    {
        public void Configure(EntityTypeBuilder<DriverType> builder)
        {
            builder.ToTable("drivertype");

            builder.HasKey(dt => dt.DriverTypeId);

            builder
               .Property(dt => dt.Name)
               .HasColumnType("varchar")
               .HasMaxLength(50);

            builder.HasData(
                new DriverType { DriverTypeId = 1, Name = "Nouveau-elle venu-e" },
                new DriverType { DriverTypeId = 2, Name = "Sébastien Loeb" },
                new DriverType { DriverTypeId = 3, Name = "Auto-tamponneur" },
                new DriverType { DriverTypeId = 4, Name = "Boîte de nuit mobile" },
                new DriverType { DriverTypeId = 5, Name = "Grand-e voyageur-euse" },
                new DriverType { DriverTypeId = 6, Name = "Grand-e bavard-e" },
                new DriverType { DriverTypeId = 7, Name = "Pas du matin" },
                new DriverType { DriverTypeId = 8, Name = "Copilote au top" },
                new DriverType { DriverTypeId = 9, Name = "Compteur-euse d'histoires" },
                new DriverType { DriverTypeId = 10, Name = "Ronfleur-euse" },
                new DriverType { DriverTypeId = 11, Name = "Mamie au volant" }
            );
        }
    }
}
