using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemoMY.Controllers
{
    public class DashboardController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            using var context = new Context();
            ViewBag.count = context.Blogs.Count();
            ViewBag.countWriter = context.Blogs.Where(x => x.WriterId == 1).Count();
            ViewBag.countCategories = context.Categories.Count();
            return View();
        }
    }
}
