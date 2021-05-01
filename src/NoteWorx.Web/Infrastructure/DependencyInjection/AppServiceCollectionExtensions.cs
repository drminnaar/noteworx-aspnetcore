using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NoteWorx.Web.Infrastructure.DependencyInjection
{
    internal static partial class AppServiceCollectionExtensions
    {
        internal static IServiceCollection ConfigureAppServices(
           this IServiceCollection services,
           IConfiguration configuration,
           IWebHostEnvironment hostingEnvironment)
        {
            services.ConfigureDataServices(configuration, hostingEnvironment);
            services.ConfigureIdentityServices();
            services.AddControllersWithViews();

            return services;
        }
    }
}
