using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Infrastructure.Data.Models.Configuration
{
   internal sealed class TagConfiguration : IEntityTypeConfiguration<Tag>
   {
      public void Configure(EntityTypeBuilder<Tag> entity)
      {
         // map table

         entity.ToTable(
            name: DbSchema.Notes.Table.Tag.TableName,
            schema: DbSchema.Notes.SchemaName);

         // map primary key

         entity
            .HasKey(e => e.Id)
            .HasName("pk_notes_tag_id");

         // map columns

         entity
            .Property(e => e.Id)
            .HasColumnName(DbSchema.Notes.Table.Tag.Column.Id);

         entity
            .Property(e => e.Value)
            .HasColumnName(DbSchema.Notes.Table.Tag.Column.Value);

         // map relationships

         entity
            .HasMany(e => e.NoteTags)
            .WithOne(e => e.Tag);
      }
   }
}