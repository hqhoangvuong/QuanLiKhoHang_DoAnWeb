using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }

        public int ProductTypeId { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public float DefaultBuyingPrice { get; set; }

        [Required]
        public float DefaultSellingPrice { get; set; }

        public string Description { get; set; }

        public string ProductImageUrl { get; set; }

        public string SKU { get; set; }

        [Required]
        public int Stock { get; set; }

        public bool Deleted { get; set; }
    }
}
