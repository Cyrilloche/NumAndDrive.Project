using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable("user");

            builder
               .Property(u => u.Lastname)
               .HasColumnType("varchar")
               .HasMaxLength(50);
            builder
                .Property(u => u.FirstName)
                .HasColumnType("varchar")
                .HasMaxLength(30);

            // configure User relationship
            builder
                .HasOne<Status>(u => u.CurrentStatus)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.CurrentStatusId);

            builder
                .HasOne<Car>(u => u.UserCar)
                .WithOne(c => c.Owner)
                .HasForeignKey<Car>(u => u.UserId)
                .IsRequired();

            builder
                .HasOne<DriverType>(u => u.CurrentDriverType)
                .WithMany(dt => dt.Users)
                .HasForeignKey(u => u.CurrentDriverTypeId);

            builder
                .HasOne<Classroom>(u => u.CurrentClassroom)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CurrentClassroomId);
        }
    }
}
