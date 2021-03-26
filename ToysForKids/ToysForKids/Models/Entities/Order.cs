using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ToysForKids.Models.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int TotalAmount { get; set; }
        [Required]
        public string ShippedAddress { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [ForeignKey("AppIdentityUser")]
        public string UserId { get; set; }
        public AppIdentityUser AppIdentityUser { get; set; }
    }
}
