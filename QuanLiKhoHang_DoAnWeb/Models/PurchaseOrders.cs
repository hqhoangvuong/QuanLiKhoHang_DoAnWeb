using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models
{
    public class PurchaseOrders
    {
        [Key]
        public int PurchaseOrderId { get; set; }

        [Display(Name = "Nhà cung cấp")]
        public int VendorId { get; set; }

        [ForeignKey("VendorId")]
        public virtual Vendors vendor { get; set; }

        [Display(Name = "Ngày sinh lệnh")]
        public DateTimeOffset OrderDate { get; set; }

        [Display(Name = "Tổng cộng")]
        public double Total { get; set; }
    }
}
