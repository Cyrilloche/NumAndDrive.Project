using Microsoft.AspNetCore.Identity;
using NumAndDrive.Areas.UserArea.Services.Interfaces;
using NumAndDrive.Areas.UserArea.ViewModels.UserProfile;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;
using NumAndDrive.Services.Interfaces;

namespace NumAndDrive.Areas.UserArea.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly UserManager<User> _userManager;
        private readonly IStatusRepository _statusRepository;
        private readonly IDriverTypeRepository _driverTypeRepository;
        private readonly ICurrentUserService _currentUserService;

        public UserProfileService(UserManager<User> userManager, IStatusRepository statusRepository, IDriverTypeRepository driverTypeRepository, ICurrentUserService currentUserService)
        {
            _userManager = userManager;
            _statusRepository = statusRepository;
            _driverTypeRepository = driverTypeRepository;
            _currentUserService = currentUserService;
        }

        public async Task<IdentityResult> CompleteFirstUserProfileAsync(FirstConnectionViewModel datas)
        {
            var user = await _userManager.FindByIdAsync(datas.UserId);

            if (user == null)
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });

            var result = await _userManager.ChangePasswordAsync(user, datas.OldPassword, datas.ConfirmedNewPassword);
            if (result.Succeeded)
            {
                user.CurrentStatusId = datas.NewStatusId;
                user.CurrentDriverTypeId = datas.NewDriverTypeId;
                user.FirstConnection = false;
                await _userManager.UpdateAsync(user);
            }
            return result;

        }

        public async Task FillFirstConnectionViewModelAsync(FirstConnectionViewModel model)
        {
            var user = await _currentUserService.GetCurrentUserAsync();

            model.UserId = user.Id;
            model.Statuses = await _statusRepository.GetAllStatusesAsync();
            model.DriverTypes = await _driverTypeRepository.GetAllDriverTypesAsync();
        }

        public async Task FillIndexViewModelAsync(UserProfileViewModel datas)
        {
            var user = await _currentUserService.GetCurrentUserAsync();

            if (user != null)
            {
                datas.Firstname = user.Firstname;
                datas.Lastname = user.Lastname;
                datas.UserStatus = user.CurrentStatus;
                datas.UserDriverType = user.CurrentDriverType;
            }
        }

        public async Task FillUpdateViewModelAsync(EditUserProfileViewModel datas)
        {
            var user = await _currentUserService.GetCurrentUserAsync();

            if (user != null)
            {
                datas.Statuses = await _statusRepository.GetAllStatusesAsync();
                datas.DriverTypes = await _driverTypeRepository.GetAllDriverTypesAsync();
                datas.StatusId = user.CurrentStatus.StatusId;
                datas.DriverTypeId = user.CurrentDriverType.DriverTypeId;
            }
        }

        public async Task<IdentityResult> UpdateUserProfileAsync(EditUserProfileViewModel datas)
        {
            var user = await _currentUserService.GetCurrentUserAsync();

            if (user == null)
                return IdentityResult.Failed(new IdentityError { Description = "User not found" });

            user.CurrentStatusId = datas.StatusId;
            user.CurrentDriverTypeId = datas.DriverTypeId;

            return await _userManager.UpdateAsync(user);
        }
    }
}
