using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models.ViewModels
{
    public class ProductsViewModel
    {
        public IEnumerable<ProductTypes> productType { get; set; }
        public IEnumerable<Vendors> vendor { get; set; }
        public Products product { get; set; }
    }
}
