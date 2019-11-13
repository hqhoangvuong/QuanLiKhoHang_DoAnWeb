using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLiKhoHang_DoAnWeb.Models
{
    public class Clients
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayName("Tên khách hàng")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Giới tính")]
        public bool Sex { get; set; }

        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        public string Email { get; set; }

        [DisplayName("Điện thoại")]
        public string Phone { get; set; }
    }
}
