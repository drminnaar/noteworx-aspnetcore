using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NoteWorx.Infrastructure.Data.Commands
{
   public sealed class DeleteNotesCommand : IDeleteNotesCommand
   {
      private readonly NoteWorxDbContext _db;

      public DeleteNotesCommand(NoteWorxDbContext db)
      {
         _db = db ?? throw new ArgumentNullException(nameof(db));
      }

      public async Task<bool> DeleteNotes(IReadOnlyList<long> noteIds)
      {
         if (noteIds == null || !noteIds.Any())
            throw new ArgumentNullException(nameof(noteIds));

         var notes = await _db.Notes
            .Where(n => noteIds.Contains(n.Id))
            .ToListAsync();

         if (notes == null || !notes.Any())
         {
            throw new InvalidOperationException(
               "Invalid list of note ids specified");
         }

         _db.Notes.RemoveRange(notes);

         var result = await _db.SaveChangesAsync();

         return result > 0;
      }
   }
}