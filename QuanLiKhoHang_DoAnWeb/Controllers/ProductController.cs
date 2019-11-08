using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuanLiKhoHang_DoAnWeb.Data;
using QuanLiKhoHang_DoAnWeb.Models;

namespace QuanLiKhoHang_DoAnWeb.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext db;
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ProductDetailsById(int? id)
        {
            if (id == null)
            {
                return Content("Bad Request: Nothing to find");
            }

            Products product = db.products.Find(id);

            if (product == null)
            {
                return Content("Bad request: Product not found");
            }
            return View(product);
        }
    }
}