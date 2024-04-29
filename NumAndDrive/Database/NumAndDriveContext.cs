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

            modelBuilder.Entity<Reservation>().HasKey(r => new { r.PassengerUserId, r.TravelId });
            modelBuilder.Entity<TravelFilter>().HasKey(tf => new { tf.TravelId, tf.FilterId });
            modelBuilder.Entity<UserNotification>().HasKey(un => new { un.UserId, un.NotificationId });
            modelBuilder.Entity<UserReward>().HasKey(ur => new { ur.UserId, ur.RewardId });
            modelBuilder.Entity<TravelStopPoint>().HasKey(tsp => new { tsp.CurrentTravelId, tsp.CurrentAdressId });
            modelBuilder.Entity<UserTravelPreference>().HasKey(utp => new { utp.UserId, utp.TravelPreferenceId });

            modelBuilder.Entity<Travel>()
                .HasOne<Adress>(t => t.DepartureAdress)
                .WithMany(a => a.DepartureTravel)
                .HasForeignKey(t => t.DepartureAdressId);

            modelBuilder.Entity<Travel>()
                .HasOne<Adress>(t => t.ArrivalAdress)
                .WithMany(a => a.ArrivalTravel)
                .HasForeignKey(t => t.ArrivalAdressId);

            modelBuilder.Entity<Message>()
                .HasOne<User>(m => m.SenderUser)
                .WithMany(u => u.PostMessage)
                .HasForeignKey(m => m.SenderUserId);

            modelBuilder.Entity<Message>()
                .HasOne<User>(m => m.ReceiverUser)
                .WithMany(u => u.IncomingMessage)
                .HasForeignKey(m => m.ReceiverUserId);

            modelBuilder.Entity<UserReview>()
                .HasOne<User>(ur => ur.ReviewerUser)
                .WithMany(u => u.SendingReviews)
                .HasForeignKey(u => u.ReviewerUserId);

            modelBuilder.Entity<UserReview>()
                .HasOne<User>(ur => ur.ReviewedUser)
                .WithMany(u => u.ObtainedReviews)
                .HasForeignKey(ur => ur.ReviewedUserId);

        }
    }
}
