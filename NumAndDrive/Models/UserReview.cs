namespace NumAndDrive.Models
{
    public class UserReview
    {
        public int UserReviewId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public int ReviewedUserId { get; set; }
        public User ReviewedUser { get; set; }
        public int ReviewerUserId { get; set; }
        public User ReviewerUser { get; set; }
    }
}
