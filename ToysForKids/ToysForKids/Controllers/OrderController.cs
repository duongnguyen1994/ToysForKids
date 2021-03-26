using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysForKids.Models;
using ToysForKids.Models.Entities;
using ToysForKids.Models.ViewModels;
using ToysForKids.Services;

namespace ToysForKids.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService orderService;
        private readonly IOrderDetailService orderDetailService;
        private readonly UserManager<AppIdentityUser> userManager;

        public OrderController(IOrderService orderService, IOrderDetailService orderDetailService, UserManager<AppIdentityUser> userManager)
        {
            this.orderService = orderService;
            this.orderDetailService = orderDetailService;
            this.userManager = userManager;
        }
        [HttpPost]
        [Route("/Order/CreateOrder/{userId}/{jsonRequest}/{total}")]
        public IActionResult CreateOrder(string userId,string jsonRequest,int total)
        {
            var cartitems = JsonConvert.DeserializeObject<List<CartItem>>(jsonRequest);
            var request = new OrderRequest()
            {
                CartItems = cartitems,
                UserId = userId,
                TotalAmount = total
            };
            if(orderService.CreateOrder(request))
                return Ok(request);
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult GetAllOrder()
        {
            return View(orderService.GetAll());
        }
        [Authorize]
        public IActionResult GetOrdersForCustomer(string userId)
        {
            return View(orderService.GetByCustomer(userId));
        }
        [Authorize(Roles = "Admin")]
        [Route("/Order/OrderDetail/{orderId}")]
        public IActionResult OrderDetail(int orderId)
        {
            return View(orderDetailService.Get(orderId));
        }
        [Authorize]
        [Route("/Order/OrderDetail/{orderId}/{userId}")]
        public async Task<IActionResult> OrderDetail(int orderId, string userId)
        {
            var user = await userManager.GetUserAsync(User);
            if (user.Id == userId)
                return View(orderDetailService.Get(orderId));
            return RedirectToAction("GetOrdersForCustomer", "Order", new { userId = userId });
        }
        [Authorize(Roles = "Admin")]
        public IActionResult AcceptOrder(int orderId)
        {
            if(orderService.Accept(orderId))
            {
                return RedirectToAction("GetAllOrder", "Order");
            }
            return RedirectToAction("GetAllOrder", "Order");
        }
    }
}
