
using H4C2.Models;
using Microsoft.AspNetCore.Mvc;

namespace H4C2.Controllers
{
    public class OgrenciController : Controller
    {
        public static List<Ogrenci>ogrenciler=new List<Ogrenci>();
        public IActionResult OgrEkle()
        {
            return View();
        }
        public string OgrKaydetGet()
        {
            string ad=HttpContext.Request.Query["OgrAd"];
            string soyad=HttpContext.Request.Query["OgrSoyad"];
            string no= HttpContext.Request.Query["OgrNo"];
            //Verinin benim istediğim formatta uygunluğunu kontorl etmek
            //Eğer uygunsa veri tabanına Kayıt vb değilse hata gösterme

            return ad +" "+soyad+" "+no;
        }
        [HttpPost]
        public string OgrKaydetPostt()
        {
            string ad = HttpContext.Request.Form["OgrAd"];
            string soyad = HttpContext.Request.Form["OgrSoyad"];
            string no = HttpContext.Request.Form["OgrNo"];
            //Verinin benim istediğim formatta uygunluğunu kontorl etmek
            //Eğer uygunsa veri tabanına Kayıt vb değilse hata gösterme

            return ad + " " + soyad + " " + no;
        }

        public string OgrKaydetParams(string OgrAd,string OgrSoyad, string OgrNo)
        {
            string ad = OgrAd;
            string soyad = OgrSoyad;
            string no = OgrNo;
            return ad + " " + soyad + " " + no;
        }

        public string OgrKaydetClass(Ogrenci ogr)
        {
            string ad = ogr.OgrAd;
            string soyad = ogr.OgrSoyad;
            int no = ogr.OgrNo;
            return ad + " " + soyad + " " + no;
        }
        public IActionResult OgrKaydetClassView(Ogrenci ogr)
        {
            if (ogr.OgrNo<0 || ogr.OgrNo > 1000)
            {
                TempData["hata"] = "Oğrenci Numarası Yanlış";
                return RedirectToAction("OgrHata");
            }
            if (ogr.OgrAd.Length < 4)
            {
                TempData["hata"] = "Ad 4 karakterden küçük olamaz";
                return RedirectToAction("OgrHata");
            }
            //ogrenciler.Add(ogr);
            //Veri Kaydı
            return View(ogr);
        }

        public IActionResult OgrKaydetClassAll(Ogrenci ogr)
        {
            if (ogr.OgrNo < 0 || ogr.OgrNo > 1000)
            {
                TempData["hata"] = "Oğrenci Numarası Yanlış";
                return RedirectToAction("OgrHata");
            }
            if (ogr.OgrAd.Length < 4)
            {
                TempData["hata"] = "Ad 4 karakterden küçük olamaz";
                return RedirectToAction("OgrHata");
            }

            ogrenciler.Add(ogr);
            TempData["msj"] = ogr.OgrAd + " adlı öğrenci eklendi";
            return RedirectToAction("OgrList");
        }
        public IActionResult OgrList()
        {
            return View(ogrenciler);
        }
        public IActionResult OgrHata() 
        {
            return View(); 
        }   
    }
}
