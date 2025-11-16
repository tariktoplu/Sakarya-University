using System.ComponentModel.DataAnnotations;

namespace H5C2.Models
{
    public class Ogrenci
    {
        [Display(Name ="Öğrenci Ad")]
        [Required(ErrorMessage ="Lütfen Ad alanını giriniz")]
        [MinLength(3,ErrorMessage ="Ad minumim 3 karakter olmalı")]
        [StringLength(100,20,ErrorMessage="dd")]
        public string OgrAd { get; set; }

        [MaxLength(50,ErrorMessage ="Soyad Makismum 50 karakter olmalı")]
        [Display(Name = "Öğrenci Soyad")]
        [Required(ErrorMessage = "Lütfen Soyad alanını giriniz")]
        public string OgrSoyad { get; set; }

        [Required(ErrorMessage = "Lütfen No alanını giriniz")]
        [Display(Name = "Öğrenci No")]
        public string OgrNo { get; set; }

        [Range(18,25,ErrorMessage ="Yaş 18-25 arasında olmalı")]
        [Required(ErrorMessage = "Lütfen Yaş alanını giriniz")]
        [Display(Name = "Öğrenci Yaş")]
        public int OgrYas{ get; set; }
    }
}
