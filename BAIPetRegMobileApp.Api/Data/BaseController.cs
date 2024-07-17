using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BAIPetRegMobileApp.Api.Data
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<TEntity> : ControllerBase where TEntity : class
    {
        protected readonly UserDbContext userDbContext;

        public BaseController(UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetEntities()
        {
            return await userDbContext.Set<TEntity>().ToListAsync();
        }
    }
}
