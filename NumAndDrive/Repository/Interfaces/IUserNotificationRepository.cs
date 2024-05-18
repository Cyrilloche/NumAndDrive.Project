﻿using NumAndDrive.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IUserNotificationRepository
{
    Task<UserNotification?> GetUserNotificationByIdAsync(int id);
    Task<IEnumerable<UserNotification>> GetAllUserNotificationsAsync();
    Task<UserNotification> CreateUserNotificationAsync(UserNotification newUserNotification);
    Task UpdateUserNotificationAsync(UserNotification updatedUserNotification);
    Task DeleteUserNotificationAsync(int id);
}
