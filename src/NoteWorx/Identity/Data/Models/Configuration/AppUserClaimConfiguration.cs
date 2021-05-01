using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Identity.Data.Models.Configuration
{
    using static Identity.Data.Schema.SchemaInfo;
    using static Identity.Data.Schema.SchemaInfo.AppUserClaimTable;

    internal sealed class AppUserClaimConfiguration : IEntityTypeConfiguration<AppUserClaim>
    {
        public void Configure(EntityTypeBuilder<AppUserClaim> entity)
        {
            // configure table
            entity.ToTable(TableName, SchemaName);

            // configure primary key
            entity.HasKey(e => e.Id).HasName(Key.PrimaryKey);

            // configure properties
            entity.Property(e => e.ClaimType).HasColumnName(Column.ClaimType);
            entity.Property(e => e.ClaimValue).HasColumnName(Column.ClaimValue);
            entity.Property(e => e.Id).HasColumnName(Column.Id);
            entity.Property(e => e.UserId).HasColumnName(Column.UserId);

            // configure indexes
            entity.HasIndex(e => e.UserId).HasDatabaseName(Index.UserId);

            // configure relationships
            entity.HasOne(e => e.User).WithMany(e => e.Claims).HasForeignKey(e => e.UserId).HasConstraintName(Key.UserIdForeignKey);
        }
    }
}
