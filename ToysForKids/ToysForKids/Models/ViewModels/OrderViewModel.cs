using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToysForKids.Models.Entities;

namespace ToysForKids.Models.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        [Display(Name ="Order Date")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Shipped Date")]
        public DateTime? ShippedDate { get; set; }
        [Display(Name = "Shipped Address")]
        public string ShippedAddress { get; set; }
        [Display(Name ="User Name")]
        public string UserId { get; set; }
        [Display(Name ="Total Amount")]
        public int TotalAmount { get; set; }
    }
}
