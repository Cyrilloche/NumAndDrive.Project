using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NumAndDrive.Areas.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize]
    public class PassengerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
