using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysForKids.Models.ViewModels;

namespace ToysForKids.Services
{
    public interface ICategoryService
    {
        public List<CategoryViewModel> GetAll();
        public CategoryViewModel Get(int id);
        public bool Edit(CategoryViewModel request);
        public bool Create(CategoryViewModel request);
        public bool Delete(CategoryViewModel request);
    }
}
