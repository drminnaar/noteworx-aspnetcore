using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NoteWorx.Infrastructure.Data;
using NoteWorx.Infrastructure.Data.Models;

namespace NoteWorx.Web.Infrastructure.DependencyInjection
{
   internal static partial class AppServiceCollectionExtensions
   {
      private static IServiceCollection ConfigureIdentityServices(
         this IServiceCollection services)
      {
         services
            .AddIdentity<AppUser, AppRole>()
            .AddEntityFrameworkStores<NoteWorxDbContext>()
            .AddDefaultTokenProviders();

         return services;
      }
   }
}