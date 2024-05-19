using NumAndDrive.Models;

public interface IRewardRepository
{
    Task<Reward?> GetRewardByIdAsync(int id);
    Task<IEnumerable<Reward>> GetAllRewardsAsync();
    Task<Reward> CreateRewardAsync(Reward newReward);
    Task UpdateRewardAsync(Reward updatedReward);
    Task DeleteRewardAsync(int id);
}
