using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysForKids.Models.ViewModels;

namespace ToysForKids.Services
{
    public interface IOrderService
    {
        public bool CreateOrder(OrderRequest request);
        public List<OrderViewModel> GetAll();
        public List<OrderViewModel> GetByCustomer(string userId);
        public bool Accept(int orderId);
    }
}
