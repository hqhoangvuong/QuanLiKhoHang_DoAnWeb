using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuanLiKhoHang_DoAnWeb.Data;
using QuanLiKhoHang_DoAnWeb.Extensions;
using QuanLiKhoHang_DoAnWeb.Models;
using QuanLiKhoHang_DoAnWeb.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace QuanLiKhoHang_DoAnWeb.Areas.Client.Controllers
{
    [Area("Client")]
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public ShoppingCartViewModel ShoppingCartVM { get; set; }

        public ShoppingCartController(ApplicationDbContext db)
        {
            _db = db;
            ShoppingCartVM = new ShoppingCartViewModel()
            {
                products = new List<Models.Products>(),
                client = new Models.Clients()
            };
        }

        public async Task<IActionResult> Index()
        {
            List<BuyProductViewModel> lstShoppingCart = HttpContext.Session.Get<List<BuyProductViewModel>>("ssShoppingCart");
            if(lstShoppingCart.Count > 0)
            {
                foreach (BuyProductViewModel cartItem in lstShoppingCart)
                {
                    Products product = _db.products.Include(p => p.ProductTypes).Where(p => p.Id == cartItem.productId).FirstOrDefault();
                    product.Stock = cartItem.amount;
                    ShoppingCartVM.products.Add(product);
                    ShoppingCartVM.amount = cartItem.amount;
                }
            }
            return View(ShoppingCartVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Index")]
        public IActionResult IndexPost()
        {
            List<BuyProductViewModel> lstCartItems = HttpContext.Session.Get<List<BuyProductViewModel>>("ssShoppingCart");
            double Total = 0.0;

            Clients client = ShoppingCartVM.client;
            SaleOrders saleOrder = new SaleOrders()
            {
                Description = ShoppingCartVM.Description,
                OrderDate = DateTime.Now
            };

            // Xử lí thông tin người mua & tạo đơn hàng
            if (_db.clients.Where(m => m.Name == client.Name).Count() == 0)
            {
                _db.clients.Add(client);
                _db.SaveChanges();
                saleOrder.ClientId =  _db.clients
                    .OrderByDescending(x => x.Id)
                    .Take(1)
                    .Select(x => x.Id)
                    .FirstOrDefault();
                _db.saleOrders.Add(saleOrder);
                _db.SaveChanges();
            }
            else
            {
                saleOrder.ClientId = _db.clients.Where(m => m.Name == client.Name).Select(x => x.Id).FirstOrDefault();
                _db.saleOrders.Add(saleOrder);
                _db.SaveChanges();
            }

            // Xử lí các sp người đó mua
            int saleOrderId = _db.saleOrders
                    .OrderByDescending(x => x.Id)
                    .Take(1)
                    .Select(x => x.Id)
                    .FirstOrDefault();

            foreach (BuyProductViewModel product in lstCartItems)
            {
                Products prod = new Products();
                prod = _db.products.Where(m => m.Id == product.productId).FirstOrDefault();
                Total += prod.DefaultSellingPrice;
                prod.Stock -= product.amount;
                SaleOrderDetails saleOrderDetail = new SaleOrderDetails()
                {
                    SaleOrderId = saleOrderId,
                    ExportProductId = prod.Id,
                    Description = "Xuất hàng theo hóa đơn của khách hàng " + client.Id,
                    Quantity = product.amount,
                    Total = prod.DefaultSellingPrice * product.amount
                };
                _db.saleOrderDetails.Add(saleOrderDetail);
                _db.SaveChanges();
            }

            // Cập nhật giá trị đơn hàng
            saleOrder.Total = (float)Total;
            _db.SaveChanges();

            lstCartItems = new List<BuyProductViewModel>();
            HttpContext.Session.Set("ssShoppingCart", lstCartItems);

            return RedirectToAction("SaleOrderConfirmation", "ShoppingCart", new { id = saleOrderId });
        }

        public IActionResult Remove(int id)
        {
            List<BuyProductViewModel> lstCartItems = HttpContext.Session.Get<List<BuyProductViewModel>>("ssShoppingCart");

            if (lstCartItems.Count > 0)
            {
                var selected = lstCartItems.Where(m => m.productId == id).SingleOrDefault();
                if (selected != null)
                {
                    lstCartItems.Remove(selected);
                }
            }

            HttpContext.Session.Set("ssShoppingCart", lstCartItems);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult SaleOrderConfirmation(int id)
        {
            ShoppingCartVM.saleOrder = _db.saleOrders.Include(m => m.client).Where(m => m.Id == id).SingleOrDefault();
            ShoppingCartVM.saleOrderDetails = _db.saleOrderDetails.Include(p => p.product).Where(p => p.SaleOrderId == id).ToList();
            return View(ShoppingCartVM);
        }
    }
}