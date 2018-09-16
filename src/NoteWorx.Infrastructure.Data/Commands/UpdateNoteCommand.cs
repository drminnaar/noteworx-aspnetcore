using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using NoteWorx.Infrastructure.Data.Models;

namespace NoteWorx.Infrastructure.Data.Commands
{
   public sealed class UpdateNoteCommand : IUpdateNoteCommand
   {
      private readonly NoteWorxDbContext _context;
      private readonly IAddTagsCommand _addTagsCommand;

      public UpdateNoteCommand(NoteWorxDbContext context, IAddTagsCommand addTagsCommand)
      {
         _context = context
            ?? throw new ArgumentNullException(nameof(context));

         _addTagsCommand = addTagsCommand
            ?? throw new ArgumentNullException(nameof(addTagsCommand));
      }

      public async Task<bool> ExecuteAsync(Note note, IReadOnlyList<string> tags)
      {
         if (note == null)
            throw new ArgumentNullException(nameof(note));

         var noteFromDb = await FindNoteAsync(note.Id);
         noteFromDb.Description = note.Description;
         noteFromDb.Title = note.Title;
         noteFromDb.ModifiedAt = DateTimeOffset.Now;

         using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
         {
            if (tags != null && tags.Any())
            {
               // if (noteFromDb.NoteTags.Any())
               //    _context.NoteTags.RemoveRange(noteFromDb.NoteTags);

               noteFromDb.NoteTags = new List<NoteTag>();

               var addTagsResult = await _addTagsCommand.ExecuteAsync(tags);

               foreach (var tag in addTagsResult)
                  noteFromDb.NoteTags.Add(new NoteTag { TagId = tag.Id });
            }

            var result = await _context.SaveChangesAsync();

            if (result < 1)
               throw new InvalidOperationException("Note update failed.");

            transaction.Complete();
         }

         return true;
      }

      private async Task<Note> FindNoteAsync(long noteId)
      {
         var note = await _context
            .Notes
            .Where(n => n.Id == noteId)
            .Include(n => n.NoteTags)
            .ThenInclude(nt => nt.Tag)
            .FirstOrDefaultAsync();

         if (note == null)
         {
            throw new InvalidOperationException(
               $"A note having id '{noteId}' doesn't exist.");
         }

         return note;
      }
   }
}