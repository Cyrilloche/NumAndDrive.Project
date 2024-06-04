using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class SchoolConfiguration : IEntityTypeConfiguration<School>
    {
        public void Configure(EntityTypeBuilder<School> builder)
        {
            builder.ToTable("school");

            builder.HasKey(s => s.SchoolId);

            builder
                .Property(c => c.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder
                .HasOne<Address>(s => s.SchoolAddress)
                .WithMany(a => a.Schools)
                .HasForeignKey(s => s.AddressId);
        }
    }
}
