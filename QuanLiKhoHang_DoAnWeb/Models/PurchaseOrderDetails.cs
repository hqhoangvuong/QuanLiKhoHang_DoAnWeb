using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models
{
    public class PurchaseOrderDetails
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Lệnh nhập")]
        public int PurchaseOrderId { get; set; }

        [ForeignKey("PurchaseOrderId")]
        public virtual PurchaseOrders PurchaseOrder { get; set; }

        [Display(Name = "Sản phẩm")]
        public int ImportProductId { get; set; }

        [ForeignKey("ImportProductId")]
        public virtual Products product { get; set; }

        [Display(Name = "Chú thích")]
        public string Description { get; set; }

        [Display(Name = "Số lượng nhập")]
        public double Quantity { get; set; }

        [Display(Name = "Giá tiền/SP")]
        public double Price { get; set; }

        [Display(Name = "Tổng cộng")]
        public double Total { get; set; }
    }
}
