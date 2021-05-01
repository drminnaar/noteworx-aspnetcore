using System;
using System.Collections.Generic;
using System.Linq;
using NoteWorx.Identity.Data.Models;

namespace NoteWorx.Notes.Data.Models
{
    public class Note
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
        public string Tags { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public AppUser User { get; set; } = null!;

        internal static ICollection<Note> EmptyCollection => Enumerable.Empty<Note>().ToList();
    }
}
