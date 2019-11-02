using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models
{
    public class PurchaseOrderDetails
    {
        [Key]
        public int ProductReceiptId { get; set; }

        [Display(Name = "Purchase Order")]
        public int PurchaseOrderId { get; set; }

        [Display(Name = "Purchase Order")]
        public PurchaseOrders PurchaseOrder { get; set; }

        [Display(Name = "Product Item")]
        public int ProductId { get; set; }

        public string Description { get; set; }

        public double Quantity { get; set; }

        public double Price { get; set; }

        public double Total { get; set; }
    }
}
