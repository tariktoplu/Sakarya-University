using Analyzer.Utilities;
using H92C.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace H92C.Controllers
{
    public class SorguController : Controller
    {
        KitaplikContext db=new KitaplikContext();
        public string Index()
        {
            string txt = "";
            int[] sayilar = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
            var SayiQuery =
                from sayi in sayilar
                where (sayi % 2) == 0
                select sayi;
            sayilar[1] = 8;
            foreach (int deger in SayiQuery)
            {
                txt = txt + " - " + deger;
            }
            return (txt);

        }

        public string Index2()
        {
            string txt = "";
            int[] sayilar = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
            var SayiQuery =
                (from sayi in sayilar
                where (sayi % 2) == 0
                select sayi).ToList();
            sayilar[1] = 8;
            foreach (int deger in SayiQuery)
            {
                txt = txt + " - " + deger;
            }
            return (txt);

        }

        public IActionResult Index3()
        {
            var kitaplar = (from ktp in db.Kitaplar
                           where ktp.KitapSayfasi > 500 && ktp.KitapSayfasi < 1000
                           select ktp);

            var kitaplar2=db.Kitaplar.Where(ktp=>ktp.KitapSayfasi>500 && ktp.KitapSayfasi<1000).ToList();

            var kitaplar3 = (from ktp in db.Kitaplar
                            orderby ktp.KtapAdi
                            select ktp).ToList();

            var kitaplar4 = (from ktp in db.Kitaplar
                             orderby ktp.KitapSayfasi descending
                             select ktp).ToList();
            var kitaplar5 = db.Kitaplar.OrderBy(x => x.KitapSayfasi);

            var Kitaplar6 = db.Kitaplar.OrderByDescending(x => x.KitapSayfasi);

            var kitaplar7 = (from ktp in db.Kitaplar
                            where ktp.KitapSayfasi > 500
                            select ktp.KtapAdi).ToList();

            //kitap adının içinde suç geçen kitaplar

            var kitaplar8 = db.Kitaplar.Where(x => x.KtapAdi.Contains("suç"));

            var kitaplar9 = from ktp in db.Kitaplar
                            where ktp.KtapAdi.Contains("suç")
                            select ktp;
           

            //Kitaplar tablosıundaki herhangi bir kayıtta kitapSayfası 1000 i geçen varsa true yoksa false
            var kitaplar10 = db.Kitaplar.Any(y => y.KitapSayfasi > 1000);

           //Kitaplar tablosunda tüm kayıtlardaki KitapSayfası 1000 den fazlaysa true değilse false
            var kitaplar11=db.Kitaplar.All(x=>x.KitapSayfasi>1000);

            //500 sayfadan küçük kitap sayısı
            var kitaplar12 = db.Kitaplar.Count(x => x.KitapSayfasi < 500);
            var kitaplar13 = db.Kitaplar.Where(x => x.KitapSayfasi < 500).Count();

            //Sayfa sayısı en fazla olan kitabın sayfa sayısı

            var kitaplar14 = db.Kitaplar.Max(x => x.KitapSayfasi);

            //Sayfa sayısı en az olan kitabın sayfa sayısı

            var kitaplar15 = db.Kitaplar.Min(x => x.KitapSayfasi);

            //sayfa ortalamasını getirir
            var kitaplar16 = db.Kitaplar.Average(x => x.KitapSayfasi);

            //Toplam sayfa sayını geitir
            var kitaplar17 = db.Kitaplar.Sum(s => s.KitapSayfasi);

            //1000 den büyyük sayfalı kitap varsa ilk bulduğu kaydı geitirir yoksa hata fırlatır
            //  var kitaplar18 = db.Kitaplar.First(x => x.KitapSayfasi > 1000);
            
            //100den büyük kitap sayfalı kitap varsa ilk kaydı dondurur yoksa null dondurur
            var kitaplar19 = db.Kitaplar.FirstOrDefault(x => x.KitapSayfasi > 1000);

            //join işlemi
            var kayit = db.Yazarlar.Include(x => x.Kitaplar).Where(x => x.YazarID == 1).ToList();
            var kayit2=(from y in db.Yazarlar
                       join ktp in db.Kitaplar
                       on y.YazarID equals ktp.YazarID
                       select new
                       {
                           YazarAdSoyad=y.YazarAd+" "+y.YazarSoyad,
                           KitapAd=ktp.KtapAdi
                       }).ToList();


            return View(kitaplar4);
        }
    }
}
