using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NoteWorx.Infrastructure.Data.Models.Configuration
{
   internal sealed class NoteConfiguration : IEntityTypeConfiguration<Note>
   {
      public void Configure(EntityTypeBuilder<Note> entity)
      {
         // map table

         entity.ToTable(
            name: DbSchema.Notes.Table.Note.TableName,
            schema: DbSchema.Notes.SchemaName);

         // map primary key

         entity
            .HasKey(e => e.Id)
            .HasName("pk_notes_note_id");

         // map columns

         entity
            .Property(e => e.CreatedAt)
            .HasColumnName(DbSchema.Notes.Table.Note.Column.CreatedAt);

         entity
            .Property(e => e.Description)
            .HasColumnName(DbSchema.Notes.Table.Note.Column.Description);

         entity
            .Property(e => e.Id)
            .HasColumnName(DbSchema.Notes.Table.Note.Column.Id);

         entity
            .Property(e => e.ModifiedAt)
            .HasColumnName(DbSchema.Notes.Table.Note.Column.ModifiedAt);

         entity
            .Property(e => e.Title)
            .HasColumnName(DbSchema.Notes.Table.Note.Column.Title);

         entity
            .Property(e => e.UserId)
            .HasColumnName(DbSchema.Notes.Table.Note.Column.UserId);

         // map relationships

         entity
            .HasOne(e => e.User)
            .WithMany(e => e.Notes);

         entity
            .HasMany(e => e.NoteTags)
            .WithOne(e => e.Note);
      }
   }
}