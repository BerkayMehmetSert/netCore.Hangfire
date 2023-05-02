using netCore.Hangfire.Application.Jobs;
using netCore.Hangfire.Application.Services;

namespace netCore.Hangfire.Application
{
    public static class ServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<EmailBackgroundJob>();
        }
    }
}
