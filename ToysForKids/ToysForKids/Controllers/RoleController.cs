using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysForKids.Models.ViewModels;
using ToysForKids.Services;

namespace ToysForKids.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var roles = roleManager.Roles;
            var model = new List<RoleViewModel>();
            model = roles.Select(r => new RoleViewModel()
            {
                RoleId = r.Id,
                RoleName = r.Name
            }).ToList();
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleCreateViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await roleManager.CreateAsync(new IdentityRole()
                {
                    Name = model.RoleName
                });
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Role");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var editRole = new RoleEditViewModel()
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                return View(editRole);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditRole(RoleEditViewModel model)
        {
            if(ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(model.RoleId);
                if(role !=null)
                {
                    role.Name = model.RoleName;
                    var result = await roleManager.UpdateAsync(role);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index","Role");
                    }
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("",error.Description);
                    }
                }
            }
            return View();
        }
        public async Task<IActionResult> DeleteRole(string id)
        {
            var delRole = await roleManager.FindByIdAsync(id);
            if(delRole != null)
            {
                var result = await roleManager.DeleteAsync(delRole);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Role");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
    }
}
