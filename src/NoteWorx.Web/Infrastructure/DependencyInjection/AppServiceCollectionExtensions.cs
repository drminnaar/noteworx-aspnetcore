using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace NoteWorx.Web.Infrastructure.DependencyInjection
{
   internal static partial class AppServiceCollectionExtensions
   {
      internal static IServiceCollection ConfigureAppServices(
         this IServiceCollection services,
         IConfiguration configuration,
         IHostingEnvironment hostingEnvironment)
      {
         services.ConfigureDataServices(configuration, hostingEnvironment);
         services.ConfigureIdentityServices();
         services
            .AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

         return services;
      }
   }
}