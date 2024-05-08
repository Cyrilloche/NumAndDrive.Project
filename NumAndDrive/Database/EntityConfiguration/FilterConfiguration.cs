using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class FilterConfiguration : IEntityTypeConfiguration<Filter>
    {
        public void Configure(EntityTypeBuilder<Filter> builder)
        {
            builder.ToTable("filter");

            builder
                .Property(f => f.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder
                .HasData(
                    new Filter { FilterId = 1, Name = "Non-fumeur"},
                    new Filter { FilterId = 2, Name = "Annimaux acceptés"});
        }
    }
}
