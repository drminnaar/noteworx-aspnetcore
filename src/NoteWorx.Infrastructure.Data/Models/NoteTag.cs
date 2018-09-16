using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using NoteWorx.Infrastructure.Data.Models;

public sealed class NoteTag
{
   public long NoteId { get; set; }
   public Note Note { get; set; }
   public long TagId { get; set; }
   public Tag Tag { get; set; }

   internal static IList<NoteTag> AsEmptyList => new List<NoteTag>();
}