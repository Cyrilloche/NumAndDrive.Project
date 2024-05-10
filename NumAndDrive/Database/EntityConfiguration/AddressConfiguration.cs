using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("address");

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
                .WithMany(s => s.Addresses)
                .HasForeignKey(a => a.CurrentSchoolId);
        }
    }
}
