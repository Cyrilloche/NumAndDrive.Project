using Microsoft.AspNetCore.Identity;
using NumAndDrive.Areas.UserArea.ViewModels.UserProfile;
using NumAndDrive.Models;

namespace NumAndDrive.Areas.UserArea.Services.Interfaces
{
    public interface IUserProfileService
    {
        Task<IdentityResult> UpdateUserProfile(EditUserProfileViewModel datas);
        Task FillUpdateViewModel(EditUserProfileViewModel model);
        Task FillIndexViewModel(UserProfileViewModel model);
        Task FillFirstConnectionViewModel(FirstConnectionViewModel model);
        Task<IdentityResult> CompleteFirstUserProfile(FirstConnectionViewModel datas);
    }
}
