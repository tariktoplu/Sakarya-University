using System.ComponentModel.DataAnnotations;

namespace TGDA.Models
{
    public class Ogrenci
    {
        [Required(ErrorMessage ="Öğrenci Adı zorunlu alandır. Lüften doldurun!")]
        [Display(Name ="Öğrenci Adı")]
        [StringLength(20)]
        [MinLength(3,ErrorMessage = "Ad en az üç karakter olmalıdır.")]
        public string OgrenciAd { get; set; }

        [Required(ErrorMessage = "Öğrenci Soyadı zorunludur, boş geçilemez.")]
        [Display(Name ="Öğrenci Soyadı")]
        [StringLength(50)]
        public string OgrenciSoyad{ get; set; }

        [Required(ErrorMessage = "Öğrenci Numarası zorunludur, boş geçilemez.")]
        [Display(Name = "Öğrenci Numarası")]
        public string OgrenciNumara{ get; set; }

        [Required(ErrorMessage = "Öğrenci Yaşı zorunludur, boş geçilemez.")]
        [Display(Name = "Öğrencinin Yaşı")]
        [Range(18,25,ErrorMessage ="Yaş değeri 18 ile 25 arasında olmalıdır.")]
        public int OgrenciYas{ get; set; }

        [Required(ErrorMessage = "E-Mail zorunlu, boş geçilemez.")]
        [Display(Name = "E-Posta Adresi")]

        [EmailAddress(ErrorMessage ="Lütfen geçerli bir e-posta adresi giriniz.")]
        public string OgrenciMail { get; set; }
        [Required(ErrorMessage = "Öğrenci Tarihi zorunlu alandır.")]
        [Display(Name = "Öğrencinin Doğum Tarihi")]
        [DataType(DataType.Date)]
        public string OgrenciDogumTarihi { get; set; }

    }
}