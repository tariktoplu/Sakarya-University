using Microsoft.AspNetCore.Identity;

namespace H12C2.Models
{
    public class UserDetails:IdentityUser
    {
        public string UserAd { get; set; }
        public string UserSoyad { get; set; }
    }
}
