using Microsoft.EntityFrameworkCore;
using netCore.Hangfire.Application.Repositories;
using netCore.Hangfire.Persistence.Context;
using netCore.Hangfire.Persistence.Repositories;

namespace netCore.Hangfire.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<BaseDbContext>(option =>
                option.UseInMemoryDatabase(databaseName: "HangFireExampleDb"));

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
