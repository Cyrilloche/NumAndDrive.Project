﻿using Microsoft.AspNetCore.Authorization;
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

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CreateGoTravel()
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
                return View(datas);
            }

            if(await _driverService.CreateTravelAsync(datas))
            {
                return RedirectToAction("Index");
            }
            else
            {
                await _driverService.FillCreateTravelViewModelAsync(datas);
                return View(datas);
            }
        }

        public async Task<IActionResult> CreateReturnTravel()
        {
            var model = new CreateTravelViewModel();
            await _driverService.FillCreateTravelViewModelAsync(model);
            return View(model);
        }
    }
}
