using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLiKhoHang_DoAnWeb.Data;
using QuanLiKhoHang_DoAnWeb.Models;
using QuanLiKhoHang_DoAnWeb.Models.ViewModels;

namespace QuanLiKhoHang_DoAnWeb.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class PurchaseOrderDetailsController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public PurchaseOrderDetailsViewModel PurchaseOrderDetaislVM { get; set; }

        public IActionResult Index(int Id)
        {
            return RedirectToAction("Details", "PurchaseOrder", new { id = Id });
        }

        public PurchaseOrderDetailsController(ApplicationDbContext db)
        {
            _db = db;
            PurchaseOrderDetaislVM = new PurchaseOrderDetailsViewModel()
            {

                PurchaseOrderDetail = new Models.PurchaseOrderDetails(),
                isNewProduct = false,
                vendor = new Vendors()
            };
        }

        public IActionResult Create(int id, int vendorId)
        {
            PurchaseOrderDetaislVM.products = _db.products.Where(m => m.VendorId == vendorId).ToList();
            PurchaseOrderDetaislVM.productTypes = _db.productTypes.ToList();
            return View(PurchaseOrderDetaislVM);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST(int Id)
        {
            if (!ModelState.IsValid)
            {
                return View(PurchaseOrderDetaislVM);
            }

            PurchaseOrderDetaislVM.PurchaseOrderDetail.ImportProductId = PurchaseOrderDetaislVM.productID;
            PurchaseOrderDetaislVM.PurchaseOrderDetail.PurchaseOrderId = Id;
            if (!PurchaseOrderDetaislVM.isNewProduct)
            {
                var purchasedProduct = await _db.products.SingleOrDefaultAsync(m => m.Id == PurchaseOrderDetaislVM.productID);
                var purchaseOrder = await _db.purchaseOrders.SingleOrDefaultAsync(m => m.Id == Id);
                PurchaseOrderDetaislVM.PurchaseOrderDetail.Price = purchasedProduct.DefaultBuyingPrice;
                PurchaseOrderDetaislVM.PurchaseOrderDetail.Total = PurchaseOrderDetaislVM.PurchaseOrderDetail.Price * PurchaseOrderDetaislVM.PurchaseOrderDetail.Quantity;
                purchasedProduct.Stock += (int)PurchaseOrderDetaislVM.PurchaseOrderDetail.Quantity;
                purchaseOrder.Total += PurchaseOrderDetaislVM.PurchaseOrderDetail.Total;
                _db.purchaseOrderDetails.Add(PurchaseOrderDetaislVM.PurchaseOrderDetail);
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Details", "PurchaseOrder", new { id = Id });
        }
    }
}