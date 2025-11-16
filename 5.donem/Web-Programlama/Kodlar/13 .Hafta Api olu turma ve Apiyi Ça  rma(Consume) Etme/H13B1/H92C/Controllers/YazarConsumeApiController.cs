using H92C.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace H92C.Controllers
{
    public class YazarConsumeApiController : Controller
    {
        KitaplikContext k = new KitaplikContext();
        public async Task<IActionResult> Index()
        {
            List<Yazar> yazarlar = new List<Yazar>();
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://localhost:7030/api/YazarApi/");
            var jsondata = await response.Content.ReadAsStringAsync();
            yazarlar = JsonConvert.DeserializeObject<List<Yazar>>(jsondata);
            return View(yazarlar);
        }

        public ActionResult Index2(int id)
        {
            var yazarlar=k.Yazarlar.ToList();
            return View(yazarlar);
        }
    }
}
