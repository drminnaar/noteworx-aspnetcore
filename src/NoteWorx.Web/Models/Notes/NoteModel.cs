using System;
using System.Collections.Generic;
using System.Linq;
using NoteWorx.Infrastructure.Data.Models;

namespace NoteWorx.Web.Models.Notes
{
   public sealed class NoteModel
   {
      public NoteModel()
      {
      }

      internal NoteModel(Note note)
      {
         if (note == null)
            throw new ArgumentNullException(nameof(note));

         Id = note.Id;
         Title = note.Title;
         Description = note.Description;
         CreatedAt = note.CreatedAt;
         ModifiedAt = note.ModifiedAt;
         UserId = note.UserId;
         Selected = false;

         // if (note.NoteTags != null && note.NoteTags.Any())
         // {
         //    var tags = note.NoteTags.Select(nt => nt.Tag).ToList();

         //    if (tags.Any())
         //       Tags = tags.Select(t => (TagModel)t).ToList();
         // }
      }

      public long Id { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public DateTimeOffset CreatedAt { get; set; }
      public DateTimeOffset ModifiedAt { get; set; }
      public int UserId { get; set; }
      public bool Selected { get; set; }
      public IReadOnlyList<TagModel> Tags { get; set; } = TagModel.AsEmptyList;

      public static explicit operator NoteModel(Note note)
      {
         if (note == null)
            throw new ArgumentNullException(nameof(note));

         return new NoteModel(note);
      }
   }
}