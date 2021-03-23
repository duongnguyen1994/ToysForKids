using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToysForKids.Models
{
    public class CartItem
    {
        public long quantity { get; set; }
        public ProductModel product { get; set; }
    }
}
