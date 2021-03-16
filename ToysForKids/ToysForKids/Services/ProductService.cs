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
        public bool Create(ProductCreateViewModel request)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ProductCreateViewModel request)
        {
            throw new NotImplementedException();
        }

        public bool Edit(ProductCreateViewModel request)
        {
            try
            {
                var editproduct = context.Products.Find(request.ProductId);
                editproduct.ProductName = request.ProductName;
                editproduct.Description = request.Description;
                editproduct.FileAvatarName = request.FileAvatarName;
                editproduct.CategoryId = request.CategoryId;
                editproduct.UnitPrice = request.UnitPrice;
                editproduct.UnitInStock = request.UnitInStock;
                editproduct.UnitOnOrder = request.UnitOnOrder;
                editproduct.QuantityPerUnit = request.QuantityPerUnit;
                context.Attach(editproduct);
                context.Entry<Product>(editproduct).State = EntityState.Modified;
                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ProductCreateViewModel Get(int id)
        {
            var product = context.Products.Find(id);
            return new ProductCreateViewModel()
            {
                Description = product.Description,
                FileAvatarName = product.FileAvatarName,
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitInStock = product.UnitInStock,
                UnitOnOrder = product.UnitOnOrder,
                UnitPrice = product.UnitPrice,
                CategoryId = product.CategoryId
            };
        }

        public List<ProductCreateViewModel> GetAllProduct()
        {
            var product = context.Products;
            return (from p in product
                    select new ProductCreateViewModel()
                    {
                        ProductId = p.ProductId,
                        Description = p.Description,
                        ProductName = p.ProductName,
                        QuantityPerUnit = p.QuantityPerUnit,
                        UnitInStock = p.UnitInStock,
                        UnitPrice = p.UnitPrice,
                        UnitOnOrder = p.UnitOnOrder,
                        FileAvatarName = p.FileAvatarName,
                        CategoryId = p.CategoryId
                    }).ToList();
        }
    }
}
