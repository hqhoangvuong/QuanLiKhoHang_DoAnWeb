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
        public int ProductTypeId { get; set; }

        [Required]
        public string ProductTypeName { get; set; }

        public string Description { get; set; }

        public List<Products> products { get; set; } = new List<Products>();
    }
}
