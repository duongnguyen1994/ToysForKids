using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToysForKids.Models.ViewModels
{
    public class OrderRequest
    {
        public string UserId { get; set; }
        public int TotalAmount { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
