using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace quần_áo_nam_cao_cấp.Controllers
{
    public class ViewProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
