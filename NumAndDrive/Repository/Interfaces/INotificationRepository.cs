using NumAndDrive.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface INotificationRepository
{
    Task<Notification?> GetNotificationByIdAsync(int id);
    Task<IEnumerable<Notification>> GetAllNotificationsAsync();
    Task<Notification> CreateNotificationAsync(Notification newNotification);
    Task UpdateNotificationAsync(Notification updatedNotification);
    Task DeleteNotificationAsync(int id);
}
