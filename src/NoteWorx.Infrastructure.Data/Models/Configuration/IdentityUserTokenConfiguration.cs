using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Infrastructure.Data.Models.Configuration
{
   public sealed class IdentityUserTokenConfiguration
     : IEntityTypeConfiguration<IdentityUserToken<int>>
   {
      public void Configure(EntityTypeBuilder<IdentityUserToken<int>> entity)
      {
         // map table

         entity.ToTable(
            name: DbSchema.Identity.Table.IdentityUserToken.TableName,
            schema: DbSchema.Identity.SchemaName);
      }
   }
}