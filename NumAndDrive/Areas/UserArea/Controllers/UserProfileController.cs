using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NumAndDrive.Areas.UserArea.Services.Interfaces;
using NumAndDrive.Areas.UserArea.ViewModels.UserProfile;
using NumAndDrive.Models;
using NumAndDrive.Repository;
using NumAndDrive.Repository.Interfaces;
using NumAndDrive.Services.Interfaces;
using NumAndDrive.ViewModels.Account;

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
            await _userProfileService.FillIndexViewModel(model);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> FirstConnection()
        {
            var model = new FirstConnectionViewModel();
            await _userProfileService.FillFirstConnectionViewModel(model);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> FirstConnection(FirstConnectionViewModel datas)
        {
            if (!ModelState.IsValid)
            {
                await _userProfileService.FillFirstConnectionViewModel(datas);
                return View(datas);
            }

            var result = await _userProfileService.CompleteFirstUserProfile(datas);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            } else
            {
                await _userProfileService.FillFirstConnectionViewModel(datas);
                return View(datas);
            }
        }

        public async Task<IActionResult> Edit()
        {
            var model = new EditUserProfileViewModel();
            await _userProfileService.FillUpdateViewModel(model);
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserProfileViewModel datas)
        {
            if (!ModelState.IsValid)
            {
                await _userProfileService.FillUpdateViewModel(datas);
                return View(datas);
            }

            var result = await _userProfileService.UpdateUserProfile(datas);

            if (result.Succeeded)
                return RedirectToAction("Index");

            await _userProfileService.FillUpdateViewModel(datas);
            return View(datas);
        }
    }
}
