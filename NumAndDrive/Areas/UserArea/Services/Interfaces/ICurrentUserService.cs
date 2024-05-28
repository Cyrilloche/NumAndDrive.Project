using NumAndDrive.Models;

namespace NumAndDrive.Services.Interfaces
{
    public interface ICurrentUserService
    {
        Task<User?> GetCurrentUserAsync();
        string? GetCurrentUserId();
    }
}
