using H92C.Models;
using Microsoft.AspNetCore.Mvc;

namespace H92C.Controllers
{
    public class YazarController : Controller
    {
       KitaplikContext k=new KitaplikContext(); 
        public IActionResult Index()
        {
            var yazarlar=k.Yazarlar.ToList();
            return View(yazarlar);
        }

        public IActionResult YazarEkle()
        {
            return View();
        }
        public IActionResult YazarKaydet(Yazar y)
        {
            if (ModelState.IsValid)
            {
                k.Yazarlar.Add(y);
              //  k.Add(y);
                k.SaveChanges();
                TempData["msj"] = y.YazarAd + " adlı yazar eklendi";
                return RedirectToAction("Index");   
            }
            TempData["msj"] = "Lütfen Dataları düzgün giriniz";
            return RedirectToAction("YazarEkle");
        }
    }
}
