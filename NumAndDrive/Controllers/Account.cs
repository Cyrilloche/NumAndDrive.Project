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


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid) return View(registerViewModel);

            var user = new User
            {
                UserName = registerViewModel.Email,
                Email = registerViewModel.Email
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (result.Succeeded)
            {
                var confirmEmail = new ConfirmEmailViewModel();

                var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                confirmEmail.UserId = user.Id ?? "";
                confirmEmail.Token = confirmationToken ?? "";

                var confirmationLink = Url.Action("FirstConnection", "Account",
                    values: new { confirmEmail.UserId, token = confirmationToken });


                confirmEmail.ConfirmationLink = confirmationLink ?? "";

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

        [HttpGet]
        public async Task<IActionResult> FirstConnection(ConfirmEmailViewModel datas)
        {
            var allStatus = await _statusRepository.GetAllStatusesAsync();
            var allDriverTypes = await _driverTyperepository.GetAllDriverTypesAsync();
            var userInformation = new FirstConnectionViewModel
            {
                UserId = datas.UserId,
                Statuses = allStatus,
                DriverTypes = allDriverTypes
            };

            return View(userInformation);
        }

        [HttpPost]
        public async Task<IActionResult> FirstConnection(FirstConnectionViewModel datas)
        {
            if (!ModelState.IsValid)
                return View(datas);

            var user = await _userManager.FindByIdAsync(datas.UserId);

            if (user == null)
                return RedirectToAction("FirstConnection", datas);

            var result = await _userManager.ConfirmEmailAsync(user, datas.Token);

            if (!result.Succeeded)
                return RedirectToAction("FirstConnection", datas);

            user.Firstname = datas.NewFirstname;
            user.Lastname = datas.NewLastname;
            user.CurrentStatusId = datas.NewStatusId;
            user.CurrentDriverTypeId = datas.NewDriverTypeId;

            await _userManager.UpdateAsync(user);
            return RedirectToAction("Login");
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

            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("Login", "Votre compte est temporairement verrouillé");
                }
                else
                {
                    ModelState.AddModelError("Login", "La connexion a échouée");
                }
            }

            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult ConfirmEmail(ConfirmEmailViewModel confirmEmail)
        {
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
