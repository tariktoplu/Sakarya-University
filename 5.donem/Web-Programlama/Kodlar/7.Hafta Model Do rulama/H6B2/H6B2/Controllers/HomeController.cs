using H6B2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace H6B2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult IlkIstek()
        {
            ViewBag.msj1 = "ViewBag Mesajı";
            ViewData["msj2"] = "View Data Mesajı";
            TempData["msj3"] = "TempData Mesajı";
         
            return View();
        }

        public IActionResult IkinciIstekOrn()
        {
            ViewBag.msj1 = "ViewBag Mesajı";
            ViewData["msj2"] = "View Data Mesajı";
            TempData["msj3"] = "TempData Mesajı";
            return RedirectToAction("IkinciIstek");
        }

        public IActionResult IkinciIstek()
        {
           // TempData["msj3"]
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}