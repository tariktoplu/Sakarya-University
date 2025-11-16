using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace H12C2.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
