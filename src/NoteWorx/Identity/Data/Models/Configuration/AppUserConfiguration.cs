using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Identity.Data.Models.Configuration
{
    using static Identity.Data.Schema.SchemaInfo;
    using static Identity.Data.Schema.SchemaInfo.AppUserTable;

    internal sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> entity)
        {
            // configure table
            entity.ToTable(TableName, SchemaName);

            // configure primary key
            entity.HasKey(e => e.Id).HasName(Key.PrimaryKey);

            // configure properties
            entity.Property(e => e.Id).HasColumnName(Column.Id);
            entity.Property(e => e.AccessFailedCount).HasColumnName(Column.AccessFailedCount);
            entity.Property(e => e.ConcurrencyStamp).HasColumnName(Column.ConcurrencyStamp);
            entity.Property(e => e.Email).HasColumnName(Column.Email);
            entity.Property(e => e.EmailConfirmed).HasColumnName(Column.EmailConfirmed);
            entity.Property(e => e.LockoutEnabled).HasColumnName(Column.LockoutEnabled);
            entity.Property(e => e.LockoutEnd).HasColumnName(Column.LockoutEnd);
            entity.Property(e => e.NormalizedEmail).HasColumnName(Column.NormalizedEmail);
            entity.Property(e => e.NormalizedUserName).HasColumnName(Column.NormalizedUserName);
            entity.Property(e => e.PasswordHash).HasColumnName(Column.PasswordHash);
            entity.Property(e => e.PhoneNumber).HasColumnName(Column.PhoneNumber);
            entity.Property(e => e.PhoneNumberConfirmed).HasColumnName(Column.PhoneNumberConfirmed);
            entity.Property(e => e.SecurityStamp).HasColumnName(Column.SecurityStamp);
            entity.Property(e => e.TwoFactorEnabled).HasColumnName(Column.TwoFactorEnabled);
            entity.Property(e => e.UserName).HasColumnName(Column.UserName);

            // configure indexes
            entity.HasIndex(e => e.NormalizedUserName).HasDatabaseName(Index.NormalizedUserName).IsUnique();
            entity.HasIndex(e => e.NormalizedEmail).HasDatabaseName(Index.NormalizedEmail);

            // configure relationships
            entity.HasMany(e => e.Claims).WithOne().HasForeignKey(e => e.UserId).HasConstraintName(Key.ClaimIdForeignKey).IsRequired();
            entity.HasMany(e => e.Logins).WithOne().HasForeignKey(e => e.UserId).HasConstraintName(Key.LoginIdForeignKey).IsRequired();
            entity.HasMany(e => e.Tokens).WithOne().HasForeignKey(e => e.UserId).HasConstraintName(Key.TokenIdForeignKey).IsRequired();
            entity.HasMany(e => e.UserRoles).WithOne().HasForeignKey(e => e.UserId).HasConstraintName(Key.UserIdForeignKey).IsRequired();
        }
    }
}
