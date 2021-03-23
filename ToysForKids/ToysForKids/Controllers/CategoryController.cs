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
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public IActionResult Index()
        {
            return View(categoryService.GetAll());
        }
        public IActionResult Detail(int id)
        {
            return View(categoryService.Get(id));
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = categoryService.Get(id);
            return View(category);
        }
        //[HttpPost]
        //public async Task<IActionResult> Edit(CategoryViewModel model)
        //{
        //    if(ModelState.IsValid)
        //    {
        //        var category = new CategoryViewModel()
        //        {
        //            CategoryId = model.CategoryId,
        //            CategoryName = model.CategoryName,
        //            Products = model.Products
        //        };
        //        if(categoryService.Edit(category))
        //            return RedirectToAction("Index", "")
        //    }
        //}
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CategoryViewModel model)
        {
            if(ModelState.IsValid)
            {
                if (categoryService.Create(model))
                    return View();
            }
            return View(model);
        }
    }
}
