using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;
using System.Reflection.Emit;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("address");

            builder.HasKey(a => a.AddressId);

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
        }
    }
}
