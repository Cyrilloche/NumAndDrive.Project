using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NumAndDrive.Areas.UserArea.ViewModels.Driver;
using NumAndDrive.Repository.Interfaces;

namespace NumAndDrive.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize]
    public class DriverController : Controller
    {
        private readonly IFilterRepository _filterRepository;
        private readonly IActivationDayRepository _activationDayRepository;

        public DriverController(IFilterRepository filterRepository, IActivationDayRepository activationDayRepository)
        {
            _filterRepository = filterRepository;
            _activationDayRepository = activationDayRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateTravel()
        {
            var filters = await _filterRepository.GetAllFiltersAsync();
            var activationDays = await _activationDayRepository.GetActivationDays();

            var datasToDisplay = new CreateTravelViewModel
            {
                Filters = filters.ToList(),
                ActivationDays = activationDays.ToList()
            };
            return View(datasToDisplay);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTravel(CreateTravelViewModel datas)
        {
            return View();
        }
    }
}
