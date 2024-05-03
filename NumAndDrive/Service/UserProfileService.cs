using NumAndDrive.Repository.Interfaces;
using NumAndDrive.ViewModels.UserProfile;

namespace NumAndDrive.Service
{
    public class UserProfileService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IDriverTypeRepository _driverTypeRepository;

        public UserProfileService(IStatusRepository statusRepository, IDriverTypeRepository driverTypeRepository)
        {
            _statusRepository = statusRepository;
            _driverTypeRepository = driverTypeRepository;
        }

        //public Task<UserProfileViewModel> GetAllUserInformation(string userId)
        //{
        //    var userProfileViewModel = new UserProfileViewModel
        //    {

        //    };
        //}

    }
}
