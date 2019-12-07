using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Ngành hàng")]
        public int ProductTypeId { get; set; }

        [ForeignKey("ProductTypeId")]
        public virtual ProductTypes ProductTypes { get; set; }

        [Display(Name = "Nhà cung cấp")]
        public int VendorId { get; set; }

        [ForeignKey("VendorId")]
        public virtual Vendors vendor { get; set; }

        [Required]
        [DisplayName("Giá mua vào")]
        public double DefaultBuyingPrice { get; set; }

        [Required]
        [DisplayName("Giá bán ra")]
        public double DefaultSellingPrice { get; set; }

        [DisplayName("Chú thích")]
        public string Description { get; set; }

        [DisplayName("Hình minh họa")]
        public string ProductImageUrl { get; set; }

        [DisplayName("Số lưu kho")]
        public string SKU { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
