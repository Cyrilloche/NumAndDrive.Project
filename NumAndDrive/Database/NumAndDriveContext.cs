﻿using Microsoft.AspNetCore.Identity;
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
        public DbSet<Address> Addresses { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<UserReward> UserRewards { get; set; }
        public DbSet<UserTravelPreference> UserTravelPreferences { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<TravelStopPoint> TravelStopPoints { get; set; }
        public DbSet<Filter> Filters { get; set; }
        public DbSet<TravelFilter> TravelFilters { get; set; }
        public DbSet<ActivationDay> ActivationDays { get; set; }
        public DbSet<TravelActivationDay> TravelActivationDays { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(name: "User");
                entity.Property(m => m.Id).HasColumnType("VARCHAR(100)");
                entity.Property(m => m.UserName).HasColumnType("VARCHAR(100)");
                entity.Property(m => m.NormalizedUserName).HasColumnType("VARCHAR(100)");
                entity.Property(m => m.Email).HasColumnType("VARCHAR(100)");
                entity.Property(m => m.NormalizedEmail).HasColumnType("VARCHAR(100)");
            });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
                entity.Property(m => m.Id).HasColumnType("VARCHAR(100)");
                entity.Property(m => m.Name).HasColumnType("VARCHAR(100)");
                entity.Property(m => m.NormalizedName).HasColumnType("VARCHAR(100)");
                entity.HasData(
                    new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole { Id = "2", Name = "Client", NormalizedName = "CLIENT" }
                    );
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
                entity.Property(m => m.LoginProvider).HasColumnType("VARCHAR(100)");
                entity.Property(m => m.ProviderKey).HasColumnType("VARCHAR(100)");
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable(name: "UserToken");
                entity.Property(m => m.LoginProvider).HasColumnType("VARCHAR(50)");
                entity.Property(m => m.Name).HasColumnType("VARCHAR(50)");

            });

            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable(name: "UserRole");
                entity.HasData(
                    new IdentityUserRole<string> { UserId = "1", RoleId = "1" }
                    );
            });


        }
    }
}
