using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models
{
    public class SaleOrders
    {
        [Key]
        public int SaleOrderId { get; set; }
        public string PurchaseOrderName { get; set; }

        public int CustomerId { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        public float Total { get; set; }

        public List<SaleOrderDetails> SaleOrderDetail { get; set; } = new List<SaleOrderDetails>();
    }
}
