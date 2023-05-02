using Hangfire;

namespace netCore.Hangfire.Application.Jobs
{
    public static class ServiceExtensions
    {
        public static void AddHangfireServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddHangfire(config => 
                config.UseSqlServerStorage(Configuration.GetConnectionString("DefaultHangfireConnection")));

            services.AddHangfireServer();
        }
    }
}
