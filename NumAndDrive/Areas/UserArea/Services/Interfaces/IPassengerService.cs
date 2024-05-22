using NumAndDrive.Areas.UserArea.ViewModels.Passenger;

namespace NumAndDrive.Areas.UserArea.Services.Interfaces
{
    public interface IPassengerService
    {
        Task DisplayPassengerHomePage(PassengerIndexViewModel model);
    }
}
