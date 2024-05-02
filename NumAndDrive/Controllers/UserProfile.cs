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
        private readonly IStatusRepository _statusRepository;
        private readonly IDriverTypeRepository _driverTypeRepository;

        public UserProfile(UserManager<User> userManager, IStatusRepository statusRepository, IDriverTypeRepository driverTypeRepository)
        {
            _userManager = userManager;
            _statusRepository = statusRepository;
            _driverTypeRepository = driverTypeRepository;
        }

        public IStatusRepository StatusRepository { get; }
        public IDriverTypeRepository DriverTypeRepository { get; }

        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);

            var user = await _userManager.FindByIdAsync(userId);


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
    }
}
