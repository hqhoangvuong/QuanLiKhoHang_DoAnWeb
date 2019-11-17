using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLiKhoHang_DoAnWeb.Data;
using QuanLiKhoHang_DoAnWeb.Models;
using QuanLiKhoHang_DoAnWeb.Utility;

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
            _db.vendors.Remove(vendor);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}