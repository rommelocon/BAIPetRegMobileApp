using BAIPetRegMobileApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BAIPetRegMobileApp.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } = default!;
    }
}
