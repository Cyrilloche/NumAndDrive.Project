using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NumAndDrive.Areas.UserArea.ViewModels.Home;
using NumAndDrive.Areas.UserArea.Services.Interfaces;
using NumAndDrive.Services.Interfaces;
using NumAndDrive.Areas.UserArea.ViewModels.UserProfile;

namespace NumAndDrive.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IUserProfileService _userProfileService;

        public HomeController(ICurrentUserService currentUserService, IUserProfileService userProfileService)
        {
            _currentUserService = currentUserService;
            _userProfileService = userProfileService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _currentUserService.GetCurrentUserAsync();
            if (user != null)
            {
                if (user.FirstConnection)
                    return RedirectToAction("FirstConnection");

                var datas = new HomeViewModel
                {
                    Firstname = user.Firstname
                };
                return View(datas);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FirstConnection()
        {
            var model = new FirstConnectionViewModel();
            await _userProfileService.FillFirstConnectionViewModelAsync(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FirstConnection(FirstConnectionViewModel datas)
        {
            if (!ModelState.IsValid)
            {
                await _userProfileService.FillFirstConnectionViewModelAsync(datas);
                return View(datas);
            }

            var result = await _userProfileService.CompleteFirstUserProfileAsync(datas);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                await _userProfileService.FillFirstConnectionViewModelAsync(datas);
                return View(datas);
            }
        }
    }
}
