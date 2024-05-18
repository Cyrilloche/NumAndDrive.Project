using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class UserRewardRepository : IUserRewardRepository
{
    private readonly NumAndDriveContext _context;

    public UserRewardRepository(NumAndDriveContext context)
    {
        _context = context;
    }

    public async Task<UserReward?> GetUserRewardByIdAsync(int id)
    {
        return await _context.UserRewards.FindAsync(id);
    }

    public async Task<IEnumerable<UserReward>> GetAllUserRewardsAsync()
    {
        return await _context.UserRewards.ToListAsync();
    }

    public async Task<UserReward> CreateUserRewardAsync(UserReward newUserReward)
    {
        await _context.UserRewards.AddAsync(newUserReward);
        await _context.SaveChangesAsync();
        return newUserReward;
    }

    public async Task UpdateUserRewardAsync(UserReward updatedUserReward)
    {
        _context.UserRewards.Update(updatedUserReward);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserRewardAsync(int id)
    {
        var userReward = await _context.UserRewards.FindAsync(id);
        if (userReward != null)
        {
            _context.UserRewards.Remove(userReward);
            await _context.SaveChangesAsync();
        }
    }
}
