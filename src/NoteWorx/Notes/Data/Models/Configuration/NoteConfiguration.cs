using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Notes.Data.Models.Configuration
{
    using static NoteWorx.Notes.Data.Schema.SchemaInfo;
    using static NoteWorx.Notes.Data.Schema.SchemaInfo.NoteTable;

    internal sealed class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> entity)
        {
            // map table
            entity.ToTable(name: TableName, schema: SchemaName);

            // map primary key
            entity.HasKey(e => e.Id).HasName(Key.PrimaryKey);

            // map columns
            entity.Property(e => e.CreatedAt).HasColumnName(Column.CreatedAt);
            entity.Property(e => e.Description).HasColumnName(Column.Description);
            entity.Property(e => e.Id).HasColumnName(Column.Id);
            entity.Property(e => e.ModifiedAt).HasColumnName(Column.ModifiedAt);
            entity.Property(e => e.Tags).HasColumnName(Column.Tags);
            entity.Property(e => e.Title).HasColumnName(Column.Title);
            entity.Property(e => e.UserId).HasColumnName(Column.UserId);

            // map relationships
            entity.HasOne(e => e.User!).WithMany(e => e.Notes);
        }
    }
}
