using System;
using System.Collections.Generic;

namespace NoteWorx.Infrastructure.Data.Models
{
   public sealed class Note
   {
      public long Id { get; set; }
      public string Title { get; set; }
      public string Description { get; set; }
      public DateTimeOffset CreatedAt { get; set; }
      public DateTimeOffset ModifiedAt { get; set; }
      public int UserId { get; set; }
      public AppUser User { get; set; }
      public ICollection<NoteTag> NoteTags { get; set; } = NoteTag.AsEmptyList;

      internal static List<Note> AsEmptyList => new List<Note>();
   }
}