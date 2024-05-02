using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class AdressConfiguration : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.ToTable("adress");

            builder
                .Property(a => a.Street)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder
                .Property(a => a.City)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            builder.Property(a => a.PostalCode)
                .HasColumnType("varchar")
                .HasMaxLength(25);

            builder
                .HasOne<School>(a => a.CurrentSchool)
                .WithMany(s => s.Adresses)
                .HasForeignKey(a => a.CurrentSchoolId);
        }
    }
}
