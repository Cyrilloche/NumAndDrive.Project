using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database.EntityConfiguration;
using NumAndDrive.Models;

namespace NumAndDrive.Database
{
    public class NumAndDriveContext : DbContext
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
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RewardConfiguration());
            modelBuilder.ApplyConfiguration(new StatusConfiguration());
            modelBuilder.ApplyConfiguration(new ClassroomConfiguration());
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            modelBuilder.ApplyConfiguration(new FuelConfiguration());
            modelBuilder.ApplyConfiguration(new DriverTypeConfiguration());
            modelBuilder.ApplyConfiguration(new NotificationConfiguration());
            modelBuilder.ApplyConfiguration(new UserReviewConfiguration());
            modelBuilder.ApplyConfiguration(new MessageConfiguration());
            modelBuilder.ApplyConfiguration(new TravelConfiguration());
            modelBuilder.ApplyConfiguration(new AdressConfiguration());
            modelBuilder.ApplyConfiguration(new SchoolConfiguration());
            modelBuilder.ApplyConfiguration(new TravelPreferenceConfiguration());
            modelBuilder.ApplyConfiguration(new UserRewardConfiguration());
            modelBuilder.ApplyConfiguration(new UserTravelPreferenceConfiguration());
            modelBuilder.ApplyConfiguration(new UserNotificationConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new TravelStopPointConfiguration());
            modelBuilder.ApplyConfiguration(new FilterConfiguration());
            modelBuilder.ApplyConfiguration(new TravelFilterConfiguration());
        }
    }
}
