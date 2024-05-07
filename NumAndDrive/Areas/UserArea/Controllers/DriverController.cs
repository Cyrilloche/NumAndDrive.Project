using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NumAndDrive.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize]
    public class DriverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateTravel()
        {
            return View();
        }
    }
}
