using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Identity.Data.Models.Configuration
{
    using static Identity.Data.Schema.SchemaInfo;
    using static Identity.Data.Schema.SchemaInfo.AppRoleTable;

    internal sealed class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> entity)
        {
            // configure table
            entity.ToTable(TableName, SchemaName);

            // configure primary key
            entity.HasKey(e => e.Id).HasName(Key.PrimaryKey);

            // configure properties
            entity.Property(e => e.ConcurrencyStamp).HasColumnName(Column.ConcurrencyStamp);
            entity.Property(e => e.Id).HasColumnName(Column.Id);
            entity.Property(e => e.Name).HasColumnName(Column.Name);
            entity.Property(e => e.NormalizedName).HasColumnName(Column.NormalizedName);

            // configure indexes
            entity.HasIndex(e => e.NormalizedName).HasDatabaseName(Index.NormalizedName).IsUnique();

            // configure relationships
            entity.HasMany(e => e.UserRoles).WithOne(e => e.Role).HasForeignKey(e => e.RoleId).HasConstraintName(Key.RoleIdForeignKey);
        }
    }
}
