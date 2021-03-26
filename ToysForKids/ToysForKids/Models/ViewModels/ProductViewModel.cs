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
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        [Required]
        [Display(Name = "Unit Price")]
        public long UnitPrice { get; set; }
        [Required]
        [Display(Name = "Quantity Per Unit")]
        public long QuantityPerUnit { get; set; }
        [Display(Name = "Unit In Stock")]
        public long UnitInStock { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [MaxLength(50)]
        public string FileAvatarName { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}
