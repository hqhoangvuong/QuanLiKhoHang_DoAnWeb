using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models.ViewModels
{
    public class PurchaseOrdersViewModel
    {
        public PurchaseOrders purchaseOrder { get; set; }
        public IEnumerable<Vendors> vendor { get; set; }
        public IEnumerable<PurchaseOrderDetails> purchaseOrderDetail { get; set; }
        public IEnumerable<Products> product { get; set; }
    }
}
