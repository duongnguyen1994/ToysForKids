using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysForKids.DbContexts;
using ToysForKids.Models.ViewModels;

namespace ToysForKids.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly AppDbContext context;

        public OrderDetailService(AppDbContext context)
        {
            this.context = context;
        }
        public List<OrderDetailView> Get(int orderId)
        {
            var orderDetail = context.OrderDetails.Where(od => od.OrderRefId == orderId).ToList();
            return (from od in orderDetail
                    select new OrderDetailView()
                    {
                        OrderId = od.OrderRefId,
                        ProductId = od.ProductRefId,
                        Quantity = od.Quantity
                    }).ToList();
        }
    }
}
