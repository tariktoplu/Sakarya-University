using H32C.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace H32C.Controllers
{
    public class OgrenciController : Controller
    {
       static  List<Ogrenci> ogrenciList =new List<Ogrenci>();
        public IActionResult OgrEkle()
        {
            return View();
        }
        [HttpPost]
        public string OgrKaydet()
        {
            string ad= HttpContext.Request.Form["OgrAd"];
            string soyad= HttpContext.Request.Form["OgrSoyad"];
            string no= HttpContext.Request.Form["OgrNo"];
            return ad+" "+soyad +" adlı Öğrenci Kaydedildi";
        }
        [HttpGet]
        public string OgrKaydetGet()
        {
            string ad = HttpContext.Request.Query["OgrAd"];
            string soyad = HttpContext.Request.Query["OgrSoyad"];
            string no = HttpContext.Request.Query["OgrNo"];
            return ad+" "+soyad+" adlı öğrenci kaydedildi";
        }
    
        public string OgrKaydetParams(string OgrAd,string OgrSoyad, string OgrNo)
        {
            return OgrAd + " " + OgrSoyad + " adlı öğrenci kaydedildi";
        }
        public string OgrKaydetClass(Ogrenci ogr)
        {
            return ogr.OgrAd + " " + ogr.OgrSoyad + " adlı öğrenci kaydedildi";
        }

        public ActionResult OgrKaydetView(Ogrenci ogr)
        {
         
           if (Convert.ToInt32 (ogr.Ogrno)<1000 && Convert.ToInt32(ogr.Ogrno) > 0)
            {
                //Veritabanına KAyıy
                return View(ogr);
            }
            return View("OgrHata");
        }

        public ActionResult OgrKaydetMultiClass(Ogrenci ogr)
        {
      
            if (Convert.ToInt32(ogr.Ogrno) > 1000 || Convert.ToInt32(ogr.Ogrno) < 0)
            {
                
                return View("OgrHata");
            }
            Personel per = new Personel();
            per.PerSicil = 500;
            Kisi kisi = new Kisi();
            kisi.ogr = ogr;
            kisi.per = per;
            //Veritabanına KAyıy
            ogrenciList.Add(ogr);
            return View(kisi);
           
        }

        public IActionResult OgrList()
        {
            return View(ogrenciList);
        }
    }
}
