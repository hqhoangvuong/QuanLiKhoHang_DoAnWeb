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
        public int Id { get; set; }

        [Required]
        [Display(Name = "Hãng")]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Người đại diện")]
        public string ContactPerson { get; set; }

        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; }

    }
}
