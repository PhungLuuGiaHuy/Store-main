using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using quần_áo_nam_cao_cấp.Models;


namespace quần_áo_nam_cao_cấp.Controllers
{
    [Route("/products")]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        private readonly StoreDbContext _context;

        public ProductController(ILogger<ProductController> logger, StoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Hiện thị danh sách sản phẩm, có nút chọn đưa vào giỏ hàng
        public IActionResult Index()
        {
            var products = _context.products.ToList();
            return View(products);
        }

        // Thêm sản phẩm vào cart
        public IActionResult AddToCart([FromRoute] int productid)
        {
            var sanpham = _context.products
                            .Where(p => p.ProductId == productid)
                            .FirstOrDefault();
            if (productid == null)
                return NotFound("Không có sản phẩm");

         // Xử lý đưa vào Cart ...


            return RedirectToAction(nameof(Cart));
        }
        /// xóa item trong cart
        [Route("/removecart/{productid:int}", Name = "removecart")]
        public IActionResult RemoveCart([FromRoute] int id)
        {

            // Xử lý xóa một mục của Cart ...
            return RedirectToAction(nameof(Cart));
        }

        /// Cập nhật
        [Route("/updatecart", Name = "updatecart")]
        [HttpPost]
        public IActionResult UpdateCart([FromForm] int id, [FromForm] int quantity)
        {
            // Cập nhật Cart thay đổi số lượng quantity ...

            return RedirectToAction(nameof(Cart));
        }


        // Hiện thị giỏ hàng
        [Route("/cart", Name = "cart")]
        public IActionResult Cart()
        {
            return View();
        }

        [Route("/checkout")]
        public IActionResult CheckOut()
        {
            // Xử lý khi đặt hàng
            return View();
        }
    }
}
