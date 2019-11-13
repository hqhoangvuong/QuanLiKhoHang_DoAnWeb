﻿using System;
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
        public string Name { get; set; }

        public string Address { get; set; }

        public string ContactPerson { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

    }
}
