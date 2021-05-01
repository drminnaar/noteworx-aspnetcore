using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NoteWorx.Identity.Data.Models;
using NoteWorx.Notes.Data.Models;

namespace NoteWorx.Notes.Data
{
    public sealed class NoteWorxDbContext : IdentityDbContext<
        AppUser,
        AppRole,
        Guid,
        AppUserClaim,
        AppUserRole,
        AppUserLogin,
        AppRoleClaim,
        AppUserToken>
    {
        public NoteWorxDbContext(DbContextOptions<NoteWorxDbContext> options)
            : base(options)
        {
        }

        public DbSet<Note> Notes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
