using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NumAndDrive.Models;
using NumAndDrive.ViewModels.UserProfile;

namespace NumAndDrive.Controllers
{
    public class UserProfile : Controller
    {
        private readonly UserManager<User> _userManager;

        public UserProfile(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId =  _userManager.GetUserId(User);

            var user = await _userManager.FindByIdAsync(userId);

            if(user == null)
            {
                return View();
            }

            var userViewModel = new UserProfileViewModel
            {
                Firstname = user.Firstname,
                Lastname = user.Lastname
            };

            return View(userViewModel);
        }
    }
}
