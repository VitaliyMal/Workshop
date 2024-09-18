using Microsoft.AspNetCore.Identity;

namespace Workshop.Server.Entity
{
    public class User 

    {
        public int Id { get; set; }
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
    }
}
