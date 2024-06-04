using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("status");

            builder.HasKey(s => s.StatusId);

            builder
                .Property(s => s.Name)
               .HasColumnType("varchar")
               .HasMaxLength(50);

            builder
                .HasData(
                new Status { StatusId = 1, Name = "Étudiant" },
                new Status { StatusId = 2, Name = "Intervenants" },
                new Status { StatusId = 3, Name = "Professeur" }
            );
        }
    }
}
