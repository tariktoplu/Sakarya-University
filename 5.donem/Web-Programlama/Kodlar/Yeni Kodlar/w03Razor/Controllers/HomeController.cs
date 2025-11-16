using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using w03Razor.Models;

namespace w03Razor.Controllers
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

        public IActionResult RazorDeneme() {
            return View();
            
            
        }

        public IActionResult FirstRequest()
        {
            ViewBag.VBmesaj = "ViewBag Mesaj metni";
            ViewData["VDmesaj"] = "ViewData Mesaj metni";
            TempData["TDmesaj"] = "TempData Mesaj metni";

            TempData["Sayi"] = 19;

            //return View();


            return RedirectToAction("SecondRequest");
        }

        public IActionResult SecondRequest()
        {
            return View();
        }


        public IActionResult Privacy()
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
