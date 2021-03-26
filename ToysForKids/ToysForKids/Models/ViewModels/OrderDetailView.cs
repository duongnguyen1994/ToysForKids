using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToysForKids.Models.ViewModels
{
    public class OrderDetailView
    {
        [Display(Name ="Product Name")]
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public long Quantity { get; set; }
    }
}
