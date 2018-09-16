using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Infrastructure.Data.Models.Configuration
{
   internal sealed class NoteTagConfiguration : IEntityTypeConfiguration<NoteTag>
   {
      public void Configure(EntityTypeBuilder<NoteTag> builder)
      {
         // map table

         builder.ToTable(
            name: DbSchema.Notes.Table.NoteTag.TableName,
            schema: DbSchema.Notes.SchemaName);

         // map key

         builder
            .HasKey(e => new { note_id = e.NoteId, tag_id = e.TagId })
            .HasName("pk_notes_notetag_noteid_tagid");

         // map columns

         builder
            .Property(e => e.NoteId)
            .HasColumnName(DbSchema.Notes.Table.NoteTag.Column.NoteId);

         builder
            .Property(e => e.TagId)
            .HasColumnName(DbSchema.Notes.Table.NoteTag.Column.TagId);

         // map relationships

         builder
            .HasOne(e => e.Note)
            .WithMany(e => e.NoteTags)
            .HasForeignKey(e => e.NoteId)
            .HasConstraintName("fk_notes_notetag_noteid");

         builder
            .HasOne(e => e.Tag)
            .WithMany(e => e.NoteTags)
            .HasForeignKey(e => e.TagId)
            .HasConstraintName("fk_notes_notetag_tagid");
      }
   }
}