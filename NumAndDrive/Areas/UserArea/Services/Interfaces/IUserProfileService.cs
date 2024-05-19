using Microsoft.AspNetCore.Identity;
using NumAndDrive.Areas.UserArea.ViewModels.UserProfile;

namespace NumAndDrive.Areas.UserArea.Services.Interfaces
{
    public interface IUserProfileService
    {
        Task<IdentityResult> UpdateUserProfileAsync(EditUserProfileViewModel datas);
        Task FillUpdateViewModelAsync(EditUserProfileViewModel model);
        Task FillIndexViewModelAsync(UserProfileViewModel model);
        Task FillFirstConnectionViewModelAsync(FirstConnectionViewModel model);
        Task<IdentityResult> CompleteFirstUserProfileAsync(FirstConnectionViewModel datas);
    }
}
