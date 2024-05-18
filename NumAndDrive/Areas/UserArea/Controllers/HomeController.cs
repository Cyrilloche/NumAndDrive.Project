using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NumAndDrive.Areas.UserArea.ViewModels.Home;
using NumAndDrive.Models;
using NumAndDrive.Services.Interfaces;

namespace NumAndDrive.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly UserManager<User> _userManager;

        public HomeController(UserManager<User> userManager, ICurrentUserService currentUserService)
        {
            _userManager = userManager;
            _currentUserService = currentUserService;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _currentUserService.GetCurrentUserAsync();
            if (user != null)
            {
                if (user.FirstConnection)
                    return RedirectToAction("FirstConnection", "UserProfile");

                var datas = new HomeViewModel
                {
                    Firstname = user.Firstname
                };
                return View(datas);
            }
            return View();
        }
    }
}
