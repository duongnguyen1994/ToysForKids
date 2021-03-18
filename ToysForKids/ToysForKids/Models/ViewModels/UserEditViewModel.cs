using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToysForKids.Models.ViewModels
{
    public class UserEditViewModel
    {
        public string UserId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }   
        [Required]
        [Display(Name = "Role")]
        public string RoleId { get; set; }
    }
}
