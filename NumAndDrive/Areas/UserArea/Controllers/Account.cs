using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;

namespace NumAndDrive.UserArea.Controllers
{
    [Area("UserArea")]
    [Authorize]
    public class Account : Controller
    {
        private readonly SignInManager<User> _signInManager;

        public Account(UserManager<User> userManager, SignInManager<User> signInManager, IDriverTypeRepository driverTypeRepository, IStatusRepository statusRepository)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
