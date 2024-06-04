using Microsoft.AspNetCore.Identity;
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

            builder.HasKey(u => u.Id);

            builder
               .Property(u => u.Lastname)
               .HasColumnType("varchar")
               .HasMaxLength(50);
            builder
                .Property(u => u.Firstname)
                .HasColumnType("varchar")
                .HasMaxLength(30);

            // configure User relationship
            builder
                .HasOne<Status>(u => u.CurrentStatus)
                .WithMany(s => s.Users)
                .HasForeignKey(u => u.CurrentStatusId);


            builder
                .HasOne<DriverType>(u => u.CurrentDriverType)
                .WithMany(dt => dt.Users)
                .HasForeignKey(u => u.CurrentDriverTypeId);

            builder
                .HasOne<Classroom>(u => u.CurrentClassroom)
                .WithMany(c => c.Users)
                .HasForeignKey(u => u.CurrentClassroomId);

            builder
                .HasData(new User
                {
                    Id = "1",
                    UserName = "admin@admin-numanddrive.fr",
                    NormalizedUserName = "ADMIN@ADMIN-NUMANDDRIVE.FR",
                    Email = "admin@admin-numanddrive.fr",
                    NormalizedEmail = "ADMIN@ADMIN-NUMANDDRIVE.FR",
                    EmailConfirmed = true,
                    FirstConnection = false,
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "motdepasse"),
                    SecurityStamp = string.Empty
                });
        }
    }
}
