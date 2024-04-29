namespace NumAndDrive.Models
{
    public class UserReview
    {
        public int UserReviewId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public string ReviewedUserId { get; set; } = string.Empty;
        public User ReviewedUser { get; set; } 
        public string ReviewerUserId { get; set; } = string.Empty;
        public User ReviewerUser { get; set; }
    }
}
