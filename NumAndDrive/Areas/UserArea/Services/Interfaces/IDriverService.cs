using NumAndDrive.Areas.UserArea.ViewModels.Driver;

namespace NumAndDrive.Areas.UserArea.Services.Interfaces
{
    public interface IDriverService
    {
        Task FillDriverIndexViewModel(DriverIndexViewModel model);
        Task FillCreateTravelViewModelAsync(CreateTravelViewModel model);
        Task FillCustomizeTravelViewModel(CustomizeTravelViewModel model, int travelId);
        Task<bool> CreateTravelAsync(CreateTravelViewModel datas);
        Task AcceptReservationAsync(int travelId, string userId);
    }
}
