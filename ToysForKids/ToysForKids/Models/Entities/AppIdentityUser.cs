using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToysForKids.Models.Entities
{
    public class AppIdentityUser : IdentityUser
    {
        [Required]
        [MaxLength(50)]
        public string Fullname { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
