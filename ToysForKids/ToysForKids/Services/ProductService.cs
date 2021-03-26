using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysForKids.DbContexts;
using ToysForKids.Models.Entities;
using ToysForKids.Models.ViewModels;

namespace ToysForKids.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext context;

        public ProductService(AppDbContext context)
        {
            this.context = context;
        }

        public bool Create(ProductViewModel request)
        {
            try
            {
                var product = new Product()
                {
                    CategoryId = request.CategoryId,
                    Description = request.Description,
                    UnitPrice = request.UnitPrice,
                    FileAvatarName = request.FileAvatarName,
                    ProductName = request.ProductName,
                    QuantityPerUnit = request.QuantityPerUnit,
                    UnitInStock = request.QuantityPerUnit
                };
                context.Add(product);
                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }           
        }
        public bool Edit(ProductViewModel request)
        {
            try
            {
                var editProduct = context.Products.Find(request.ProductId);
                editProduct.CategoryId = request.CategoryId;
                editProduct.Description = request.Description;
                editProduct.FileAvatarName = request.FileAvatarName;
                editProduct.ProductName = request.ProductName;
                editProduct.QuantityPerUnit = request.QuantityPerUnit;
                editProduct.UnitInStock = request.UnitInStock;
                editProduct.UnitPrice = request.UnitPrice;
                context.Attach(editProduct);
                context.Entry<Product>(editProduct).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(ProductViewModel request)
        {
            try
            {
                var delProduct = context.Products.Find(request.ProductId);
                context.Remove(delProduct);
                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ProductViewModel Get(int id)
        {
            return (from p in context.Products
                    where p.ProductId == id
                    select new ProductViewModel()
                    {
                        CategoryId = p.CategoryId,
                        Description = p.Description,
                        FileAvatarName = p.FileAvatarName,
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        QuantityPerUnit = p.QuantityPerUnit,
                        UnitInStock = p.UnitInStock,
                        UnitPrice = p.UnitPrice
                    }).FirstOrDefault();
        }

        public List<ProductViewModel> GetAll()
        {
            var products = context.Products.ToList();
            return (from p in products
                    select new ProductViewModel()
                    {
                        Description = p.Description,
                        FileAvatarName = p.FileAvatarName,
                        ProductId = p.ProductId,
                        ProductName = p.ProductName,
                        QuantityPerUnit = p.QuantityPerUnit,
                        UnitInStock = p.UnitInStock,
                        UnitPrice = p.UnitPrice,
                        CategoryId = p.CategoryId
                    }).ToList();
        }
    }
}
