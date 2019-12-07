using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLiKhoHang_DoAnWeb.Data;
using QuanLiKhoHang_DoAnWeb.Models;
using QuanLiKhoHang_DoAnWeb.Utility;
using System.Web;

namespace QuanLiKhoHang_DoAnWeb.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class VendorsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public VendorsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.vendors.ToList());
        }

        [Authorize(Roles = SD.AdminEndUser)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Vendors vendor)
        {
            if (ModelState.IsValid)
            {
                _db.Add(vendor);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendor);
        }

        [Authorize(Roles = SD.AdminEndUser)]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
                return NotFound();

            var vendor = await _db.vendors.FindAsync(Id);
            if (vendor == null)
                return NotFound();
            return View(vendor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, Vendors vendor)
        {
            if (Id != vendor.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _db.Update(vendor);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vendor);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = await _db.vendors.FindAsync(id);

            if (vendor == null)
            {
                return NotFound();
            }

            return View(vendor);
        }

        [Authorize(Roles = SD.AdminEndUser)]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
                return NotFound();

            var vendor = await _db.vendors.FindAsync(Id);
            if (vendor == null)
                return NotFound();

            return View(vendor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vendor = await _db.vendors.FindAsync(id);
            int productCount = _db.products.Count(m => m.VendorId == id);

            if (productCount != 0)
            {
                SetAlert("Lỗi, không thể xóa mục này", "error");
            }
            else
            {
                _db.vendors.Remove(vendor);
                await _db.SaveChangesAsync();
                SetAlert("Xóa thành công", "success");
            }

            return RedirectToAction(nameof(Index));
        }

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if(type == "error")
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