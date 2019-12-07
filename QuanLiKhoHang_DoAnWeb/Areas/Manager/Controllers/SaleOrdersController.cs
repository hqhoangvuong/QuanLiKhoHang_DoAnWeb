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

        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
                return NotFound();

            var saleOrder = await _db.saleOrders.FindAsync(Id);
            if (saleOrder == null)
                return NotFound();

            return View(saleOrder);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleOrder = await _db.saleOrders.FindAsync(id);
            int saleOrderDetailCount = _db.saleOrderDetails.Count(m => m.SaleOrderId == id);

            if (saleOrderDetailCount != 0)
            {
                SetAlert("Lỗi, không thể xóa mục này. Vui lòng kiểm chắc chắn lệnh này trống và thử lại", "error");
            }
            else
            {
                _db.saleOrders.Remove(saleOrder);
                await _db.SaveChangesAsync();
                SetAlert("Xóa thành công", "success");
            }
            return RedirectToAction(nameof(Index));
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

        public IActionResult OrderConfirmation(int? id)
        {
            if (id == null)
            {
                SetAlert("Đã xảy ra lỗi khi xác nhận đơn hàng", "error");
                return RedirectToAction(nameof(Index));
            }
            else
            {
                var SaleOrder = _db.saleOrders.Where(m => m.Id == id).FirstOrDefault();
                SaleOrder.isConfirmed = true;
                _db.SaveChanges();
                SetAlert("Xác nhận thành công đơn hàng id = " + id, "success");
            }

            return RedirectToAction(nameof(Index));
        }
    }
}