using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Index(PassengerIndexViewModel datas)
        {
            if (!ModelState.IsValid)
            {
                await _passengerService.DisplayPassengerHomePage(datas);
                return View(datas);
            }
            return RedirectToAction("ResearchTravel", datas);
        }


        public async Task<IActionResult> ResearchTravel()
        {
            return View();
        }
    }
}
