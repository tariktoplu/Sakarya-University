using Microsoft.AspNetCore.Mvc;
using w04Forms.Models;


namespace w04Forms.Controllers
{
    public class OgrenciController : Controller
    {
        static List<Ogrenci> students = new List<Ogrenci>();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public string Index(string OgrenciAd, string OgrenciSoyad, string OgrenciNumara)
        {
            // FORMDAKİ DEĞİŞKENLERİN KONTROLÜ 
            // DB KAYIT vs.
            return OgrenciAd + " " + OgrenciSoyad + " " + OgrenciNumara;
        }

        [HttpPost]
        public string OgrenciModelKaydet(Ogrenci ogr)
        {
            string txtBilgi = "Burası Ogrenci Modelinden Ogrenci Controller'ının OgrenciModelKaydet Action'ı \n\n";
            string txt = txtBilgi + ogr.OgrenciAd + " " + ogr.OgrenciSoyad + " " + ogr.OgrenciNumara;
            return txt;
        }

        [HttpPost]
        public IActionResult Kaydet(Ogrenci ogr)
        {
            students.Add(ogr);
            //return View(ogr);
            return RedirectToAction("OgrenciListele", "Ogrenci");
        }

        public IActionResult OgrenciListele()
        {
            return View(students);
        }
    }
}
