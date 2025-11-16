using H92C.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult YazarDetay(int ?id)
        {
            if (id is null)
            {
                TempData["msj"] = "Lütfen dataları düzgün giriniz";
                return RedirectToAction("Index");
            }
            var yazar =k.Yazarlar.Include(x=>x.Kitaplar).First(x=>x.YazarID==id);
            if (yazar is null)
            {
                TempData["msj"] = "Yazar Bulunamadı";
                return RedirectToAction("Index");
            }
            return View(yazar); 
        }

        public IActionResult YazarEkle()
        {
            return View();
        }

        public IActionResult YazarSil(int? id)
        {
            if (id is null)
            {
                TempData["msj"] = "Lütfen dataları düzgün giriniz";
                return RedirectToAction("Index");
            }
            var yazar = k.Yazarlar.Find(id);
            if (yazar is null)
            {
                TempData["msj"] = "Yazar Bulunamadı";
                return RedirectToAction("Index");
            }
            var kayit=k.Yazarlar.Include(x=>x.Kitaplar).Where(x=>x.YazarID==id).ToList();
            if (kayit[0].Kitaplar.Count > 0)
            {
                TempData["msj"] = "Yazara ait Kitaplar var. Önce Kitapları siliniz";
                return RedirectToAction("Index");
            }
            k.Yazarlar.Remove(yazar);
            k.SaveChanges();
            TempData["msj"] = yazar.YazarAd +" adlı yazar silindi";
            return RedirectToAction("Index");
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

        public IActionResult YazarDuzenle(int? id)
        {
            if (id is null)
            {
                TempData["msj"] = "Lütfen dataları düzgün giriniz";
                return RedirectToAction("Index");
            }
            var yazar = k.Yazarlar.Find(id);
            if (yazar is null)
            {
                TempData["msj"] = "Yazar Bulunamadı";
                return RedirectToAction("Index");
            }
            return View(yazar);
        }
        [HttpPost]
        public IActionResult YazarDuzenle(int? id,Yazar y)
        {
            if (id is null)
            {
                TempData["msj"] = "Lütfen dataları düzgün giriniz";
                return RedirectToAction("Index");
            }
            if (id !=y.YazarID)
            {
                TempData["msj"] = "id ler eşleşmiyor";
                return RedirectToAction("Index");
            }
   
            if (ModelState.IsValid)
            {
                k.Yazarlar.Update(y);
                k.SaveChanges();
                TempData["msj"] = y.YazarAd + "adlı yazara ait güncelleme yapıldı";
                return RedirectToAction("Index");
            }
            TempData["msj"] = "Güncelleme işlemi başarısız";
            return RedirectToAction("Index");
        }
    }
}
