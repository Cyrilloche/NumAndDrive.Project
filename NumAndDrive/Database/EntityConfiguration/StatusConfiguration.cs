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
                new Status { StatusId = 1, Name = "Statut non renseigné" },
                new Status { StatusId = 2, Name = "Intervenant-e" },
                new Status { StatusId = 3, Name = "Administrateur-trice" },
                new Status { StatusId = 4, Name = "Apprenant-e" },
                new Status { StatusId = 5, Name = "Formateur-trice" }
            );
        }
    }
}
