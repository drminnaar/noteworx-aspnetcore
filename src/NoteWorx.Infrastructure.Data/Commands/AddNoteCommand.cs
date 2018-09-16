using System;
using System.Threading.Tasks;
using NoteWorx.Infrastructure.Data.Models;

namespace NoteWorx.Infrastructure.Data.Commands
{
   public sealed class AddNoteCommand : IAddNoteCommand
   {
      private readonly NoteWorxDbContext _context;

      public AddNoteCommand(NoteWorxDbContext context)
      {
         _context = context
            ?? throw new System.ArgumentNullException(nameof(context));
      }

      public async Task<bool> ExecuteAsync(Note note)
      {
         if (note == null)
            throw new ArgumentNullException(nameof(note));

         _context.Notes.Add(note);

         var result = await _context.SaveChangesAsync();

         if (result < 1)
         {
            throw new InvalidOperationException("Note was not saved successfully");
         }

         return result > 0;
      }
   }
}