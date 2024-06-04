using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;
using System.Reflection.Emit;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class ActivationDayConfiguration : IEntityTypeConfiguration<ActivationDay>
    {
        public void Configure(EntityTypeBuilder<ActivationDay> builder)
        {
            builder
            .ToTable("activationday");

            builder.HasKey(ad => ad.ActivationDayId);

            builder.HasData(
                new ActivationDay { ActivationDayId = 1, Day = "Lundi"},
                new ActivationDay { ActivationDayId = 2, Day = "Mardi"},
                new ActivationDay { ActivationDayId = 3, Day = "Mercredi"},
                new ActivationDay { ActivationDayId = 4, Day = "Jeudi"},
                new ActivationDay { ActivationDayId = 5, Day = "Vendredi"},
                new ActivationDay { ActivationDayId = 6, Day = "Samedi"},
                new ActivationDay { ActivationDayId = 7, Day = "Dimanche"}
                );
        }
    }
}
