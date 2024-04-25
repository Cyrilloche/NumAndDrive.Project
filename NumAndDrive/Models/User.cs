﻿namespace NumAndDrive.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Lastname { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;

        // One-to-one
        public int CarId { get; set; }
        public Car? UserCar { get; set; }

        // One-to-many
        public int CurrentStatusId { get; set; }
        public Status CurrentStatus { get; set; }
        public int CurrentDriverTypeId { get; set; }
        public DriverType CurrentDriverType { get; set; }
        public int CurrentClassroomId { get; set; }
        public Classroom CurrentClassroom { get; set; }

        // Many-to-one
        public ICollection<UserReview> SendingReviews { get; set; } = [];
        public ICollection<UserReview> ObtainedReviews { get; set; } = [];
        public ICollection<Message> PostMessage { get; set; } = [];
        public ICollection<Message> IncomingMessage { get; set; } = [];
        public ICollection<Travel> PublishedTravel { get; set; } = [];

        // Many-to-many
        public ICollection<UserReward> UserRewards { get; set; } = [];
        public ICollection<UserTravelPreference> UserTravelPreferences { get; set; } = [];
        public ICollection<UserNotification> UserNotifications { get; set; } = [];
        public ICollection<Reservation> Reservations { get; set; } = [];
    }
}