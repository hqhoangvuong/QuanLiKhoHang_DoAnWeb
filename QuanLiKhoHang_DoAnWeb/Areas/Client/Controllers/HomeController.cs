using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLiKhoHang_DoAnWeb.Data;
using QuanLiKhoHang_DoAnWeb.Extensions;
using QuanLiKhoHang_DoAnWeb.Models;
using QuanLiKhoHang_DoAnWeb.Models.ViewModels;

namespace QuanLiKhoHang_DoAnWeb.Areas.Client
{
    [Area("Client")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        
        public HomeController(ApplicationDbContext db)
        {
            this._db = db;

        }

        //public async Task<IActionResult> Index()
        //{
        //    var productList = await _db.products.Include(m => m.ProductTypes).ToListAsync();

        //    return View(productList);
        //}

        private void getUser()
        {
            string usrId = "";
            if (User.FindFirst(ClaimTypes.NameIdentifier) != null)
                usrId = User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();

            var accList = _db.Users.Where(m => m.Id == usrId).FirstOrDefault();
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var productList = from m in _db.products.Include(m => m.ProductTypes) select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                productList = productList.Where(s => s.Name.Contains(searchString));
                SetAlert("Có " + productList.Count() + " kết quả tìm kiếm cho từ khóa '" + searchString +"'", "success");
            }
            getUser();
            return View(await productList.ToListAsync());
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _db.products.Include(m => m.ProductTypes).Where(m => m.Id == id).FirstOrDefaultAsync();
            return View(product);
        }

        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailsPOST(int id, int amount)
        {
            List<BuyProductViewModel> lstShoppingCart = HttpContext.Session.Get<List<BuyProductViewModel>>("ssShoppingCart");
            if(lstShoppingCart == null)
            {
                lstShoppingCart = new List<BuyProductViewModel>();
            }

            BuyProductViewModel buy = new BuyProductViewModel()
            {
                productId = id,
                amount = amount
            };

            lstShoppingCart.Add(buy);
            HttpContext.Session.Set("ssShoppingCart", lstShoppingCart);
            return RedirectToAction("Index", "Home", new { area = "Client" });  
        }

        public async Task<IActionResult> Edit(int id, int amount)
        {
            List<BuyProductViewModel> lstShoppingCart = HttpContext.Session.Get<List<BuyProductViewModel>>("ssShoppingCart");
            
            if(lstShoppingCart != null && lstShoppingCart.Any(m => m.productId == id))
            {
                var selected = lstShoppingCart.Where(m => m.productId == id).SingleOrDefault();
                selected.amount = amount;
                SetAlert("Đã thay đổi thành công sản phẩm trong giỏ hàng!", "success");
            }
            else
                SetAlert("Xảy ra lỗi! Không thể thay đổi thông tin sản phẩm trong giỏ hàng!", "error");
            HttpContext.Session.Set("ssShoppingCart", lstShoppingCart);
            return RedirectToAction("Index", "Home", new { area = "Client" });
        }

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;

            if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }

            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
        }
    }
}