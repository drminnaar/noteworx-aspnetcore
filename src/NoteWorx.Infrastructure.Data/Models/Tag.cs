using System.Collections.Generic;

namespace NoteWorx.Infrastructure.Data.Models
{
   public sealed class Tag
   {
      public long Id { get; set; }
      public string Value { get; set; }
      public ICollection<NoteTag> NoteTags { get; set; } = NoteTag.AsEmptyList;

      internal static List<Tag> AsEmptyList => new List<Tag>();
   }
}