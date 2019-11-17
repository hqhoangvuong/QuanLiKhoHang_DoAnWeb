using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using QuanLiKhoHang_DoAnWeb.Data;
using QuanLiKhoHang_DoAnWeb.Models.ViewModels;
using QuanLiKhoHang_DoAnWeb.Utility;

namespace QuanLiKhoHang_DoAnWeb.Areas.Manager
{
    [Authorize(Roles = SD.AdminEndUser)]
    [Area("Manager")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ProductsViewModel ProductsVM { get; set; }

        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
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

            //string webRootPath = _hostingEnvironment.WebRootPath;
            //var files = HttpContext.Request.Form.Files;

            //var productsFromDb = _db.products.Find(ProductsVM.product.Id);

            //if (files.Count != 0)
            //{
            //    //Image has been uploaded
            //    var uploads = Path.Combine(webRootPath, SD.ImageFolder);
            //    var extension = Path.GetExtension(files[0].FileName);

            //    using (var filestream = new FileStream(Path.Combine(uploads, ProductsVM.Products.Id + extension), FileMode.Create))
            //    {
            //        files[0].CopyTo(filestream);
            //    }
            //    productsFromDb.Image = @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + extension;
            //}
            //else
            //{
            //    //when user does not upload image
            //    var uploads = Path.Combine(webRootPath, SD.ImageFolder + @"\" + SD.DefaultProductImage);
            //    System.IO.File.Copy(uploads, webRootPath + @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + ".png");
            //    productsFromDb.Image = @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + ".png";
            //}
            await _db.SaveChangesAsync();

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
                //string webRootPath = _hostingEnvironment.WebRootPath;
                //var files = HttpContext.Request.Form.Files;

                var productFromDb = _db.products.Where(m => m.Id == ProductsVM.product.Id).FirstOrDefault();

                //if (files.Count > 0 && files[0] != null)
                //{
                //    //if user uploads a new image
                //    var uploads = Path.Combine(webRootPath, SD.ImageFolder);
                //    var extension_new = Path.GetExtension(files[0].FileName);
                //    var extension_old = Path.GetExtension(productFromDb.Image);

                //    if (System.IO.File.Exists(Path.Combine(uploads, ProductsVM.Products.Id + extension_old)))
                //    {
                //        System.IO.File.Delete(Path.Combine(uploads, ProductsVM.Products.Id + extension_old));
                //    }
                //    using (var filestream = new FileStream(Path.Combine(uploads, ProductsVM.Products.Id + extension_new), FileMode.Create))
                //    {
                //        files[0].CopyTo(filestream);
                //    }
                //    ProductsVM.Products.Image = @"\" + SD.ImageFolder + @"\" + ProductsVM.Products.Id + extension_new;
                //}

                //if (ProductsVM.Products.Image != null)
                //{
                //    productFromDb.Image = ProductsVM.Products.Image;
                //}

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
    }
}