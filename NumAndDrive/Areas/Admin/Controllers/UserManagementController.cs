using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NumAndDrive.Areas.Admin.ViewModels.UserManagement;
using NumAndDrive.Database;
using NumAndDrive.Models;
using NumAndDrive.Repository.Interfaces;
using NumAndDrive.ViewModels.Account;

namespace NumAndDrive.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles="Admin")]
    public class UserManagementController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly NumAndDriveContext _context;
        private readonly IStatusRepository _statusRepository;
        private readonly IDriverTypeRepository _driverTypeRepository;

        public UserManagementController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, NumAndDriveContext context, IStatusRepository statusRepository, IDriverTypeRepository driverTypeRepository)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _context = context;
            _statusRepository = statusRepository;
            _driverTypeRepository = driverTypeRepository;
        }

        private void DisplayErrors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        // GET: UserManagementController
        public async Task<ActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            if (users != null)
            {
                var datasToReturn = new IndexUserViewModel
                {
                    Users = users
                };
                return View(datasToReturn);
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: UserManagementController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var userRole = await _context.UserRoles.FirstOrDefaultAsync(u => u.UserId == id);
                var currentUserRole = await _roleManager.FindByIdAsync(userRole.RoleId);
                var status = await _statusRepository.GetStatusByUserIdAsync(user.CurrentStatusId);
                var driverType = await _driverTypeRepository.GetDriverTypeByUserIdAsync(user.CurrentDriverTypeId);

                var statusName = status != null ? status.Name : "";
                var driverTypeName = driverType != null ? driverType.Name : "";

                var datasToReturn = new DetailsUserManagementViewModel
                {
                    UserId = user.Id,
                    Lastname = user.Lastname,
                    Firstname = user.Firstname,
                    CurrentRole = currentUserRole != null ? currentUserRole.Name : "",
                    Email = user.Email,
                    NormalizeEmail = user.NormalizedEmail,
                    IsEmailConfirmed = user.EmailConfirmed,
                    IsPhoneNumberConfirmed = user.PhoneNumberConfirmed,
                    AccessFaildCount = user.AccessFailedCount,
                    CurrentStatus = statusName,
                    CurrentDriverType = driverTypeName
                };
                return View(datasToReturn);
            }
            return View();
        }

        // GET: UserManagementController/Create
        public async Task<ActionResult> Create()
        {
            var datasToReturn = new CreateUserManagementViewModel
            {
                Roles = await _roleManager.Roles.ToListAsync()
            };
            return View(datasToReturn);
        }

        // POST: UserManagementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateUserManagementViewModel datas)
        {
            if (!ModelState.IsValid)
                return View(datas);

            var user = new User
            {
                UserName = datas.Email,
                Email = datas.Email
            };

            var result = await _userManager.CreateAsync(user, datas.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, datas.RoleName);

                var confirmEmail = new ConfirmEmailViewModel();

                var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                confirmEmail.UserId = user.Id ?? "";
                confirmEmail.Token = confirmationToken ?? "";

                var confirmationLink = Url.Action("FirstConnection", "Account",
                    new { confirmEmail.UserId, token = confirmationToken, area = "" },
                    HttpContext.Request.Scheme,
                    HttpContext.Request.Host.Value);


                confirmEmail.ConfirmationLink = confirmationLink ?? "";

                return RedirectToAction("Index");
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

        // GET: UserManagementController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                var roles = await _roleManager.Roles.ToListAsync();
                var userRole = await _context.UserRoles.FirstOrDefaultAsync(u => u.UserId == id);
                var currentUserRole = await _roleManager.FindByIdAsync(userRole.RoleId);
                var statuses = await _statusRepository.GetAllStatusesAsync();
                var driverTypes = await _driverTypeRepository.GetAllDriverTypesAsync();
                var status = await _statusRepository.GetStatusByUserIdAsync(user.CurrentStatusId);
                var driverType = await _driverTypeRepository.GetDriverTypeByUserIdAsync(user.CurrentDriverTypeId);

                var datasToReturn = new EditUserManagementViewModel
                {
                    UserId = user.Id,
                    Lastname = user.Lastname,
                    Firstname = user.Firstname,
                    CurrentRole = userRole.RoleId,
                    NewStatusId = status != null ? status.StatusId : 0,
                    NewDriverTypeId = driverType != null ?driverType.DriverTypeId : 0,
                    Email = user.Email,
                    Statuses = statuses,
                    DriverTypes = driverTypes,
                    Roles = roles
                };

                return View(datasToReturn);
            }
            return View();
        }

        // POST: UserManagementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditUserManagementViewModel datas)
        {
            if (!ModelState.IsValid)
                return View(datas);

            var user = await _userManager.FindByIdAsync(datas.UserId);

            if (user != null)
            {
                user.Lastname = datas.Lastname;
                user.Firstname = datas.Firstname;
                user.Email = datas.Email;
                user.CurrentStatusId = datas.NewStatusId;
                user.CurrentDriverTypeId = datas.NewDriverTypeId;

                var userRole = await _context.UserRoles.FirstOrDefaultAsync(u => u.UserId == datas.UserId);
                if (userRole != null)
                    userRole.RoleId = datas.NewRoleId;

                var result = await _userManager.UpdateAsync(user);
                await _context.SaveChangesAsync();

                if (result.Succeeded)
                    return RedirectToAction("Index", _userManager.Users);
                else
                    DisplayErrors(result);
            }
            else
                ModelState.AddModelError("", "No user found");
            return View("Index");
        }


        // POST: UserManagementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    DisplayErrors(result);
            }
            else
                ModelState.AddModelError("", "No user found");
            return View("Index");
        }
    }
}
