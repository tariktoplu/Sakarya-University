using H4C2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace H4C2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IlkIstek ()
        {
            ViewBag.msj1 = "ViewBag mesajı";
            ViewData["msj2"] = "ViewData mesajı";
            TempData["msj3"] = "TempData mesajı";
            return View();
        }
        public IActionResult IkinciIstekRedirectIle()
        {
            ViewBag.msj1 = "ViewBag mesajı";
            ViewData["msj2"] = "ViewData mesajı";
            TempData["msj3"] = "TempData mesajı";
            return RedirectToAction("IkinciIstek");
            return View();
        }
        public IActionResult IkinciIstek()
        {
   
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}