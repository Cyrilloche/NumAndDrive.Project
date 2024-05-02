using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class TravelPreferenceConfiguration : IEntityTypeConfiguration<TravelPreference>
    {
        public void Configure(EntityTypeBuilder<TravelPreference> builder)
        {
            builder.ToTable("travelpreference");

            builder
                .Property(tp => tp.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50);
        }
    }
}
