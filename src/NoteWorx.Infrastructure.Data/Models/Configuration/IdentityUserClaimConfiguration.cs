using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Infrastructure.Data.Models.Configuration
{
   public sealed class IdentityUserClaimConfiguration
      : IEntityTypeConfiguration<IdentityUserClaim<int>>
   {
      public void Configure(EntityTypeBuilder<IdentityUserClaim<int>> entity)
      {
         // map table

         entity.ToTable(
            name: DbSchema.Identity.Table.IdentityUserClaim.TableName,
            schema: DbSchema.Identity.SchemaName);
      }
   }
}