using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace H12C2.Controllers
{
    [Authorize]
    public class YetkiController : Controller
    {
   
        public IActionResult Index()
        {
            return View();
        }
    }
}
