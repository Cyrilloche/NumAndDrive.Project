using Microsoft.EntityFrameworkCore;
using NumAndDrive.Database;
using NumAndDrive.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public class NotificationRepository : INotificationRepository
{
    private readonly NumAndDriveContext _context;

    public NotificationRepository(NumAndDriveContext context)
    {
        _context = context;
    }

    public async Task<Notification?> GetNotificationByIdAsync(int id)
    {
        return await _context.Notifications.FindAsync(id);
    }

    public async Task<IEnumerable<Notification>> GetAllNotificationsAsync()
    {
        return await _context.Notifications.ToListAsync();
    }

    public async Task<Notification> CreateNotificationAsync(Notification newNotification)
    {
        await _context.Notifications.AddAsync(newNotification);
        await _context.SaveChangesAsync();
        return newNotification;
    }

    public async Task UpdateNotificationAsync(Notification updatedNotification)
    {
        _context.Notifications.Update(updatedNotification);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteNotificationAsync(int id)
    {
        var notification = await _context.Notifications.FindAsync(id);
        if (notification != null)
        {
            _context.Notifications.Remove(notification);
            await _context.SaveChangesAsync();
        }
    }
}
