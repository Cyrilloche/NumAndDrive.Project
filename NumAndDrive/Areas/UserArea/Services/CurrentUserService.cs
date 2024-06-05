using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NumAndDrive.Models;
using NumAndDrive.Services.Interfaces;

namespace NumAndDrive.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<User?> GetCurrentUserAsync()
        {
            var userId = GetCurrentUserId();

            if (userId != null)
            {
                return await _userManager.Users
                    .Include(u => u.CurrentStatus)
                    .Include(u => u.CurrentDriverType)
                    .Include(u => u.CurrentClassroom)
                    .Include(u => u.SendingReviews)
                    .Include(u => u.ObtainedReviews)
                    .Include(u => u.PostMessage)
                    .Include(u => u.IncomingMessage)
                    .Include(u => u.PublishedTravel)
                    .Include(u => u.Cars)
                    .Include(u => u.UserRewards)
                    .Include(u => u.UserTravelPreferences)
                    .Include(u => u.UserNotifications)
                    .Include(u => u.Reservations)
                    .FirstOrDefaultAsync(u => u.Id == userId);
            }
            return null;
        }

        public string? GetCurrentUserId()
        {
            var httpContext = _httpContextAccessor.HttpContext;

            if (httpContext == null)
            {
                Console.WriteLine("HttpContext is null");
                return null;
            }

            var userId = _userManager.GetUserId(httpContext.User);

            return userId;
        }
    }
}
