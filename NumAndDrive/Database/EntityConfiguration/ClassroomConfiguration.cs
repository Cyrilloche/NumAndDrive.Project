using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class ClassroomConfiguration : IEntityTypeConfiguration<Classroom>
    {
        public void Configure(EntityTypeBuilder<Classroom> builder)
        {
            builder.ToTable("classroom");

            builder.HasKey(c => c.ClassroomId);

            builder.Property(c => c.Name)
               .HasColumnType("varchar")
               .HasMaxLength(50);
        }
    }
}
