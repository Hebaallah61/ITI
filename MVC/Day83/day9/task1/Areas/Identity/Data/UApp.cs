using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;

namespace task1.Areas.Identity.Data
{
    public class UApp:IdentityUser
    {
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set; }
    }
}
