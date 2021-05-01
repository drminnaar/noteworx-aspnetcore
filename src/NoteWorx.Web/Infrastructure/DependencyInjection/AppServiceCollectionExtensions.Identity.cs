using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NoteWorx.Identity.Data.Models;
using NoteWorx.Notes.Data;

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
