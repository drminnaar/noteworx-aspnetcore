using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NoteWorx.Notes.Data;

namespace NoteWorx.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
            SeedDb(host);
            host.Run();
        }

        private static void SeedDb(IHost host)
        {
            var scopeFactory = host.Services.GetRequiredService<IServiceScopeFactory>();

            using var scope = scopeFactory.CreateScope();

            var environment = scope.ServiceProvider.GetService<IWebHostEnvironment>();

            // TODO: Uncomment the following code to limit
            // database seeding to development

            // if (!environment.IsDevelopment())
            //    return;

            var executingPath = Path
                .GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                ?? string.Empty;

            var usersFilePath = Path.Combine(executingPath, "users.json");

            var notesFilePath = Path.Combine(executingPath, "notes.json");

            var seeder = scope
               .ServiceProvider
               .GetRequiredService<Seeder>()
               .IncludeUsers(usersFilePath)
               .IncludeNotes(notesFilePath);

            seeder.Seed();
        }

        public static IHost BuildWebHost(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .Build();
        }
    }
}
