using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using quần_áo_nam_cao_cấp.Models;

namespace quần_áo_nam_cao_cấp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly StoreDbContext _context;

        public HomeController(ILogger<HomeController> logger, StoreDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        private IActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }
        public ActionResult ListProduct()
        {
            StoreDbContext context = new StoreDbContext();
            var listProduct = context.products.ToList();
            return View(listProduct);
        }
        public IActionResult ViewProduct(int productid)
        {
            StoreDbContext context = new StoreDbContext();
            Product product = context.products.SingleOrDefault(p => p.ProductId == productid);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}
