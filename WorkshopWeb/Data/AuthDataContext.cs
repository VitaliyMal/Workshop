using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Workshop.Server.Entity;
using WorkshopWeb;

namespace Workshop.Server.Data
{
    public class AuthDataContext : IdentityDbContext<User>
    {
        public AuthDataContext(DbContextOptions<AuthDataContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<User>().Property(u => u.Initials).HasMaxLength(5);

            builder.HasDefaultSchema("identity");
        }
    }
}
