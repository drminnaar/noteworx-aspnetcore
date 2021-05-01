using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Identity.Data.Models.Configuration
{
    using static Identity.Data.Schema.SchemaInfo;
    using static Identity.Data.Schema.SchemaInfo.RefreshTokenTable;

    public sealed class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> entity)
        {
            // configure table
            entity.ToTable(TableName, SchemaName);

            // configure primary key
            entity.HasKey(e => e.Id).HasName(Key.PrimaryKey);

            // configure properties
            entity.Property(e => e.ExpiresAt).HasColumnName(Column.ExpiresAt);
            entity.Property(e => e.RevokedAt).HasColumnName(Column.RevokedAt);
            entity.Property(e => e.Value).HasColumnName(Column.Value);

            // configure indexes
            entity.HasIndex(e => e.UserId).HasDatabaseName(Index.UserId);

            // configure relationships
            entity.HasOne(e => e.User).WithMany(e => e.RefreshTokens).HasForeignKey(e => e.UserId).HasConstraintName(Key.UserIdForeignKey);
        }
    }
}
