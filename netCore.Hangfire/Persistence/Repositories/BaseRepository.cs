using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using netCore.Hangfire.Application.Repositories;
using netCore.Hangfire.Models.Common;

namespace netCore.Hangfire.Persistence.Repositories
{
    public class BaseRepository<TEntity, TContext> : IBaseRepository<TEntity>
    where TEntity : BaseEntity where TContext : DbContext
    {
        private readonly TContext _context;

        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(expression);
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>>? expression = null)
        {
            if(expression == null)
            {
                return await _context.Set<TEntity>().ToListAsync();
            }

            return await _context.Set<TEntity>().Where(expression).ToListAsync();
        }

        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
           _context.Set<TEntity>().Remove(entity);
        }
    }
}
