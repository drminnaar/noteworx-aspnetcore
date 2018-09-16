using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NoteWorx.Infrastructure.Data;
using NoteWorx.Infrastructure.Data.Commands;
using NoteWorx.Infrastructure.Data.Queries;
using NoteWorx.Infrastructure.Data.Repositories;

namespace NoteWorx.Web.Infrastructure.DependencyInjection
{
   internal static partial class AppServiceCollectionExtensions
   {
      private static IServiceCollection ConfigureDataServices(
        this IServiceCollection services,
        IConfiguration configuration,
        IHostingEnvironment hostingEnvironment)
      {
         services.AddDbContext<NoteWorxDbContext>(options =>
         {
            options.UseNpgsql(
               configuration.GetConnectionString("NoteWorx"),
               builder =>
               {
                  var assembly = Assembly
                     .GetAssembly(typeof(NoteWorxDbContext))
                     .FullName;

                  builder.MigrationsAssembly(assembly);
               });

            if (hostingEnvironment.IsDevelopment())
               options.EnableSensitiveDataLogging();
         });

         services.AddScoped<Seeder>();
         services.AddScoped<INoteQuery, NoteQuery>();
         services.AddScoped<IAddNoteCommand, AddNoteCommand>();
         services.AddScoped<IAddTagsCommand, AddTagsCommand>();
         services.AddScoped<IDeleteNotesCommand, DeleteNotesCommand>();
         services.AddScoped<IUpdateNoteCommand, UpdateNoteCommand>();
         services.AddScoped<INoteRepository, NoteRepository>();

         return services;
      }
   }
}