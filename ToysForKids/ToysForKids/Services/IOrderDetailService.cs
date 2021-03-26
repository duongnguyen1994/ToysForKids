using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysForKids.Models.ViewModels;

namespace ToysForKids.Services
{
    public interface IOrderDetailService
    {
        public List<OrderDetailView> Get(int orderId);
    }
}
