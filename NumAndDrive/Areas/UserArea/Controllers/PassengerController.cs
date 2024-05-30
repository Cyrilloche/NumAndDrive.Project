using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NumAndDrive.Areas.UserArea.Services.Interfaces;
using NumAndDrive.Areas.UserArea.ViewModels.Passenger;

namespace NumAndDrive.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize]
    public class PassengerController : Controller
    {
        private readonly IPassengerService _passengerService;

        public PassengerController(IPassengerService passengerService)
        {
            _passengerService = passengerService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new PassengerIndexViewModel();
            await _passengerService.DisplayPassengerHomePage(model);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResearchTravel(PassengerIndexViewModel datas)
        {
            if (!ModelState.IsValid)
            {
                await _passengerService.DisplayPassengerHomePage(datas);
                return View(datas);
            }

            var model = await _passengerService.DisplayResultOfResearch(datas);
           
            return View(model);
        }

        public async Task<IActionResult> TravelDetailsPartial(int travelId)
        {
            var model = new TravelDetailsPartialViewModel();
            await _passengerService.FillTravelDetailsPartialView(model, travelId);
            return PartialView("_TravelDetails",model);
        }

        public async Task<IActionResult> TravelReservation(int travelId)
        {
            var model = new ReservationTravelViewModel();
            await _passengerService.FillReservationTravelViewModel(model, travelId);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmReservation(int travelId)
        {
            await _passengerService.ConfirmTravelReservation(travelId);
            return RedirectToAction("Index");
        }
    }
}
