using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models
{
    public class SaleOrderDetails
    {
        [Display(Name = "Sale Order")]
        public int SaleOrderId { get; set; }

        [Display(Name = "Sale Order")]
        public SaleOrders SaleOrder { get; set; }

        [Key]
        public int ProductIssueId { get; set; }

        public int ProductId;

        public string Description { get; set; }

        public int Quantity { get; set; }
        
        public double SubTotal { get; set; }
        
        public double Total { get; set; }
    }
}
