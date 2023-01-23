using Identity.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.API.Data
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public readonly IHttpContextAccessor httpContextAccessor;

        public IdentityContext(DbContextOptions<IdentityContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public DbSet<ApplicationUserTokens> ApplicationUserTokens { get; set; }

    }
}