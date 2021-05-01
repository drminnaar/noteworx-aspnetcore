using System;
using System.Collections.Generic;
using System.Linq;
using NoteWorx.Notes.Data.Models;

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
            Tags = note
                ?.Tags
                ?.Split(",")
                ?.ToList()
                ?? Enumerable.Empty<string>().ToList();
        }

        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ModifiedAt { get; set; }
        public Guid UserId { get; set; }
        public bool Selected { get; set; }
        public IReadOnlyList<string> Tags { get; set; } = Enumerable.Empty<string>().ToList();

        public static explicit operator NoteModel(Note note)
        {
            if (note == null)
                throw new ArgumentNullException(nameof(note));

            return new NoteModel(note);
        }
    }
}
