using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysForKids.DbContexts;
using ToysForKids.Models;

namespace ToysForKids.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext context;
        public const string CARTKEY = "cart";

        public CartController(AppDbContext context)
        {
            this.context = context;
        }
        [Route("/Cart/AddToCart/{productid}")]
        public IActionResult AddToCart(int productid)
        {
            var product = context.Products
                            .Where(p => p.ProductId == productid)
                            .FirstOrDefault();
            if (product == null)
                return NotFound("Not found");
            var cart = GetCartItems();
            var caritem = cart.Find(p => p.product.ProductId == productid);
            if (caritem != null)
            {
                if (caritem.quantity < product.UnitInStock)
                    caritem.quantity++;
                else
                    return NotFound("Not found");
            }                
            else
                cart.Add(new CartItem()
                {
                    quantity = 1,
                    product = new ProductModel()
                    {
                        FileAvatarName = product.FileAvatarName,
                        ProductId = product.ProductId,
                        ProductName = product.ProductName,
                        UnitInStock = product.UnitInStock,
                        UnitPrice = product.UnitPrice
                    }
                });
            SaveCartSession(cart);
            return Ok();
        }
        private List<CartItem> GetCartItems()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if(jsoncart != null)
            {
                return JsonConvert.DeserializeObject<List<CartItem>>(jsoncart);
            }
            return new List<CartItem>();
        }
        private void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }
        private void SaveCartSession(List<CartItem> listcart)
        {
            var session = HttpContext.Session;
            string jsoncart = JsonConvert.SerializeObject(listcart);
            session.SetString(CARTKEY, jsoncart);
        }
        [Route("/removecart/{productid}", Name= "removecart")]
        public IActionResult RemoveCart([FromRoute] int productid)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.ProductId == productid);
            if (cartitem != null)
            {
                cart.Remove(cartitem);
            }

            SaveCartSession(cart);
            return Ok();
        }
        [Route("/updatecart/{productid}/{quantity}")]
        [HttpPost]
        public IActionResult UpdateCart(int productid,long quantity)
        {
            var cart = GetCartItems();
            var cartitem = cart.Find(p => p.product.ProductId == productid);
            if (cartitem.product.UnitInStock < quantity)
                return NotFound("Out of stock!");
            if (cartitem != null)
                cartitem.quantity = quantity;
            SaveCartSession(cart);
            return Ok();
        }
        [Route("/cart", Name = "cart")]
        public IActionResult Cart()
        {
            return View(GetCartItems());
        }
        [Route("/Cart/GetCart")]
        public IActionResult GetCart()
        {           
            return Ok(GetCartItems());
        }
        [Authorize]
        [Route("/Cart/Checkout")]
        public IActionResult CheckOut()
        {
            string jsonResult = JsonConvert.SerializeObject(GetCartItems());
            ClearCart();
            return Ok(jsonResult);
        }      
        public IActionResult CartCount()
        {
            var cartCount = GetCartItems().Count.ToString();
            return Json(cartCount);
        }
    }
}
