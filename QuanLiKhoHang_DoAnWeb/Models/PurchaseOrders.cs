using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models
{
    public class PurchaseOrders
    {
        [Key]
        public int PurchaseOrderId { get; set; }

        [Display(Name = "Order Number")]
        public string PurchaseOrderName { get; set; }

        [Display(Name = "Branch")]
        public int VendorId { get; set; }

        public DateTimeOffset OrderDate { get; set; }

        public double Total { get; set; }

        public List<PurchaseOrderDetails> purchaseOrderDetail { get; set; } = new List<PurchaseOrderDetails>();
    }
}
