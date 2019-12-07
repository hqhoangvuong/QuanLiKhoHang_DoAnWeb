using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models.ViewModels
{
    public class ProductsViewModel
    {
        [Display(Name = "Ngành hàng")]
        public IEnumerable<ProductTypes> productType { get; set; }
        [Display(Name = "Nhà cung ứng")]
        public IEnumerable<Vendors> vendor { get; set; }
        public Products product { get; set; }
    }
}
