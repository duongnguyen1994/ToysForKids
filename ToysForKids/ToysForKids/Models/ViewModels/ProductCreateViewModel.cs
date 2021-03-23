using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToysForKids.Models.ViewModels
{
    public class ProductCreateViewModel
    {
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
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Choose file upload")]
        public IFormFile FileUpload { get; set; }
    }
}
