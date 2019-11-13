using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models
{
    public class ProductTypes
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [System.ComponentModel.DisplayName("Ngành hàng")]
        public string Name { get; set; }

        [System.ComponentModel.DisplayName("Mô tả")]
        public string Description { get; set; }
    }
}
