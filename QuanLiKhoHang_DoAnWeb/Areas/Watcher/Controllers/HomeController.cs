using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuanLiKhoHang_DoAnWeb.Areas.Watcher
{
    public class HomeController : Controller
    {
        [Area("Watcher")]
        public IActionResult Index()
        {
            return View();
        }
    }
}