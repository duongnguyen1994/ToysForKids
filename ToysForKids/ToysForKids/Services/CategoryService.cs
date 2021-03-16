using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysForKids.DbContexts;
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
        public List<CategoryViewModel> GetAllCategory()
        {
            var category = context.Categories;
            return (from c in category
                    select new CategoryViewModel()
                    {
                        CategoryId = c.CategoryId,
                        CategoryName = c.CategoryName
                    }).ToList();
        }
    }
}
