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
                var confirmEmail = new ConfirmEmailViewModel();

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
                    ModelState.AddModelError("Login", "Votre compte est temporairement verrouillé");
                }
                else
                {
                    ModelState.AddModelError("Login", "La connexion a échouée");
                }
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailViewModel confirmEmail)
        {
            var user = await _userManager.FindByIdAsync(confirmEmail.UserId);

            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, confirmEmail.Token);

                if (result.Succeeded)
                {
                    confirmEmail.Message = "Adresse mail confirmée. Vous pouvez maintenant vous connecter à botre application";
                    return View(confirmEmail);
                }
            }
            confirmEmail.Message = "Échec lors de la vérification de l'adresse mail";
            return View(confirmEmail);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

    }
}
