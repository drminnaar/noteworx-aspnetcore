using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Infrastructure.Data.Models.Configuration
{
   internal sealed class IdentityRoleConfiguration
      : IEntityTypeConfiguration<AppRole>
   {
      public void Configure(EntityTypeBuilder<AppRole> entity)
      {
         // map table

         entity.ToTable(
            name: DbSchema.Identity.Table.IdentityRole.TableName,
            schema: DbSchema.Identity.SchemaName);
      }
   }
}