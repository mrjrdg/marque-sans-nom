using System.Threading.Tasks;
using ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System.Collections.Generic;
using Models;

namespace EmployeeManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AdministrationController> _logger;

        public AdministrationController(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager, ILogger<AdministrationController> logger
        )
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                 IdentityResult result = await _roleManager.CreateAsync(new IdentityRole() { Name = model.RoleName });

                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles", "Administration");
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);

            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id : {id} cannot be found";
                _logger.LogWarning($"Role with Id : {id} cannot be found");
                return View("Notfound");
            }

            var result = await _roleManager.DeleteAsync(role);

            if (!result.Succeeded)
            {
                ViewBag.ErrorMessage = $"An error has occured while trying to delete the role with id : {id}";
                _logger.LogWarning($"An error has occured while trying to delete the role with id : {id}");
                return View("Error");
            }

            return RedirectToAction("ListRoles", "Administration");
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id : {id} cannot be found";
                _logger.LogWarning($"Role with Id : {id} cannot be found");
                return View("Notfound");
            }
            var model = new EditRoleViewModel()
            {
                Id = role.Id,
                RoleName = role.Name

            };
            foreach (var user in await _userManager.GetUsersInRoleAsync(role.Name))
            {
                model.Users.Add(user.UserName);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return View("Notfound");
            }
            else
            {
                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListRoles");
                }
                foreach (var err in result.Errors)
                {
                    ModelState.AddModelError("", err.Description);
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;
            var role = await _roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                _logger.LogWarning($"Role with Id = {roleId} cannot be found");
                return View("Notfound");
            }
            var model = new List<UserRoleViewModel>();
            foreach (var user in _userManager.Users)
            {
                model.Add(new UserRoleViewModel()
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                    IsSelected = await _userManager
                                 .IsInRoleAsync(user, role.Name)
                });
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(
            List<UserRoleViewModel> users,
            string roleId
        )
        {
            IdentityRole role = await _roleManager.FindByIdAsync(roleId);
            IdentityResult result = null;
            ApplicationUser user = null;
            bool isInRoleResult = false;
            if (role == null)
            {
                return View("Notfound");
            }
            foreach (var u in users)
            {
                user = await _userManager.FindByIdAsync(u.UserId);
                if (user == null)
                {
                    return View("Notfound");
                }
                if ((isInRoleResult = await _userManager.IsInRoleAsync(user, role.Name)) && !u.IsSelected)
                {
                    result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else if (!isInRoleResult && u.IsSelected)
                {
                    result = await _userManager.AddToRoleAsync(user, role.Name);
                }
            }
            return RedirectToAction("ListRoles");
        }
    }
}