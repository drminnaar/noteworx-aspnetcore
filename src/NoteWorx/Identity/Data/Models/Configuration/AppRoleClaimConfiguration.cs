using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Identity.Data.Models.Configuration
{
    using static Identity.Data.Schema.SchemaInfo;
    using static Identity.Data.Schema.SchemaInfo.AppRoleClaimTable;

    internal sealed class AppRoleClaimConfiguration : IEntityTypeConfiguration<AppRoleClaim>
    {
        public void Configure(EntityTypeBuilder<AppRoleClaim> entity)
        {
            // configure table
            entity.ToTable(TableName, SchemaName);

            // configure primary key
            entity.HasKey(e => e.Id).HasName(Key.PrimaryKey);

            // configure properties
            entity.Property(e => e.ClaimType).HasColumnName(Column.ClaimType);
            entity.Property(e => e.ClaimValue).HasColumnName(Column.ClaimValue);
            entity.Property(e => e.Id).HasColumnName(Column.Id);
            entity.Property(e => e.RoleId).HasColumnName(Column.RoleId);

            // configure indexes
            entity.HasIndex(e => e.RoleId).HasDatabaseName(Index.RoleId);

            // configure relationships
            entity.HasOne(e => e.Role).WithMany(e => e.RoleClaims).HasForeignKey(e => e.RoleId).HasConstraintName(Key.RoleIdForeignKey);
        }
    }
}
