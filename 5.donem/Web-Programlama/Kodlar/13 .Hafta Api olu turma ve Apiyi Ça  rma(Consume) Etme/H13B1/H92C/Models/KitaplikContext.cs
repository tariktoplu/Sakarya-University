using Microsoft.EntityFrameworkCore;

namespace H92C.Models
{
    public class KitaplikContext:DbContext
    {
        public DbSet<Kitap> Kitaplar { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=Kitaplik2024C2;Trusted_Connection=True;");
        }
    }
}
