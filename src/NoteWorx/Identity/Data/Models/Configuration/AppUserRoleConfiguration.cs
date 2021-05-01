using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Identity.Data.Models.Configuration
{
    using static Identity.Data.Schema.SchemaInfo;
    using static Identity.Data.Schema.SchemaInfo.AppUserRoleTable;

    internal sealed class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> entity)
        {
            // configure table
            entity.ToTable(TableName, SchemaName);

            // configure primary key
            entity.HasKey(e => new { e.UserId, e.RoleId }).HasName(Key.PrimaryKey);

            // configure properties
            entity.Property(e => e.RoleId).HasColumnName(Column.RoleId);
            entity.Property(e => e.UserId).HasColumnName(Column.UserId);

            // configure indexes
            entity.HasIndex(e=>e.RoleId).HasDatabaseName(Index.RoleId);
            entity.HasIndex(e=>e.UserId).HasDatabaseName(Index.UserId);

            // configure relationships
            entity.HasOne(e => e.Role).WithMany(e => e.UserRoles).HasForeignKey(e => e.RoleId).HasConstraintName(Key.RoleIdForeignKey);
            entity.HasOne(e => e.User).WithMany(e => e.UserRoles).HasForeignKey(e => e.UserId).HasConstraintName(Key.UserIdForeignKey);
        }
    }
}
