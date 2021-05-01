using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Identity.Data.Models.Configuration
{
    using static Identity.Data.Schema.SchemaInfo;
    using static Identity.Data.Schema.SchemaInfo.AppUserTokenTable;

    internal sealed class AppUserTokenConfiguration : IEntityTypeConfiguration<AppUserToken>
    {
        public void Configure(EntityTypeBuilder<AppUserToken> entity)
        {
            // configure table
            entity.ToTable(TableName, SchemaName);

            // configure primary key
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name }).HasName(Key.PrimaryKey);

            // configure properties
            entity.Property(e => e.LoginProvider).HasColumnName(Column.LoginProvider);
            entity.Property(e => e.Name).HasColumnName(Column.Name);
            entity.Property(e => e.UserId).HasColumnName(Column.UserId);
            entity.Property(e => e.Value).HasColumnName(Column.Value);

            // configure indexes
            entity.HasIndex(e => e.UserId).HasDatabaseName(Index.UserId);

            // configure relationships
            entity.HasOne(e => e.User).WithMany(e => e.Tokens).HasForeignKey(e => e.UserId).HasConstraintName(Key.UserIdForeignKey);
        }
    }
}
