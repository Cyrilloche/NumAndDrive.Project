using NumAndDrive.Models;

public interface IUserReviewRepository
{
    Task<UserReview?> GetUserReviewByIdAsync(int id);
    Task<IEnumerable<UserReview>> GetAllUserReviewsAsync();
    Task<UserReview> CreateUserReviewAsync(UserReview newUserReview);
    Task UpdateUserReviewAsync(UserReview updatedUserReview);
    Task DeleteUserReviewAsync(int id);
}
