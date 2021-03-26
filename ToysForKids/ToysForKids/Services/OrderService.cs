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
    public class OrderService : IOrderService
    {
        private readonly AppDbContext context;

        public OrderService(AppDbContext context)
        {
            this.context = context;
        }

        public bool Accept(int orderId)
        {
            try
            {
                var orderAccept = context.Orders.Where(o => o.OrderId == orderId).FirstOrDefault();
                if(orderAccept !=null)
                {
                    orderAccept.ShippedDate = DateTime.Now;
                    context.Attach(orderAccept);
                    context.Entry<Order>(orderAccept).State = EntityState.Modified;
                    return context.SaveChanges() > 0;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }           
        }

        public bool CreateOrder(OrderRequest request)
        {
            try
            {
                var order = new Order()
                {
                    OrderDate = DateTime.Now,
                    UserId = request.UserId,
                    ShippedAddress = context.Users.Where(u => u.Id == request.UserId).FirstOrDefault().Address,
                    TotalAmount = request.TotalAmount
                };
                context.Orders.Add(order);
                context.SaveChanges();
                foreach (var orderDetail in request.CartItems)
                {
                    var odDetail = new OrderDetail()
                    {
                        Quantity = orderDetail.quantity,
                        ProductRefId = orderDetail.product.ProductId,
                        OrderRefId = context.Orders.ToList().Last().OrderId
                    };
                    context.OrderDetails.Add(odDetail);
                    var productUpdateStock = context.Products.Where(p => p.ProductId == orderDetail.product.ProductId).FirstOrDefault();
                    if(productUpdateStock.UnitInStock >= orderDetail.quantity)
                    {
                        productUpdateStock.UnitInStock -= orderDetail.quantity;
                    }
                    else
                    {
                        return false;
                    }
                    context.Attach(productUpdateStock);
                    context.Entry<Product>(productUpdateStock).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public List<OrderViewModel> GetAll()
        {
            var order = context.Orders.ToList();
            return (from o in order
                    select new OrderViewModel()
                    {
                        OrderDate = o.OrderDate,
                        OrderId = o.OrderId,
                        ShippedAddress = o.ShippedAddress,
                        ShippedDate = o.ShippedDate,
                        UserId = o.UserId,
                        TotalAmount = o.TotalAmount
                    }).ToList();
        }

        public List<OrderViewModel> GetByCustomer(string userId)
        {
            var order = context.Orders.Where(u => u.UserId == userId).ToList();
            return (from o in order
                    select new OrderViewModel()
                    {
                        OrderDate = o.OrderDate,
                        OrderId = o.OrderId,
                        ShippedAddress = o.ShippedAddress,
                        ShippedDate = o.ShippedDate,
                        UserId = o.UserId,
                        TotalAmount = o.TotalAmount
                    }).ToList();
        }
    }
}
