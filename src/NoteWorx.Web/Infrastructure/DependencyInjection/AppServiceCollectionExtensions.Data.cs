using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NoteWorx.Notes.Data;

namespace NoteWorx.Web.Infrastructure.DependencyInjection
{
    internal static partial class AppServiceCollectionExtensions
    {
        private static IServiceCollection ConfigureDataServices(
          this IServiceCollection services,
          IConfiguration configuration,
          IWebHostEnvironment hostingEnvironment)
        {
            services.AddDbContext<NoteWorxDbContext>(options =>
            {
                options.UseNpgsql(
                configuration.GetConnectionString("NoteWorx"),
                builder =>
                {
                    var assembly = typeof(NoteWorxDbContext).Assembly.FullName;

                    builder.MigrationsAssembly(assembly);
                });

                if (hostingEnvironment.IsDevelopment())
                    options.EnableSensitiveDataLogging();
            });

            services.AddScoped<Seeder>();
            services.AddScoped<NoteDao, NoteDao>();

            return services;
        }
    }
}
