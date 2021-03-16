using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToysForKids.Models.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ProductName { get; set; }
        [Required]
        public long UnitPrice { get; set; }
        [Required]
        public long QuantityPerUnit { get; set; }
        [Required]
        public long UnitInStock { get; set; }
        [Required]
        public long UnitOnOrder { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [MaxLength(50)]
        public string FileAvatarName { get; set; }
    }
}
