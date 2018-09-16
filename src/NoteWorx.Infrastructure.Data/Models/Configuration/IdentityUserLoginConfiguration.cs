using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Infrastructure.Data.Models.Configuration
{
   public sealed class IdentityUserLoginConfiguration
      : IEntityTypeConfiguration<IdentityUserLogin<int>>
   {
      public void Configure(EntityTypeBuilder<IdentityUserLogin<int>> entity)
      {
         entity.ToTable(
            name: DbSchema.Identity.Table.IdentityUserLogin.TableName,
            schema: DbSchema.Identity.SchemaName);
      }
   }
}