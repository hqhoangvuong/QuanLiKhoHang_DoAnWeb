using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models
{
    public class Vendors
    {
        [Key]
        public int VendorId { get; set; }

        [Required]
        public string VendorName { get; set; }

        public string Address { get; set; }

        public string ContactPerson { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public List<PurchaseOrders> purchaseorders { get; set; } = new List<PurchaseOrders>();
    }
}
