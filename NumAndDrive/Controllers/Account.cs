using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;
using NumAndDrive.ViewModels.Account;

namespace NumAndDrive.Controllers
{
    public class Account : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IStatusRepository _statusRepository;
        private readonly IDriverTypeRepository _driverTyperepository;

        public Account(UserManager<User> userManager, SignInManager<User> signInManager, IDriverTypeRepository driverTypeRepository, IStatusRepository statusRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _driverTyperepository = driverTypeRepository;
            _statusRepository = statusRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
                return View(loginViewModel);

            var result = await _signInManager.PasswordSignInAsync(
                loginViewModel.UserName,
                loginViewModel.Password,
                false,
                false);

            if (result.Succeeded)
            {
                if (User.IsInRole("Admin"))
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                return RedirectToAction("Index", "Home");
            }
            else
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("Login", "Votre compte est temporairement verrouillé");
                }
                else if (result.IsNotAllowed)
                {
                    ModelState.AddModelError("Login", "L'adresse mail n'est pas verifiée");
                }
                else
                {
                    ModelState.AddModelError("Login", "La connexion a échouée");
                }
            }

            return View(loginViewModel);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel datas)
        {
            if (!ModelState.IsValid) return View(datas);

            var user = await _userManager.FindByEmailAsync(datas.Email);

            if (user != null)
            {

                var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                var resetLink = Url.Action("ResetPassword", "Account",
                    values: new { email = user.Email, token = resetPasswordToken });

                var resetPassword = new SimulateEmailViewModel
                {
                    Token = await _userManager.GeneratePasswordResetTokenAsync(user),
                    Email = user.Email,
                    Link = resetLink ?? ""
                };
                return RedirectToAction("SimulateResetPasswordMail", resetPassword);
            }

            return View();
        }

        public IActionResult SimulateResetPasswordMail(SimulateEmailViewModel datas)
        {
            return View(datas);
        }

        [HttpGet]
        public IActionResult ResetPassword(string token, string email)
        {
            var resetPassword = new ResetPasswordViewModel
            {
                Email = email,
                Token = token
            };
            return View(resetPassword);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Resetpassword(ResetPasswordViewModel datas)
        {
            if (!ModelState.IsValid) return View(datas);

            var user = await _userManager.FindByEmailAsync(datas.Email);

            if (user == null) return RedirectToAction(nameof(Index));


            var result = await _userManager.ResetPasswordAsync(user, datas.Token, datas.ConfirmPassword);
            if (result.Succeeded)
            {
                var toReturn = new ResetPasswordViewModel
                {
                    IsPasswordRest = true

                };
                return View(toReturn);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }
                return View();
            }
        }
    }
}
