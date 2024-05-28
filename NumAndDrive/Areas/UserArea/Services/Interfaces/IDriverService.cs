using NumAndDrive.Areas.UserArea.ViewModels.Driver;

namespace NumAndDrive.Areas.UserArea.Services.Interfaces
{
    public interface IDriverService
    {
        Task FillDriverIndexViewModel(DriverIndexViewModel model);
        Task FillCreateTravelViewModelAsync(CreateTravelViewModel model);
        Task<bool> CreateTravelAsync(CreateTravelViewModel datas);
    }
}
