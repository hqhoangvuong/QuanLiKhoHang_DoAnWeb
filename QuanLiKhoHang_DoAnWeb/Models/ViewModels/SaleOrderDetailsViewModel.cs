using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models.ViewModels
{
    public class SaleOrderDetailsViewModel
    {
        public SaleOrderDetails saleOrderDetail { get; set; }
        public IEnumerable<Products> product { get; set; }
    }
}