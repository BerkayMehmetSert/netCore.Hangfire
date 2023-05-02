using Microsoft.EntityFrameworkCore;
using netCore.Hangfire.Models.Entities;

namespace netCore.Hangfire.Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
