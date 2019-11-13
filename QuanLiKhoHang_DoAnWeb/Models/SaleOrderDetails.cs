using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models
{
    public class SaleOrderDetails
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Lệnh bán")]
        public int SaleOrderId { get; set; }

        [ForeignKey("SaleOrderId")]
        public virtual SaleOrders SaleOrder { get; set; }

        [Display(Name = "Sản phẩm")]
        public int ExportProductId { get; set; }
        
        [ForeignKey("ExportProductId")]
        public virtual Products product { get; set; }

        [Display(Name = "Chú thích")]
        public string Description { get; set; }

        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }
        
        [Display(Name = "Đơn giá")]
        public double Total { get; set; }
    }
}