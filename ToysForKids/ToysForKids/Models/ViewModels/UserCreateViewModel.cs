using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToysForKids.Models.ViewModels
{
    public class UserCreateViewModel
    {
        [Required]
        [MaxLength(25)]
        public string Firstname { get; set; }
        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        [MaxLength(15)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [Display(Name = "Role")]
        public string RoleId { get; set; }
    }
}
