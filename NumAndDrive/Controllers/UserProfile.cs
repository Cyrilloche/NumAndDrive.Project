using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NumAndDrive.Models;
using NumAndDrive.Repository;
using NumAndDrive.Services;
using NumAndDrive.ViewModels.UserProfile;

namespace NumAndDrive.Controllers
{
    public class UserProfile : Controller
    {
        private readonly UserManager<User> _userManager;
        private IStatusRepository _statusRepository;

        public UserProfile(UserManager<User> userManager, IStatusRepository statusRepository)
        {
            _userManager = userManager;
            _statusRepository = statusRepository;
        }

        public IStatusRepository StatusRepository { get; }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            var user = await _userManager.FindByIdAsync(userId);

            if (user != null)
            {
                var userViewModel = new UserProfileViewModel
                {
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Status = await _statusRepository.GetStatusByIdAsync(user.CurrentStatusId)
                };
                return View(userViewModel);
            }

            return View();

        }
    }
}
