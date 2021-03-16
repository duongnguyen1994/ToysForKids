using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysForKids.Models.ViewModels;

namespace ToysForKids.Services
{
    public interface IProductService
    {
        public List<ProductCreateViewModel> GetAllProduct();
        public ProductCreateViewModel Get(int id);
        public bool Edit(ProductCreateViewModel request);
        public bool Create(ProductCreateViewModel request);
        public bool Delete(ProductCreateViewModel request);
    }
}
