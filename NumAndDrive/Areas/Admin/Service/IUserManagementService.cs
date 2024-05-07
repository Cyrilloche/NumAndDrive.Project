namespace NumAndDrive.Areas.Admin.Service
{
    public interface IUserManagementService
    {
        Task ReadAndCreateUsersAsync(IFormFile fileName);
    }
}
