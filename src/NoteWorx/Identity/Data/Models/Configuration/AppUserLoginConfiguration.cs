using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Identity.Data.Models.Configuration
{
    using static Identity.Data.Schema.SchemaInfo;
    using static Identity.Data.Schema.SchemaInfo.AppUserLoginTable;

    internal sealed class AppUserLoginConfiguration : IEntityTypeConfiguration<AppUserLogin>
    {
        public void Configure(EntityTypeBuilder<AppUserLogin> entity)
        {
            // configure table
            entity.ToTable(TableName, SchemaName);

            // configure primary key
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey }).HasName(Key.PrimaryKey);

            // configure properties
            entity.Property(e => e.LoginProvider).HasColumnName(Column.LoginProvider);
            entity.Property(e => e.ProviderDisplayName).HasColumnName(Column.ProviderDisplayName);
            entity.Property(e => e.ProviderKey).HasColumnName(Column.ProviderKey);
            entity.Property(e => e.UserId).HasColumnName(Column.UserId);

            // configure indexes
            entity.HasIndex(e => e.UserId).HasDatabaseName(Index.UserId);

            // configure relationships
            entity.HasOne(e => e.User).WithMany(e => e.Logins).HasForeignKey(e => e.UserId).HasConstraintName(Key.UserIdForeignKey);
        }
    }
}
