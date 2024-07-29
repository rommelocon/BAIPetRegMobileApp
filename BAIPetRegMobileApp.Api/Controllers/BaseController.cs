using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BAIPetRegMobileApp.Api.Data;

namespace BAIPetRegMobileApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TContext, TKey> : ControllerBase
    where TEntity : class
    where TContext : DbContext
    {
        protected readonly TContext _context;

        protected BaseController(TContext context)
        {
            _context = context;
        }

        protected abstract TKey GetId(TEntity entity);
        protected abstract bool IdMatches(TEntity entity, TKey id);

        // GET: api/[controller]
        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<TEntity>>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
    }
}