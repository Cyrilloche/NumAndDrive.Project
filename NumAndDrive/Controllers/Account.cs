using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NumAndDrive.Models;
using NumAndDrive.ViewModels.Account;

namespace NumAndDrive.Controllers
{
    public class Account : Controller
    {
        private readonly UserManager<User> _userManager;

        public Account(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if(!ModelState.IsValid) { return View(registerViewModel); }

            var user = new User
            {
                FirstName = registerViewModel.Firstname,
                Lastname = registerViewModel.Lastname,
                Email = registerViewModel.Email,
                UserName = registerViewModel.Firstname + "_" + registerViewModel.Lastname
            };

            var result = await _userManager.CreateAsync(user,registerViewModel.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("register", error.Description);
                }
            }

            return View("Index");
        }
    }
}
