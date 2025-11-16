using H7B2.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace H7B2.Controllers
{
    public class UserController : Controller
    {
        static List<User> Users = new List<User>()
        {
            new User{ UsrName="can",UsrPass="123",UsrColor="Green"},
            new User{ UsrName="ayse",UsrPass="456",UsrColor="red"},
        };
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("SesUsr") is  null)
            {
                return View();
            }
            return View("AnaSayfa");
        }
        public IActionResult LogOut()
        {
            if (HttpContext.Session.GetString("SesUsr") is not null)
            {
                TempData["msj"] = "Güvenli bir şekilde çıkış yaptınız";
                HttpContext.Session.Clear();
            }
         
            return RedirectToAction("Index");


        }
        public IActionResult UsrLogin(User u)
        {
            foreach (var user in Users)
            {
                if(u.UsrName==user.UsrName && u.UsrPass == user.UsrPass)
                {
                    //Login başarılı
                    HttpContext.Session.SetString("SesUsr", user.UsrName);
                    var cookopt = new CookieOptions {
                        Expires = DateTime.Now.AddSeconds(100),
                     };
                    HttpContext.Response.Cookies.Append("CookiRenk",user.UsrColor,cookopt);
                    TempData["msj"] = user.UsrName + " kullanıcısı login oldu";
                    return  RedirectToAction("UsrIcerik");
                }
            }
            TempData["msj"] = "Kullanıcı Adı/Şifre Hatalı";
            return RedirectToAction("Index");
        }

        public IActionResult UsrIcerik()
        {
           if (HttpContext.Session.GetString("SesUsr") is null)
            {
                TempData["msj"] = "Lütfen önce Login olun";
                return RedirectToAction("Index");
            }
            return View();  
        }

        public IActionResult UsrSesSet()
        {
            User usr= new User();
            usr.UsrName = "Hasan";
            usr.UsrPass = "ztaa";
            usr.UsrColor = "green";
            string usrJson=JsonConvert.SerializeObject(usr);

            HttpContext.Session.SetString("SesObj",usrJson);

            return RedirectToAction("UsrIcerik");
        }

        public IActionResult UsrSesGet()
        {
            if (HttpContext.Session.GetString("SesObj") is not null)
            {
                var stJson = HttpContext.Session.GetString("SesObj");
                User u = JsonConvert.DeserializeObject<User>(stJson);
                return View(u);
            }
            TempData["msj"] = "Once Obje Session oluştur";
            return RedirectToAction("Index");
        }
    }
}
