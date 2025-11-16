using H5C2.Models;
using Microsoft.AspNetCore.Mvc;

namespace H5C2.Controllers
{
    public class OgrenciController : Controller
    {
        public static List<Ogrenci> ogrenciler =new List<Ogrenci>();
        public IActionResult OgrEkle()
        {
            return View();
        }
        public IActionResult OgrEkleOto()
        {
            return View();
        }
        public IActionResult OgrList()
        {
            return View(ogrenciler);
        }
        public IActionResult OgrHata()
        {
            return View();
        }
        public IActionResult OgrKaydet(Ogrenci ogr)
        {
            if (ogr.OgrAd.Length < 3) //Normal sartlarda class propertilerine ait istedğim tüm kısıtlamaların kontrolunu yapmam gerekli
            {
                //Hata
            }
            if (ModelState.IsValid)
            {
                //Başarılı Veri tabanına kayıt vb
                ogrenciler.Add(ogr);
                TempData["msj"] = ogr.OgrAd + " " + ogr.OgrSoyad + " adlı öğrenci Eklendi";
                return RedirectToAction("OgrList");
            }
            TempData["hata"] = "Lütfen Öğrenci verilerini eksiksiz giriniz";
            return RedirectToAction("OgrHata");
        }
    }
}
