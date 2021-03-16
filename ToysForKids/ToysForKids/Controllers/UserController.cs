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
    public class UserController : Controller
    {
        private readonly UserManager<AppIdentityUser> userManager;

        public UserController(UserManager<AppIdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            var user = userManager.Users;
            var model = user.Select(u => new UserViewModel()
            {
                Address = u.Address,
                Email = u.Email,
                Fullname = u.Fullname,
                PhoneNumber = u.PhoneNumber,
                UserId = u.Id
            });
            return View(model);
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
                             UserId = u.Id
                         }).FirstOrDefault();
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(RegisterViewModel model)
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
                    return RedirectToAction("Index", "User");
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
        public async Task<IActionResult> EditUser(string id)
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
        public async Task<IActionResult> EditUser(UserViewModel model)
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
