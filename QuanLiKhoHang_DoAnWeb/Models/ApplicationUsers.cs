using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models
{
    public class ApplicationUsers : IdentityUser
    {
        [Display(Name = "Tên người dùng")]
        public string Name { get; set; }

        [NotMapped]
        public bool isAdmin { get; set; }
    }
}
