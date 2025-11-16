using H92C.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace H92C.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YazarApiController : ControllerBase
    {
        KitaplikContext k = new KitaplikContext();
        // GET: api/<YazarApiController>
        [HttpGet]
        public List<Yazar> Get()
        {
            var yazarlar=k.Yazarlar.ToList();
           // var yazarlar2=k.Yazarlar.Include(x=>x.Kitaplar).ToList();
           //Yukardaki yazarlar2 yi göndermek için ayar yapmak lazım
           //aşağdaki yazarlar3 için yeni bir model oluşturup o modeli göndermek lazım
            var yazarlar3=(from y in k.Yazarlar 
                          join kt in k.Kitaplar
                          on y.YazarID equals kt.YazarID
                          select new
                          {
                              KitapAd=kt.KtapAdi,
                              YazarAd=y.YazarAd
                          }).ToList();

            var yazarlar4 = k.Yazarlar
               .Include(y => y.Kitaplar)
               .Select(y => new Yazar
               {
                   YazarID = y.YazarID,
                   YazarAd = y.YazarAd,
                   Kitaplar = y.Kitaplar.Select(k => new Kitap
                   {
                       KitapID = k.KitapID,
                       KtapAdi = k.KtapAdi
                   }).ToList()
               }).ToList();


            //return yazarlar;
            return yazarlar4;
        }

        // GET api/<YazarApiController>/5
        [HttpGet("{id}")]
        public ActionResult<Yazar> Get(int id)
        {
           var yazar =k.Yazarlar.FirstOrDefault(x=>x.YazarID==id);
            if (yazar is null)
             {
                return NoContent();
             }
            return yazar;
        }

        // POST api/<YazarApiController>
        [HttpPost]
        public ActionResult Post([FromBody] Yazar y)
        {
            k.Yazarlar.Add(y);
            k.SaveChanges();
            return Ok(y.YazarAd+" adlı yazar eklendi");

        }

        // PUT api/<YazarApiController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Yazar y)
        {
            var yazar = k.Yazarlar.FirstOrDefault(x => x.YazarID == id);
            if(yazar is null)
            {
                return NotFound();
            }
            yazar.YazarAd= y.YazarAd;
            yazar.YazarSoyad=y.YazarSoyad;
            k.Yazarlar.Update(yazar);
            k.SaveChanges();
            return Ok(y.YazarAd + " adlı yazar güncellendi");
        }

        // DELETE api/<YazarApiController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var yazar = k.Yazarlar.Include(x=>x.Kitaplar).FirstOrDefault(x => x.YazarID == id);
            if (yazar is null)
            {
                return NotFound();
            }
            if (yazar.Kitaplar.Count > 0)
            {
                return NotFound();
            }
            k.Yazarlar.Remove(yazar);
            k.SaveChanges();
            return Ok();
        }
    }
}
