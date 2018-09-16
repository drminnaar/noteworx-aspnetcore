using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoteWorx.Infrastructure.Data.Models;
using NoteWorx.Infrastructure.Data.Models.Configuration;

namespace NoteWorx.Infrastructure.Data
{
   public sealed class NoteWorxDbContext
       : IdentityDbContext<AppUser, AppRole, int>
   {
      public NoteWorxDbContext(DbContextOptions<NoteWorxDbContext> options)
          : base(options)
      {
      }

      public DbSet<Note> Notes { get; set; }

      public DbSet<NoteTag> NoteTags { get; set; }

      public DbSet<Tag> Tags { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         base.OnModelCreating(modelBuilder);

         // configure identity schema entity configuration
         modelBuilder.ApplyConfiguration(new AppUserConfiguration());
         modelBuilder.ApplyConfiguration(new IdentityRoleConfiguration());
         modelBuilder.ApplyConfiguration(new IdentityRoleClaimConfiguration());
         modelBuilder.ApplyConfiguration(new IdentityUserClaimConfiguration());
         modelBuilder.ApplyConfiguration(new IdentityUserLoginConfiguration());
         modelBuilder.ApplyConfiguration(new IdentityUserRoleConfiguration());
         modelBuilder.ApplyConfiguration(new IdentityUserTokenConfiguration());

         // configure notes schema entity configuration
         modelBuilder.ApplyConfiguration(new NoteConfiguration());
         modelBuilder.ApplyConfiguration(new TagConfiguration());
         modelBuilder.ApplyConfiguration(new NoteTagConfiguration());
      }
   }
}