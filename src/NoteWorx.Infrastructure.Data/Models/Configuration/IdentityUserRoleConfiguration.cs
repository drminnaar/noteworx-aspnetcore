using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Infrastructure.Data.Models.Configuration
{
   public sealed class IdentityUserRoleConfiguration
     : IEntityTypeConfiguration<IdentityUserRole<int>>
   {
      public void Configure(EntityTypeBuilder<IdentityUserRole<int>> entity)
      {
         // map table

         entity.ToTable(
            name: DbSchema.Identity.Table.IdentityUserRole.TableName,
            schema: DbSchema.Identity.SchemaName);
      }
   }
}