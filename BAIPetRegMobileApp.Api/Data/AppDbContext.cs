using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BAIPetRegMobileApp.Api.Models;

namespace BAIPetRegMobileApp.Api.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<BAIPetRegMobileApp.Api.Models.User> User { get; set; } = default!;
    }
}
