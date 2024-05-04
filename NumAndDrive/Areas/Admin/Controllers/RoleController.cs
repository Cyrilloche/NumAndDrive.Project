using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NumAndDrive.Areas.Admin.ViewModels.Role;
using NumAndDrive.Database;
using NumAndDrive.Models;

namespace NumAndDrive.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _usermanager;
        private readonly NumAndDriveContext _context;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<User> usermanager, NumAndDriveContext context)
        {
            _roleManager = roleManager;
            _usermanager = usermanager;
            _context = context;
        }

        private void DisplayErrors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        // GET: RoleController
        public async Task<ActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }

        // GET: RoleController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var usersWithThisRole = await _context.UserRoles.Where(u => u.RoleId == id).ToListAsync();
            var role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var datasToReturn = new DetailsRoleViewModel
                {
                    Users = usersWithThisRole.Count(),
                    Role = role
                };
                return View(datasToReturn);
            }
            return View();
        }

        // GET: RoleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateRoleViewModel datas)
        {
            if (!ModelState.IsValid)
                return View(datas);

            var result = await _roleManager.CreateAsync(new IdentityRole(datas.RoleName));
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                DisplayErrors(result);
                return View(datas);

            }

        }

        // GET: RoleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
