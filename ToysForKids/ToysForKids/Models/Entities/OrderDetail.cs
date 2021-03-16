using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToysForKids.Models.Entities
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        [ForeignKey("Product")]
        public int ProductRefId { get; set; }
        [ForeignKey("Order")]
        public int OrderRefId { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        [Required]
        public long Quantity { get; set; }
    }
}
