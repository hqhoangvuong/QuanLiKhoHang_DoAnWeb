using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLiKhoHang_DoAnWeb.Data;
using QuanLiKhoHang_DoAnWeb.Models.ViewModels;

namespace QuanLiKhoHang_DoAnWeb.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class SaleOrderDetailsController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public SaleOrderDetailsViewModel SaleOrderDetailsVM { get; set; }

        public SaleOrderDetailsController(ApplicationDbContext db)
        {
            _db = db;
            SaleOrderDetailsVM = new SaleOrderDetailsViewModel()
            {

                saleOrderDetail = new Models.SaleOrderDetails(),
                product = _db.products.ToList()
            };
        }

        public IActionResult Create(int id)
        {
            SaleOrderDetailsVM.saleOrderDetail.SaleOrderId = id;
            return View(SaleOrderDetailsVM);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST(int Id)
        {
            if (!ModelState.IsValid)
            {
                return View(SaleOrderDetailsVM);
            }

            var result = _db.products.SingleOrDefault(b => b.Id == SaleOrderDetailsVM.saleOrderDetail.ExportProductId);
            var saleOrder = _db.saleOrders.SingleOrDefault(b => b.Id == SaleOrderDetailsVM.saleOrderDetail.SaleOrderId);

            if (result != null)
            {
                result.Stock -= SaleOrderDetailsVM.saleOrderDetail.Quantity;
                saleOrder.Total += (float)SaleOrderDetailsVM.saleOrderDetail.Total;
                await _db.SaveChangesAsync();
            }

            _db.saleOrderDetails.Add(SaleOrderDetailsVM.saleOrderDetail);
            await _db.SaveChangesAsync();
            return RedirectToAction("Details", "SaleOrders", new { id = Id });
        }
    }
}