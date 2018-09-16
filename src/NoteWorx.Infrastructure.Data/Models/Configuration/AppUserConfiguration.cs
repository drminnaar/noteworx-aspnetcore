using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Infrastructure.Data.Models.Configuration
{
   public sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
   {
      public void Configure(EntityTypeBuilder<AppUser> entity)
      {
         // map table

         entity.ToTable(
            name: DbSchema.Identity.Table.AppUser.TableName,
            schema: DbSchema.Identity.SchemaName);

         // map relationships

         entity.HasMany(e => e.Notes).WithOne(e => e.User);
      }
   }
}