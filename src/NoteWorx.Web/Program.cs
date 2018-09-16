using System.IO;
using System.Reflection;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NoteWorx.Infrastructure.Data;

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

      private static void SeedDb(IWebHost host)
      {
         var scopeFactory = host.Services.GetService<IServiceScopeFactory>();

         using (var scope = scopeFactory.CreateScope())
         {
            var environment = scope.ServiceProvider.GetService<IHostingEnvironment>();

            // TODO: Uncomment the following code to limit 
            // database seeding to development

            // if (!environment.IsDevelopment())
            //    return;

            var executingPath = Path.GetDirectoryName(
               Assembly.GetExecutingAssembly().Location);

            var usersFilePath = Path.Combine(executingPath, "users.json");

            var notesFilePath = Path.Combine(executingPath, "notes.json");

            var tagsFilePath = Path.Combine(executingPath, "tags.json");

            var seeder = scope
               .ServiceProvider
               .GetService<Seeder>()
               .IncludeUsers(usersFilePath)
               .IncludeTags(tagsFilePath)
               .IncludeNotes(notesFilePath);

            seeder.Seed();
         }
      }

      public static IWebHost BuildWebHost(string[] args)
      {
         return WebHost.CreateDefaultBuilder()
             .UseKestrel()
             .UseStartup<Startup>()
             .Build();
      }
   }
}
