using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ToysForKids.DbContexts;
using ToysForKids.Models.ViewModels;
using ToysForKids.Services;

namespace ToysForKids.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IWebHostEnvironment environment;
        private readonly AppDbContext context;

        public ProductController(IProductService productService, IWebHostEnvironment environment, AppDbContext context)
        {
            this.productService = productService;
            this.environment = environment;
            this.context = context;
        }
        public IActionResult Index()
        {
            return View(productService.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var fileName = "noimage.jpg";
                if (model.FileUpload != null)
                {
                    var folderPath = Path.Combine(environment.WebRootPath, "images", "products");
                    fileName = $"{Guid.NewGuid()}_{model.FileUpload.FileName}";
                    var filePath = Path.Combine(folderPath, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.FileUpload.CopyToAsync(fileStream);
                    }
                }
                var product = new ProductViewModel()
                {
                    CategoryId = model.CategoryId,
                    Description = model.Description,
                    FileAvatarName = fileName,
                    ProductName = model.ProductName,
                    QuantityPerUnit = model.QuantityPerUnit,
                    UnitPrice = model.UnitPrice
                };
                if (productService.Create(product))
                    return RedirectToAction("Index", "Product");
            }
            return View(model);
        }
        public IActionResult Detail(int id)
        {
            var product = productService.Get(id);
            var model = new ProductViewModel()
            {
                CategoryId = product.CategoryId,
                Description = product.Description,
                FileAvatarName = product.FileAvatarName,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitInStock = product.UnitInStock,
                UnitOnOrder = product.UnitOnOrder,
                UnitPrice = product.UnitPrice
            };
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = productService.Get(id);
            var model = new ProductEditViewModel()
            {
                CategoryId = product.CategoryId,
                Description = product.Description,
                FileAvatarName = product.FileAvatarName,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitInStock = product.UnitInStock,
                UnitOnOrder = product.UnitOnOrder,
                UnitPrice = product.UnitPrice
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existAvatar = model.FileAvatarName;
                if (model.FileUpload != null)
                {
                    if (string.Compare(existAvatar, "noimage.jpg") != 0)
                    {
                        System.IO.File.Delete(Path.Combine(environment.WebRootPath, "images", "Products", existAvatar));
                    }
                    var folderPath = Path.Combine(environment.WebRootPath, "images", "products");
                    var fileName = $"{Guid.NewGuid()}_{model.FileUpload.FileName}";
                    var filePath = Path.Combine(folderPath, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.FileUpload.CopyToAsync(fileStream);
                    }
                    existAvatar = fileName;
                }
                var product = new ProductViewModel()
                {
                    CategoryId = model.CategoryId,
                    Description = model.Description,
                    ProductId = model.ProductId,
                    ProductName = model.ProductName,
                    QuantityPerUnit = model.QuantityPerUnit,
                    UnitInStock = model.UnitInStock,
                    UnitOnOrder = model.UnitOnOrder,
                    UnitPrice = model.UnitPrice,
                    FileAvatarName = existAvatar
                };
                if (productService.Edit(product))
                    return RedirectToAction("Index", "Product");
            }
            return RedirectToAction("Detail", "Product", new { id = model.ProductId });
        }
    }
}
