using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoteWorx.Notes.Data.Models;

namespace NoteWorx.Notes.Data
{
    public sealed class NoteDao
    {
        private readonly NoteWorxDbContext _context;

        public NoteDao(NoteWorxDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> DeleteNotes(IReadOnlyList<long> noteIds)
        {
            if (noteIds?.Any() == false)
                throw new ArgumentNullException(nameof(noteIds));

            var notes = await _context
                .Notes
                .Where(n => noteIds!.Contains(n.Id))
                .ToListAsync();

            if (notes?.Any() == false)
                return false;

            _context.Notes.RemoveRange(notes);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Note?> GetNoteById(long noteId)
        {
            return await _context
                .Notes
                .TagWith(nameof(GetNoteById))
                .AsNoTracking()
                .FirstOrDefaultAsync(note => note.Id == noteId);
        }

        public async Task<IPagedList<Note>> GetNotes(NoteQueryOptions options)
        {
            var filter = new NoteQueryBuilder()
                .WhereTagEquals(options.Tag)
                .WhereTermLike(options.Term)
                .WhereUsernameEquals(options.Username)
                .Filter;

            return await _context
                .Notes
                .TagWith(nameof(GetNotes))
                .AsNoTracking()
                .Where(filter)
                .OrderBy(options.Order, new NoteOrderBuilder())
                .ToPagedListAsync(options.PageNumber, options.PageSize);
        }

        public Task<bool> SaveNote(Note note)
        {
            if (note == null)
                throw new ArgumentNullException(nameof(note));

            return SaveNote();

            async Task<bool> SaveNote()
            {
                var noteFromDb = await _context
                    .Notes
                    .TagWith(nameof(SaveNote))
                    .FirstOrDefaultAsync(n => n.Id == note.Id);

                if (noteFromDb is null)
                {
                    note.CreatedAt = DateTimeOffset.Now;
                    note.ModifiedAt = DateTimeOffset.Now;
                    _context.Notes.Add(note);
                    return await _context.SaveChangesAsync() > 0;
                }
                else
                {
                    noteFromDb.Description = note.Description;
                    noteFromDb.Title = note.Title;
                    noteFromDb.Tags = note.Tags;
                    noteFromDb.ModifiedAt = DateTimeOffset.Now;
                    return await _context.SaveChangesAsync() > 0;
                }
            }
        }
    }
}
