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
        public IActionResult Index()
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
            var user = userManager.Users;
            var model = (from u in user
                         where u.Id == id
                         select new UserViewModel()
                         {
                             Address = u.Address,
                             Email = u.Email,
                             Fullname = u.Fullname,
                             PhoneNumber = u.PhoneNumber,
                             UserId = u.Id,
                         }).FirstOrDefault();
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult UserProfile(string id)
        {
            var user = userManager.Users;
            var model = (from u in user
                         where u.Id == id
                         select new UserViewModel()
                         {
                             Address = u.Address,
                             Email = u.Email,
                             Fullname = u.Fullname,
                             PhoneNumber = u.PhoneNumber,
                             UserId = u.Id,                            
                         }).FirstOrDefault();
            model.RoleName = GetRoleName(id);
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
                            return RedirectToAction("Index", "User");
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
        [HttpGet]
        public async Task<IActionResult> EditProfile(string id)
        {         
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                var editUser = new UserViewModel()
                {
                    Address = user.Address,
                    Email = user.Email,
                    Fullname = user.Fullname,
                    PhoneNumber = user.PhoneNumber,
                    UserId = user.Id
                };
                return View(editUser);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> EditProfile(UserViewModel model)
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
                        return RedirectToAction("Profile", "User", new { id = model.UserId });
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            ViewBag.Roles = roleManager.Roles;
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                var editUser = new UserEditViewModel()
                {
                    Address = user.Address,
                    Email = user.Email,
                    Fullname = user.Fullname,
                    PhoneNumber = user.PhoneNumber,
                    UserId = user.Id
                };
                var roleName = await userManager.GetRolesAsync(user);
                if(roleName != null && roleName.Any())
                {
                    var role = await roleManager.FindByNameAsync(roleName.FirstOrDefault());
                    editUser.RoleId = role.Id;
                }
                return View(editUser);
            }
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditUser(UserEditViewModel model)
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
                                return RedirectToAction("UserProfile", "User", new { id = model.UserId });
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
            return View(model);
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
                    return RedirectToAction("Index", "User");
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
