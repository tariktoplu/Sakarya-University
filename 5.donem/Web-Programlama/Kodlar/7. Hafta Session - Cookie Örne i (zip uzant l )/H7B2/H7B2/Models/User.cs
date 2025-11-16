using System.ComponentModel.DataAnnotations;

namespace H7B2.Models
{
    public class User
    {
        [Display(Name ="Kullanıcı Adı")]
        public string UsrName { get; set; }

        [Display(Name = "Şifre")]
        public string UsrPass { get; set; }
        public string? UsrColor { get; set; }
    }
}
