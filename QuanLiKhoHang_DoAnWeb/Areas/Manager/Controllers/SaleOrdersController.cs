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
    public class SaleOrdersController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public SaleOrdersViewModel SaleOrderVM { get; set; }

        public SaleOrdersController(ApplicationDbContext db)
        {
            _db = db;
            SaleOrderVM = new SaleOrdersViewModel()
            {
                client = _db.clients.ToList(),
                saleOrder = new Models.SaleOrders()
            };
        }

        public async Task<IActionResult> Index()
        {
            var saleorder = _db.saleOrders.Include(m => m.client);
            return View(await saleorder.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(SaleOrderVM);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            if (!ModelState.IsValid)
            {
                return View(SaleOrderVM);
            }

            _db.saleOrders.Add(SaleOrderVM.saleOrder);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SaleOrderVM.product = _db.products.ToList();
            SaleOrderVM.saleOrder = await _db.saleOrders.Include(m => m.client).SingleOrDefaultAsync(m => m.Id == id);

            SaleOrderVM.saleOrderDetails = from p in _db.saleOrders
                                           join q in _db.saleOrderDetails on p.Id equals q.SaleOrderId
                                           where p.Id == SaleOrderVM.saleOrder.Id
                                           select new SaleOrderDetails()
                                           {
                                               SaleOrderId = p.Id,
                                               ExportProductId = q.ExportProductId,
                                               Description = q.Description,
                                               Quantity = q.Quantity,
                                               Total = q.Total
                                           };
                                                                    

            if (SaleOrderVM.saleOrder == null)
            {
                return NotFound();
            }

            return View(SaleOrderVM);
        }

        [HttpGet]
        public ActionResult CreateDetails(string id)
        {
            return RedirectToAction("Create", "SaleOrderDetails", new { id = id});
        }
    }
}