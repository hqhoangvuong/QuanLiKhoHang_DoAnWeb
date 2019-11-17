using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models.ViewModels
{
    public class SaleOrdersViewModel
    {
        public SaleOrders saleOrder { get; set; }
        public IEnumerable<Clients> client { get; set; }
        public IEnumerable<SaleOrderDetails> saleOrderDetails { get; set; }
        public IEnumerable<Products> product { get; set; }

    }
}
