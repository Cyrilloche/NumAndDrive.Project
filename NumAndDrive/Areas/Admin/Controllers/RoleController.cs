using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly NumAndDriveContext _context;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, NumAndDriveContext context)
        {
            _roleManager = roleManager;
            _userManager = userManager;
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
            if(roles != null)
            {
                var datasToReturn = new IndexRoleViewModel
                {
                    Roles = roles
                };
            return View(datasToReturn);
            }
            return RedirectToAction("Index", "Home");
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

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, IndexRoleViewModel datas)
        {
            if (!ModelState.IsValid)
                return View(id, datas);

            var role = await _roleManager.FindByIdAsync(id);

            if (role != null)
            {
                role.Name = datas.NewNameRole;

                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    DisplayErrors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", _roleManager.Roles);
        }

        // POST: RoleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    DisplayErrors(result);
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", _roleManager.Roles);
        }
    }
}
