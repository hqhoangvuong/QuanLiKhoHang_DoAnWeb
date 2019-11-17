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
    public class PurchaseOrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public PurchaseOrdersViewModel PurchaseOrdersVM { get; set; }

        public PurchaseOrderController(ApplicationDbContext db)
        {
            _db = db;
            PurchaseOrdersVM = new PurchaseOrdersViewModel()
            {
                vendor = _db.vendors.ToList(),
                purchaseOrder = new Models.PurchaseOrders()
            };
        }

        public async Task<IActionResult> Index()
        {
            var saleorder = _db.purchaseOrders.Include(m => m.vendor);
            return View(await saleorder.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(PurchaseOrdersVM);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            if (!ModelState.IsValid)
            {
                return View(PurchaseOrdersVM);
            }

            _db.purchaseOrders.Add(PurchaseOrdersVM.purchaseOrder);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PurchaseOrdersVM.product = _db.products.ToList();
            PurchaseOrdersVM.purchaseOrder = await _db.purchaseOrders.Include(m => m.vendor).SingleOrDefaultAsync(m => m.Id == id);

            PurchaseOrdersVM.purchaseOrderDetail = from p in _db.saleOrders
                                           join q in _db.purchaseOrderDetails on p.Id equals q.PurchaseOrderId
                                           where p.Id == PurchaseOrdersVM.purchaseOrder.Id
                                           select new PurchaseOrderDetails()
                                           {
                                               PurchaseOrderId = p.Id,
                                               ImportProductId = q.ImportProductId,
                                               Description = q.Description,
                                               Quantity = q.Quantity,
                                               Total = q.Total
                                           };


            if (PurchaseOrdersVM.purchaseOrder == null)
            {
                return NotFound();
            }

            return View(PurchaseOrdersVM);
        }

        [HttpGet]
        public ActionResult CreateDetails(string id)
        {
            return RedirectToAction("Create", "SaleOrderDetails", new { id = id });
        }
    }
}