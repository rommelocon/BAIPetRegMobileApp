using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BAIPetRegMobileApp.Api.Models;

namespace BAIPetRegMobileApp.Api.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<PetRegistration> PetRegistration { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
