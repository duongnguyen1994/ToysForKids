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
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext context;

        public CategoryService(AppDbContext context)
        {
            this.context = context;
        }

        public bool Create(CategoryViewModel request)
        {
            try
            {
                var category = new Category();
                category.CategoryName = request.CategoryName;
                context.Categories.Add(category);
                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(CategoryViewModel request)
        {
            try
            {
                var category = context.Categories.Find(request.CategoryId);
                context.Categories.Remove(category);
                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(CategoryViewModel request)
        {
            try
            {
                var category = context.Categories.Find(request.CategoryId);
                category.CategoryName = request.CategoryName;
                if (request.Products != null)
                    category.Products = request.Products;
                context.Update(category);
                return context.SaveChanges() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public CategoryViewModel Get(int id)
        {
            return (from c in context.Categories.Include(p => p.Products)
                    where c.CategoryId == id
                    select new CategoryViewModel()
                    {
                        CategoryId = c.CategoryId,
                        Products = c.Products,
                        CategoryName = c.CategoryName
                    }).FirstOrDefault();
        }

        public List<CategoryViewModel> GetAll()
        {
            var categories = (from c in context.Categories.Include(p=>p.Products)
                              select new CategoryViewModel()
                              {
                                  CategoryId = c.CategoryId,
                                  CategoryName = c.CategoryName,
                                  Products = c.Products
                              }).ToList();
            return categories;
        }
    }
}
