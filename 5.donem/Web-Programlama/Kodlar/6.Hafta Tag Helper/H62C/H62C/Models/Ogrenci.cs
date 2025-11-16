

using System.ComponentModel.DataAnnotations;

namespace H62C.Models
{
    public class Ogrenci
    {
        [Required(ErrorMessage ="Lütfen Ad alanını Giriniz")]
        [Display(Name ="Adınız")]
        public string OgrAd { get; set; }


        [Required(ErrorMessage = "Lütfen Soyad alanını Giriniz")]
        [Display(Name = "Öğrenci Soyad")]
        public string OgrSoyad { get; set; }

        [Display(Name = "Öğrenci No")]
        [Required(ErrorMessage = "Lütfen No alanını Giriniz")]
        public string OgrNo { get; set; }

        [Range(18,25,ErrorMessage ="Yaş 18-25 aralığında olabilir")]
        [Required(ErrorMessage = "Lütfen Yaş alanını Giriniz")]
        [Display(Name = "Öğrenci Yas")]
        public int OgrYas { get; set; }

        [Required(ErrorMessage = "Lütfen Doğum tarihi alanını Giriniz")]
        [Display(Name = "Öğrenci Doğum Tarihi")]
        public DateTime OgrDogumTarihi { get; set; }

    }
}
