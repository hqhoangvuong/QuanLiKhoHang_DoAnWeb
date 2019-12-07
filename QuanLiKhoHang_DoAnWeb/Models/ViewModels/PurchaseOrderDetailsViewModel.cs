using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models.ViewModels
{
    public class PurchaseOrderDetailsViewModel
    {
        public bool isNewProduct { get; set; }
        public int productID { get; set; }
        
        public PurchaseOrders purchaseOrder { get; set; }

        public PurchaseOrderDetails PurchaseOrderDetail { get; set; }

        [Display(Name = "Mặt hàng")]
        public IEnumerable<Products> products { get; set; }

        [Display(Name = "Ngành hàng")]
        public IEnumerable<ProductTypes> productTypes { get; set; }
        
        [Display(Name = "Nhà cung cấp")]
        public Vendors vendor { get; set; }
    }
}
