using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ToysForKids.Models.Entities;

namespace ToysForKids.Models.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryId { get; set; }
        [Required]
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
