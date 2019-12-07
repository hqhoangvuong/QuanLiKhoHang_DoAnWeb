using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using QuanLiKhoHang_DoAnWeb.Data;
using QuanLiKhoHang_DoAnWeb.Models.ViewModels;
using QuanLiKhoHang_DoAnWeb.Utility;
using System.IO;

namespace QuanLiKhoHang_DoAnWeb.Areas.Manager
{
    [Authorize(Roles = SD.AdminEndUser)]
    [Area("Manager")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ProductsViewModel ProductsVM { get; set; }
        private readonly IHostingEnvironment _hostingEnvironment;

        public ProductsController(ApplicationDbContext db, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            ProductsVM = new ProductsViewModel()
            {
                productType = _db.productTypes.ToList(),
                vendor = _db.vendors.ToList(),
                product = new Models.Products()
            };
        }

        //public ProductsController(ApplicationDbContext db)
        //{
        //    _db = db;
        //    ProductsVM = new ProductsViewModel()
        //    {
        //        productType = _db.productTypes.ToList(),
        //        vendor = _db.vendors.ToList(),
        //        product = new Models.Products()
        //    };

        //}

        public async Task<IActionResult> Index()
        {
            var products = _db.products.Include(m => m.ProductTypes).Include(m => m.vendor);
            return View(await products.ToListAsync());
        }

        public IActionResult Create()
        {
            return View(ProductsVM);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePOST()
        {
            if (!ModelState.IsValid)
            {
                return View(ProductsVM);
            }

            _db.products.Add(ProductsVM.product);
            await _db.SaveChangesAsync();

            //Image being saved

            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            var productsFromDb = _db.products.Find(ProductsVM.product.Id);

            if (files.Count != 0)
            {
                //Image has been uploaded
                var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                var extension = Path.GetExtension(files[0].FileName);

                using (var filestream = new FileStream(Path.Combine(uploads, ProductsVM.product.Id + extension), FileMode.Create))
                {
                    files[0].CopyTo(filestream);
               }
                productsFromDb.ProductImageUrl = @"\" + SD.ImageFolder + @"\" + ProductsVM.product.Id + extension;
            }
            else
            {
                //when user does not upload image
                var uploads = Path.Combine(webRootPath, SD.ImageFolder + @"\" + SD.DefaultProductImage);
                System.IO.File.Copy(uploads, webRootPath + @"\" + SD.ImageFolder + @"\" + ProductsVM.product.Id + ".png");
                productsFromDb.ProductImageUrl = @"\" + SD.ImageFolder + @"\" + ProductsVM.product.Id + ".png";
            }
            await _db.SaveChangesAsync();
            SetAlert("Thêm danh mục thành công", "success");
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductsVM.product = await _db.products.Include(m => m.vendor).Include(m => m.ProductTypes).SingleOrDefaultAsync(m => m.Id == id);

            if (ProductsVM.product == null)
            {
                return NotFound();
            }

            return View(ProductsVM);
        }

        //Post : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            if (ModelState.IsValid)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;

                var productFromDb = _db.products.Where(m => m.Id == ProductsVM.product.Id).FirstOrDefault();

                if (files.Count > 0 && files[0] != null)
                {
                    //if user uploads a new image
                    var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                    var extension_new = Path.GetExtension(files[0].FileName);
                    var extension_old = Path.GetExtension(productFromDb.ProductImageUrl);

                    if (System.IO.File.Exists(Path.Combine(uploads, ProductsVM.product.Id + extension_old)))
                    {
                        System.IO.File.Delete(Path.Combine(uploads, ProductsVM.product.Id + extension_old));
                    }
                    using (var filestream = new FileStream(Path.Combine(uploads, ProductsVM.product.Id + extension_new), FileMode.Create))
                    {
                        files[0].CopyTo(filestream);
                    }
                    ProductsVM.product.ProductImageUrl = @"\" + SD.ImageFolder + @"\" + ProductsVM.product.Id + extension_new;
                }

                if (ProductsVM.product.ProductImageUrl != null)
                {
                    productFromDb.ProductImageUrl = ProductsVM.product.ProductImageUrl;
                }

                productFromDb.Name = ProductsVM.product.Name;
                productFromDb.DefaultBuyingPrice = ProductsVM.product.DefaultBuyingPrice;
                productFromDb.DefaultSellingPrice = ProductsVM.product.DefaultSellingPrice;
                productFromDb.ProductTypeId = ProductsVM.product.ProductTypeId;
                productFromDb.VendorId = ProductsVM.product.VendorId;
                productFromDb.Description = ProductsVM.product.Description;
                productFromDb.SKU = ProductsVM.product.SKU;
                productFromDb.Stock = ProductsVM.product.Stock;
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(ProductsVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProductsVM.product = await _db.products.Include(m => m.ProductTypes).SingleOrDefaultAsync(m => m.Id == id);

            if (ProductsVM.product == null)
            {
                return NotFound();
            }

            return View(ProductsVM);
        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
                return NotFound();

            var productType = await _db.products.FindAsync(Id);
            if (productType == null)
                return NotFound();

            return View(productType);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _db.products.FindAsync(id);
            int relate = _db.saleOrderDetails.Count(m => m.ExportProductId == id) + _db.purchaseOrderDetails.Count(m => m.ImportProductId == id);
            if (relate != 0)
            {
                SetAlert("Lỗi, không thể xóa mục này", "error");
            }
            else
            {
                _db.products.Remove(product);
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
    }
}