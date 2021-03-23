using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToysForKids.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Display(Name = "Unit Price")]
        public long UnitPrice { get; set; }
        [Display(Name = "Unit In Stock")]
        public long UnitInStock { get; set; }
        public string FileAvatarName { get; set; }
    }
}
