using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using NoteWorx.Notes.Data;

namespace NoteWorx.Notes.Database.Postgres
{
    public sealed class PostgresDesignTimeDbContextFactory : IDesignTimeDbContextFactory<NoteWorxDbContext>
    {
        public NoteWorxDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("settings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<NoteWorxDbContext>();
            optionsBuilder.UseNpgsql(
                configuration.GetConnectionString("default"),
                options => options.MigrationsAssembly(GetType().Assembly.FullName));

            return new NoteWorxDbContext(optionsBuilder.Options);
        }
    }
}
