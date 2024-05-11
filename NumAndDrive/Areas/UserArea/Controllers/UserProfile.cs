using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NumAndDrive.Areas.UserArea.ViewModels.UserProfile;
using NumAndDrive.Models;
using NumAndDrive.Repository;
using NumAndDrive.Repository.Interfaces;
using NumAndDrive.ViewModels.Account;

namespace NumAndDrive.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize]
    public class UserProfile : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IStatusRepository _statusRepository;
        private readonly IDriverTypeRepository _driverTypeRepository;

        public UserProfile(UserManager<User> userManager, IStatusRepository statusRepository, IDriverTypeRepository driverTypeRepository)
        {
            _userManager = userManager;
            _statusRepository = statusRepository;
            _driverTypeRepository = driverTypeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user.FirstConnection)
                return RedirectToAction("FirstConnection");

            if (user != null)
            {
                var status = await _statusRepository.GetStatusByUserIdAsync(user.CurrentStatusId);
                var driverType = await _driverTypeRepository.GetDriverTypeByUserIdAsync(user.CurrentDriverTypeId);

                var userViewModel = new UserProfileViewModel
                {
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    UserStatus = status,
                    UserDriverType = driverType
                };
                return View(userViewModel);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> FirstConnection()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var allStatus = await _statusRepository.GetAllStatusesAsync();
            var allDriverTypes = await _driverTypeRepository.GetAllDriverTypesAsync();
            var userInformation = new FirstConnectionViewModel
            {
                UserId = user.Id,
                Statuses = allStatus,
                DriverTypes = allDriverTypes
            };

            return View(userInformation);
        }

        [HttpPost]
        public async Task<IActionResult> FirstConnection(FirstConnectionViewModel datas)
        {
            if (!ModelState.IsValid) return View(datas);

            var user = await _userManager.FindByIdAsync(datas.UserId);

            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, datas.OldPassword, datas.ConfirmedNewPassword);
                if (result.Succeeded)
                {
                    user.CurrentStatusId = datas.NewStatusId;
                    user.CurrentDriverTypeId = datas.NewDriverTypeId;
                    user.FirstConnection = false;
                    await _userManager.UpdateAsync(user);
                     return RedirectToAction("Index");
                }
                return View(datas);
            }
            return RedirectToAction("FirstConnection", datas);
        }

        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user != null)
            {
                var status = await _statusRepository.GetStatusByUserIdAsync(user.CurrentStatusId);
                var driverType = await _driverTypeRepository.GetDriverTypeByUserIdAsync(user.CurrentDriverTypeId);

                var editUserProfileViewModel = new EditUserProfileViewModel
                {
                    Statuses = await _statusRepository.GetAllStatusesAsync(),
                    DriverTypes = await _driverTypeRepository.GetAllDriverTypesAsync(),
                    NewStatusId = status.StatusId,
                    NewDriverTypeId = driverType.DriverTypeId,
                };
                return View(editUserProfileViewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditUserProfileViewModel editUserProfileViewModel)
        {
            if (!ModelState.IsValid) return View(editUserProfileViewModel);

            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user != null)
            {
                user.CurrentStatusId = editUserProfileViewModel.NewStatusId;
                user.CurrentDriverTypeId = editUserProfileViewModel.NewDriverTypeId;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index");
            }
            return View(editUserProfileViewModel);

        }
    }
}
