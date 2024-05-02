using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NumAndDrive.Models;
using System.Reflection;

namespace NumAndDrive.Database
{
    public class NumAndDriveContext : IdentityDbContext<User>
    {
        public NumAndDriveContext(DbContextOptions<NumAndDriveContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<DriverType> DriverTypes { get; set; }
        public DbSet<TravelPreference> TravelPreferences { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<UserReward> UserRewards { get; set; }
        public DbSet<UserTravelPreference> UserTravelPreferences { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<TravelStopPoint> TravelStopPoints { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<TravelFilter> TravelFilters { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User");
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable(name: "RoleClaim");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable(name: "UserClaim");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable(name: "UserLogin");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable(name: "UserToken");
            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRole");
            });
        }
    }
}
