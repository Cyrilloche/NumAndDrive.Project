using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserReviewRepository : IUserReviewRepository
{
    private readonly NumAndDriveContext _context;

    public UserReviewRepository(NumAndDriveContext context)
    {
        _context = context;
    }

    public async Task<UserReview?> GetUserReviewByIdAsync(int id)
    {
        return await _context.UserReviews.FindAsync(id);
    }

    public async Task<IEnumerable<UserReview>> GetAllUserReviewsAsync()
    {
        return await _context.UserReviews.ToListAsync();
    }

    public async Task<UserReview> CreateUserReviewAsync(UserReview newUserReview)
    {
        await _context.UserReviews.AddAsync(newUserReview);
        await _context.SaveChangesAsync();
        return newUserReview;
    }

    public async Task UpdateUserReviewAsync(UserReview updatedUserReview)
    {
        _context.UserReviews.Update(updatedUserReview);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserReviewAsync(int id)
    {
        var userReview = await _context.UserReviews.FindAsync(id);
        if (userReview != null)
        {
            _context.UserReviews.Remove(userReview);
            await _context.SaveChangesAsync();
        }
    }
}
