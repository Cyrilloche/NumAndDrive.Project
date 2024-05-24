using NumAndDrive.Areas.UserArea.ViewModels.Passenger;
using NumAndDrive.Models;

namespace NumAndDrive.Areas.UserArea.Services.Interfaces
{
    public interface IPassengerService
    {
        Task DisplayPassengerHomePage(PassengerIndexViewModel model);
        Task<ResearchViewModel> DisplayResultOfResearch(PassengerIndexViewModel datas);
        Task FillTravelDetailsPartialView(TravelDetailsPartialViewModel model, int travelId);
    }
}
