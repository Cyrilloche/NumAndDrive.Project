using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NumAndDrive.Areas.UserArea.Services.Interfaces;
using NumAndDrive.Areas.UserArea.ViewModels.Driver;

namespace NumAndDrive.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize]
    public class DriverController : Controller
    {
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DriverIndexViewModel();
            await _driverService.FillDriverIndexViewModel(model);
            return View(model);
        }

        public async Task<IActionResult> CreateGoTravel()
        {
            var model = new CreateTravelViewModel();
            await _driverService.FillCreateTravelViewModelAsync(model);
            return View(model);
        }
        public async Task<IActionResult> CreateReturnTravel()
        {
            var model = new CreateTravelViewModel();
            await _driverService.FillCreateTravelViewModelAsync(model);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateTravel(CreateTravelViewModel datas)
        {
            if (!ModelState.IsValid)
            {
                await _driverService.FillCreateTravelViewModelAsync(datas);
                return RedirectToAction("CreateGoTravel");
            }

            if (!await _driverService.CreateTravelAsync(datas))
            {
                datas.ErrorMessage = "L'utilisateur n'est pas authorisé à créer un trajet";
                await _driverService.FillCreateTravelViewModelAsync(datas);
                return RedirectToAction("CreateGoTravel");
            }
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> CustomizeReservation(int travelId)
        {
            var model = new CustomizeTravelViewModel();
            await _driverService.FillCustomizeTravelViewModel(model, travelId);
            return View(model);
        }

        public async Task<IActionResult> AcceptReservation(int travelId, string userId)
        {
            await _driverService.AcceptReservationAsync(travelId, userId);
            return RedirectToAction("Index");
        }
    }
}
