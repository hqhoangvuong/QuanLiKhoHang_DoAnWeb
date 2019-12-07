using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public SaleOrders saleOrder { get; set; }
        public List<SaleOrderDetails> saleOrderDetails { get; set; }
        public string Description { get; set; }
        public List<Products> products { get; set; }
        public Clients client { get; set; }
        public int amount { get; set; }
    }
}
