using netCore.Hangfire.Application.Repositories;
using netCore.Hangfire.Persistence.Context;

namespace netCore.Hangfire.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BaseDbContext _context;

        public UnitOfWork(BaseDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
