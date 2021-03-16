using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToysForKids.Models.ViewModels
{
    public class ProductCreateViewModel : ProductViewModel
    {
        [DataType(DataType.Upload)]
        [FileExtensions(Extensions = "png,jpg,jpeg,gif")]
        [Display(Name = "Select")]
        public IFormFile[] FileUploads { get; set; }
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
