using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;

public class RewardRepository : IRewardRepository
{
    private readonly NumAndDriveContext _context;

    public RewardRepository(NumAndDriveContext context)
    {
        _context = context;
    }

    public async Task<Reward?> GetRewardByIdAsync(int id)
    {
        return await _context.Rewards.FindAsync(id);
    }

    public async Task<IEnumerable<Reward>> GetAllRewardsAsync()
    {
        return await _context.Rewards.ToListAsync();
    }

    public async Task<Reward> CreateRewardAsync(Reward newReward)
    {
        await _context.Rewards.AddAsync(newReward);
        await _context.SaveChangesAsync();
        return newReward;
    }

    public async Task UpdateRewardAsync(Reward updatedReward)
    {
        _context.Rewards.Update(updatedReward);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRewardAsync(int id)
    {
        var reward = await _context.Rewards.FindAsync(id);
        if (reward != null)
        {
            _context.Rewards.Remove(reward);
            await _context.SaveChangesAsync();
        }
    }
}
