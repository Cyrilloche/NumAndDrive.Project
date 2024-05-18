﻿using NumAndDrive.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserRewardRepository
{
    Task<UserReward?> GetUserRewardByIdAsync(int id);
    Task<IEnumerable<UserReward>> GetAllUserRewardsAsync();
    Task<UserReward> CreateUserRewardAsync(UserReward newUserReward);
    Task UpdateUserRewardAsync(UserReward updatedUserReward);
    Task DeleteUserRewardAsync(int id);
}
