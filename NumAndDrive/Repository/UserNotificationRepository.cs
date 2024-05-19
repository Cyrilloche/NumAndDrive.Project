using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;

public class UserNotificationRepository : IUserNotificationRepository
{
    private readonly NumAndDriveContext _context;

    public UserNotificationRepository(NumAndDriveContext context)
    {
        _context = context;
    }

    public async Task<UserNotification?> GetUserNotificationByIdAsync(int id)
    {
        return await _context.UserNotifications.FindAsync(id);
    }

    public async Task<IEnumerable<UserNotification>> GetAllUserNotificationsAsync()
    {
        return await _context.UserNotifications.ToListAsync();
    }

    public async Task<UserNotification> CreateUserNotificationAsync(UserNotification newUserNotification)
    {
        await _context.UserNotifications.AddAsync(newUserNotification);
        await _context.SaveChangesAsync();
        return newUserNotification;
    }

    public async Task UpdateUserNotificationAsync(UserNotification updatedUserNotification)
    {
        _context.UserNotifications.Update(updatedUserNotification);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserNotificationAsync(int id)
    {
        var userNotification = await _context.UserNotifications.FindAsync(id);
        if (userNotification != null)
        {
            _context.UserNotifications.Remove(userNotification);
            await _context.SaveChangesAsync();
        }
    }
}
