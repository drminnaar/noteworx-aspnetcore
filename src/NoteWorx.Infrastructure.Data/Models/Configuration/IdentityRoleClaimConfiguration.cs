using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Infrastructure.Data.Models.Configuration
{
   public sealed class IdentityRoleClaimConfiguration
     : IEntityTypeConfiguration<IdentityRoleClaim<int>>
   {
      public void Configure(EntityTypeBuilder<IdentityRoleClaim<int>> entity)
      {
         // map table

         entity.ToTable(
            name: DbSchema.Identity.Table.IdentityRoleClaim.TableName,
            schema: DbSchema.Identity.SchemaName);
      }
   }
}