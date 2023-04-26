using Microsoft.AspNetCore.Identity;

namespace task1.API.Data.Models
{
    public class User : IdentityUser
    {
        public string Position { get; set; } = string.Empty;
    }
}
