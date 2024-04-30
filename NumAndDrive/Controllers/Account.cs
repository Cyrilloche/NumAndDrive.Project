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
        public async Task<IActionResult> Register([Bind("UserName, Email, Password")]RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var user = new User
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (result.Succeeded)
            {
                return View("Home", "Index");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("register", error.Description);
                }
                return View();
            }

        }
    }
}
