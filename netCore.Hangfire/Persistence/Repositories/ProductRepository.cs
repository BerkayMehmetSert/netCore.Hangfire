using netCore.Hangfire.Application.Repositories;
using netCore.Hangfire.Models.Entities;
using netCore.Hangfire.Persistence.Context;

namespace netCore.Hangfire.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<Product, BaseDbContext>, IProductRepository
    {
        public ProductRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
