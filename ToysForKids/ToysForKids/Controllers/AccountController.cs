﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysForKids.Models.Entities;
using ToysForKids.Models.ViewModels;

namespace ToysForKids.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppIdentityUser> userManager;
        private readonly SignInManager<AppIdentityUser> signInManager;

        public AccountController(UserManager<AppIdentityUser> userManager, SignInManager<AppIdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if(ModelState.IsValid)
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
                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent:false);
                    return RedirectToAction("Index", "Home");
                }
                foreach(var errors in result.Errors)
                {
                    ModelState.AddModelError("", errors.Description);
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(user.Email, user.Password, user.RemeberPassword, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
