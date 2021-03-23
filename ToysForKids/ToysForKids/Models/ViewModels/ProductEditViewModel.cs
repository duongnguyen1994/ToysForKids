using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToysForKids.Models.ViewModels
{
    public class ProductEditViewModel : ProductViewModel
    {
        [DataType(DataType.Upload)]
        [Display(Name = "Choose file upload")]
        public IFormFile FileUpload { get; set; }
    }
}
