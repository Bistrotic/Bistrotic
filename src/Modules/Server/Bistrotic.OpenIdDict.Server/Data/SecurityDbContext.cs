namespace Bistrotic.OpenIdDict.Data
{
    using Bistrotic.Infrastructure.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class SecurityDbContext : IdentityDbContext<ApplicationUser>
    {
        public SecurityDbContext(DbContextOptions options)
            : base(options)
        {
        }
    }
}