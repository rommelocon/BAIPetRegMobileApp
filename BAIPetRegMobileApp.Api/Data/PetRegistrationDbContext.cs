using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BAIPetRegMobileApp.Api.Data
{
    public class PetRegistrationDbContext : IdentityDbContext<UserModel>
    {
        public PetRegistrationDbContext(DbContextOptions<PetRegistrationDbContext> options) : base(options)
        {
        }
    }
}
