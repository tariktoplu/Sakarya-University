using H6B2.Models;
using Microsoft.AspNetCore.Mvc;

namespace H6B2.Controllers
{
    public class OgrenciController : Controller
    {
        static List<Ogrenci> ogrenciler = new List<Ogrenci>();
        public IActionResult OgrEkle()
        {
            return View();
        }
        public IActionResult OgrEkleOto()
        {
            return View();
        }
        public IActionResult OgrKaydet(Ogrenci ogr)
        {
            if (ModelState.IsValid)
            {
                //Kayıt İşlemi
                ogrenciler.Add(ogr);
                TempData["msj"] = ogr.OgrAd + " adlı öğrenci Kaydedildi";
               return RedirectToAction("OgrList");

            }
            TempData["msj"] = "Kayıt İşlemi Başarısız";
            return RedirectToAction("OgrEkle");
            //Hata işlemi
        }

        public IActionResult OgrList()
        {
            return View(ogrenciler);
        }
    }
}
