using System.ComponentModel.DataAnnotations;

namespace H6B2.Models
{
    public class Ogrenci
    {
        [Display(Name ="Öğrenci Ad") ]
        [Required(ErrorMessage ="Lütfen Öğrenci Adını Giriniz")]
        [MinLength(3,ErrorMessage ="Ad alanı minimum 3 karakter olmalı")]
        [MaxLength(20,ErrorMessage ="Ad alanı Makismum 20 karakter olmalı")]
        public string OgrAd { get; set; }

        [Required(ErrorMessage = "Lütfen Öğrenci Soyadını Giriniz")]
        [Display(Name = "Öğrenci Soyad")]
        public string OgrSoyad { get; set; }


        [Required(ErrorMessage = "Lütfen Öğrenci No Giriniz")]
        [Display(Name = "Öğrenci No")]
        public string OgrNo { get; set; }

        [EmailAddress(ErrorMessage ="Mail adresi uygun değil")]
        public string OgrMail { get; set; }

        [Range(18,65,ErrorMessage ="Yaş 18-65 aralığında olmalı")]
        [Required(ErrorMessage = "Lütfen Öğrenci Yaş Giriniz")]
        [Display(Name = "Öğrenci Yaş")]
        public int OgrYas { get; set; }


        [Required(ErrorMessage = "Lütfen Öğrenci Doğum tarihi Giriniz")]
        [Display(Name = "Öğrenci Doğum Tarihi")]
        public DateTime OgrDogumTarihi { get; set; }

    }
}
