using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models
{
    public class SaleOrders
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Khách hàng")]
        public int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public Clients client { get; set; }

        [Display(Name = "Chú thích")]
        public string Description { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Tổng cộng")]
        public float Total { get; set; }
    }
}
