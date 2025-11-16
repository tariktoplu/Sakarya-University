using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace H92C.Models
{
    public class Kitap
    {
        [Key]
        public int KitapID { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Kitap Adı ")]
        public string KtapAdi { get; set; }
        public int YazarID { get; set; }

        public int KitapSayfasi { get; set; }
        public Yazar Yazar { get; set; }

    }
}
