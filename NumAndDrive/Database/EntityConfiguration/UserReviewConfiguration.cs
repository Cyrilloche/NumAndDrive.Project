using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class UserReviewConfiguration : IEntityTypeConfiguration<UserReview>
    {
        public void Configure(EntityTypeBuilder<UserReview> builder)
        {
            builder.ToTable("userreview");

            builder.HasKey(ur => ur.UserReviewId);

            builder
                .Property(ur => ur.Rating)
                .HasColumnType("tinyint");
            builder
                .Property(ur => ur.Comment)
                .HasColumnType("text");

            builder
                .HasOne<User>(ur => ur.ReviewerUser)
                .WithMany(u => u.SendingReviews)
                .HasForeignKey(u => u.ReviewerUserId);

            builder
                .HasOne<User>(ur => ur.ReviewedUser)
                .WithMany(u => u.ObtainedReviews)
                .HasForeignKey(ur => ur.ReviewedUserId);
        }
    }
}
