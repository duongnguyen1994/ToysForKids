using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysForKids.Models.ViewModels;

namespace ToysForKids.Services
{
    public interface IProductService
    {
        public List<ProductViewModel> GetAll();
        public ProductViewModel Get(int id);
        public bool Edit(ProductViewModel request);
        public bool Create(ProductViewModel request);
        public bool Delete(ProductViewModel request);
    }
}
