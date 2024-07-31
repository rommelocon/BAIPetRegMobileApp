using BAIPetRegMobileApp.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace BAIPetRegMobileApp.Api.Services
{
    public abstract class BaseService<TEntity> where TEntity : class
    {
        protected readonly UserDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected BaseService(UserDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        // Add other common methods here if needed
    }
}
