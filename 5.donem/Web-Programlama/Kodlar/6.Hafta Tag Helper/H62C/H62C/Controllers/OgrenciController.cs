using Microsoft.AspNetCore.Mvc;

namespace H62C.Controllers
{
    public class OgrenciController : Controller
    {
        public IActionResult OgrEkle()
        {
            return View();
        }
        public string OgrKaydet()
        {
            return "Ogrenci Kaydedildi";
        }
        public IActionResult OgrEkleOto()
        {
            return View();
        }
    }
}
