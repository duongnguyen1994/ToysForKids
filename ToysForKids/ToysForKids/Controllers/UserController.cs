using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysForKids.Models.Entities;
using ToysForKids.Models.ViewModels;
using ToysForKids.Services;

namespace ToysForKids.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<AppIdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult UserTable()
        {
            var user = userManager.Users;
            if(user !=null && user.Any())
            {
                var model = new List<UserViewModel>();
                model = user.Select(u => new UserViewModel()
                {
                    Address = u.Address,
                    Email = u.Email,
                    Fullname = u.Fullname,
                    PhoneNumber = u.PhoneNumber,
                    UserId = u.Id
                }).ToList();
                foreach(var u in model)
                {
                    u.RoleName = GetRoleName(u.UserId);
                }
                return View(model);
            }
            return View();
        }
        private string GetRoleName(string userId)
        {
            var user = Task.Run(async () => await userManager.FindByIdAsync(userId)).Result;
            var roles = Task.Run(async () => await userManager.GetRolesAsync(user)).Result;
            return roles != null ? string.Join(", ", roles):"";
        }       
        public IActionResult Profile(string id)
        {
            var users = userManager.Users;
            var model = (from u in users
                         where u.Id == id
                         select new UserEditViewModel()
                         {
                             Address = u.Address,
                             Email = u.Email,
                             Fullname = u.Fullname,
                             PhoneNumber = u.PhoneNumber,
                             UserId = u.Id,
                         }).FirstOrDefault();
            var roleName = GetRoleName(model.UserId);
            var role = Task.Run(async () => await roleManager.FindByNameAsync(roleName)).Result;
            model.RoleId = role.Id;
            return View(model);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateUser()
        {
            ViewBag.Roles = roleManager.Roles;
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppIdentityUser()
                {
                    Address = model.Address,
                    Email = model.Email,
                    UserName = model.Email,
                    Fullname = $"{model.Firstname} {model.Lastname}",
                    PhoneNumber = model.PhoneNumber
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(model.RoleId))
                    {
                        var role = await roleManager.FindByIdAsync(model.RoleId);
                        var addRoleResult = await userManager.AddToRoleAsync(user, role.Name);
                        if(addRoleResult.Succeeded)
                        {
                            return RedirectToAction("UserTable", "User");
                        }
                        foreach(var errors in addRoleResult.Errors)
                        {
                            ModelState.AddModelError("", errors.Description);
                        }
                    }                  
                }
                foreach (var errors in result.Errors)
                {
                    ModelState.AddModelError("", errors.Description);
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }       
        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    user.Address = model.Address;
                    user.Email = model.Email;
                    user.Fullname = model.Fullname;
                    user.UserName = model.Email;
                    user.PhoneNumber = model.PhoneNumber;
                    var result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var roleList = await userManager.GetRolesAsync(user);
                        var delRole = await userManager.RemoveFromRolesAsync(user, roleList);
                        if (!string.IsNullOrEmpty(model.RoleId))
                        {   
                            var role = await roleManager.FindByIdAsync(model.RoleId);
                            var addRoleResult = await userManager.AddToRoleAsync(user, role.Name);
                            if (addRoleResult.Succeeded)
                            {
                                return RedirectToAction("Profile", "User", new { id = model.UserId });
                            }
                            foreach (var errors in addRoleResult.Errors)
                            {
                                ModelState.AddModelError("", errors.Description);
                            }
                        }                       
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return RedirectToAction("Profile", "User", new { id = model.UserId });
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var delUser = await userManager.FindByIdAsync(id);
            if(delUser != null)
            {
                var result = await userManager.DeleteAsync(delUser);
                if(result.Succeeded)
                {
                    return RedirectToAction("UserTable", "User");
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
