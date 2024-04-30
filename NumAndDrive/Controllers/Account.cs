using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NumAndDrive.Models;
using NumAndDrive.ViewModels.Account;

namespace NumAndDrive.Controllers
{
    public class Account : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public Account(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
        public async Task<IActionResult> Register([Bind("UserName, Email, Password")] RegisterViewModel registerViewModel)
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
                var confirmEmail = new ConfirmEmail();

                var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                confirmEmail.UserId = user.Id ?? "";
                confirmEmail.Token = confirmationToken ?? "";

                return RedirectToAction("ConfirmEmail", confirmEmail);
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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("UserName, Password")] LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View(loginViewModel);

            var result = await _signInManager.PasswordSignInAsync(
                loginViewModel.UserName,
                loginViewModel.Password,
                false,
                false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("Login", "You are locked out");
                }
                else
                {
                    ModelState.AddModelError("Login", "Failed to login");
                }
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmail confirmEmail)
        {
            var user = await _userManager.FindByIdAsync(confirmEmail.UserId);

            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, confirmEmail.Token);

                if (result.Succeeded)
                {
                    confirmEmail.Message = "Email adress is succefully confirmed, you can now try to login";
                    return View(confirmEmail);
                }
            }
            confirmEmail.Message = "Failed to validate email";
            return View(confirmEmail);
        }
    }
}
