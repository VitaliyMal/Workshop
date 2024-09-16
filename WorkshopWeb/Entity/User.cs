using Microsoft.AspNetCore.Identity;

namespace Workshop.Server.Entity
{
    public class User : IdentityUser

    {
        public string? Initials { get; set; }
    }
}
