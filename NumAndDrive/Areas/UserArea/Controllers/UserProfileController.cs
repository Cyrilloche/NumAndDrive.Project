using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NumAndDrive.Areas.UserArea.Services.Interfaces;
using NumAndDrive.Areas.UserArea.ViewModels.UserProfile;

namespace NumAndDrive.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly IUserProfileService _userProfileService;

        public UserProfileController(IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = new UserProfileViewModel();
            await _userProfileService.FillIndexViewModelAsync(model);
            return View(model);
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
            } else
            {
                await _userProfileService.FillFirstConnectionViewModelAsync(datas);
                return View(datas);
            }
        }

        public async Task<IActionResult> Edit()
        {
            var model = new EditUserProfileViewModel();
            await _userProfileService.FillUpdateViewModelAsync(model);
            return View(model);

        }

        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public async Task<IActionResult> Edit(EditUserProfileViewModel datas)
        {
            if (!ModelState.IsValid)
            {
                await _userProfileService.FillUpdateViewModelAsync(datas);
                return View(datas);
            }

            var result = await _userProfileService.UpdateUserProfileAsync(datas);

            if (result.Succeeded)
                return RedirectToAction("Index");

            await _userProfileService.FillUpdateViewModelAsync(datas);
            return View(datas);
        }
    }
}
