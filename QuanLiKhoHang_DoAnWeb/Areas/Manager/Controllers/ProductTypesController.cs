using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLiKhoHang_DoAnWeb.Data;
using Microsoft.AspNetCore.Mvc;
using QuanLiKhoHang_DoAnWeb.Models;
using Microsoft.AspNetCore.Authorization;
using QuanLiKhoHang_DoAnWeb.Utility;

namespace QuanLiKhoHang_DoAnWeb.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class ProductTypesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.productTypes.ToList());
        }

        public IActionResult CreateProductType()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProductType(ProductTypes productType)
        {
            if (ModelState.IsValid)
            {
                _db.Add(productType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productType);
        }

        [Authorize(Roles = SD.AdminEndUser)]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
                return NotFound();

            var productType = await _db.productTypes.FindAsync(Id);
            if (productType == null)
                return NotFound();

            return View(productType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, ProductTypes productType)
        {
            if (Id != productType.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _db.Update(productType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productType);
        }

        [Authorize(Roles = SD.AdminEndUser)]
        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
                return NotFound();

            var productType = await _db.productTypes.FindAsync(Id);
            if (productType == null)
                return NotFound();

            return View(productType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productType = await _db.productTypes.FindAsync(id);
            _db.productTypes.Remove(productType);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}