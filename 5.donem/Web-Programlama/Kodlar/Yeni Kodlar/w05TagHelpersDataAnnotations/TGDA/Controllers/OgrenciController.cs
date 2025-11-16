using Microsoft.AspNetCore.Mvc;
using TGDA.Models;

namespace TGDA.Controllers
{
    public class OgrenciController : Controller
    {

        public static List<Ogrenci> ogrenciler = new List<Ogrenci>();
        public IActionResult OgrenciEklemeFormu()
        {
            return View();
        }

        public IActionResult OgrenciEkle(Ogrenci ogr)
        { // POSTTAN GELEN VERİ KONTROLÜ
            if (ModelState.IsValid)
            {
                // TEMP DATA MESAJ 
                TempData["txtMSG"] = ogr.OgrenciAd + " " + ogr.OgrenciSoyad + " isimli öğrenci kayıt edilmiştir.";
                // DB KAYIT
                ogrenciler.Add(ogr);
                // YÖNLENDİR
                return RedirectToAction("OgrenciListele");
            } else
            {
                // TEMP DATA MESAJ 
                TempData["txtMSG"] = " Form verilerinde hata var. Kontrol edin.";
                return RedirectToAction("OgrenciEklemeFormu");
            }

        }

        public IActionResult OgrenciListele(Ogrenci ogr)
        {
            return View(ogrenciler);
        }

        public IActionResult OgrenciCreateAuto()
        {
            return View();
        }


    }
}
