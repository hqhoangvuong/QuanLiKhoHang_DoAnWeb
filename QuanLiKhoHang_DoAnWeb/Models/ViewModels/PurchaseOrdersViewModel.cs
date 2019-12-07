using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models.ViewModels
{
    public class PurchaseOrdersViewModel
    {
        public PurchaseOrders purchaseOrder { get; set; }

        [Display(Name = "Nhà cung cấp")]
        public IEnumerable<Vendors> vendor { get; set; }

        public IEnumerable<PurchaseOrderDetails> purchaseOrderDetail { get; set; }

        public IEnumerable<Products> product { get; set; }
    }
}
