using System.ComponentModel.DataAnnotations;

namespace H7C2.Models
{
    public class User
    {
        [Required(ErrorMessage = "Kıllanıcı Adı Zorunlu")]
        [Display(Name ="Kullanıcı Adı")]
        [MaxLength(25,ErrorMessage ="Kullanıcı Adı Maksimum 25 Kakareter olabilir")]
        public string UserName { get; set; }

        [Required(ErrorMessage ="Şifre Zorunlu")]
        [Display(Name = "Kullanıcı Şifresi")]
        [MinLength(3,ErrorMessage ="Şifre Minimum 3 Karakter olmalı")]

       // [Compare("Pass1",ErrorMessage ="Şifreler Uyuşmuyır")]
        public string UserPass { get; set; }

        public string UserColor { get; set; }
    }
}
