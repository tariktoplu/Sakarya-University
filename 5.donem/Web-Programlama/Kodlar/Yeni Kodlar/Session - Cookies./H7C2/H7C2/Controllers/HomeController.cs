using H7C2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace H7C2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static List<User> users = new List<User>()
        {
            new User(){UserName="can",UserPass="123",UserColor="Green"},
            new User(){UserName="hasan",UserPass="456",UserColor="red"},
        };

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult LoginKontrol(User u)
        {
           // bool bayrak = false;
          /*
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login");
            }
          */
            foreach (var user in users)
            {
                if (user.UserName==u.UserName && user.UserPass == u.UserPass)
                {
                    //Login
                    HttpContext.Session.SetString("SesUser", user.UserName);
                    var cokopt = new CookieOptions
                    {
                        Expires = DateTime.Now.AddHours(1)
                    };
                    HttpContext.Response.Cookies.Append("CookRenk", user.UserColor);
                   // bayrak = true;
                   // break;
                    return RedirectToAction("Icerik");
                    
                    /* var ustrring= JsonConvert.SerializeObject(u)
                    HttpContext.Session.SetString("ObjectSes", ustrring);
                    var deg = HttpContext.Session.GetString("ObjectSes");
                    var usr2=JsonConvert.DeserializeObject<User>(deg);
                    */
                }
            }
           // if (bayrak) { }
            TempData["msj"] = "Kullanıcı Adı veya Şifre Hatalı";
            return RedirectToAction("Login");
        }

        public IActionResult Icerik()
        {
            if (HttpContext.Session.GetString("SesUser") is null)
            {
                TempData["msj"] = "Lütfen Login olunuz";
                return RedirectToAction("Login");
            }
            return View();
        }
        public IActionResult Cikis()
        {
                 HttpContext.Session.Clear();
                TempData["msj"] = "Başaraılı bir şekilde çıkış yaptınız";
                return RedirectToAction("Login");
         
        
        }
    }
}