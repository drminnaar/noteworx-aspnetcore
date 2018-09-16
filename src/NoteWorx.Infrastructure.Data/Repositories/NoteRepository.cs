using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NoteWorx.Infrastructure.Data.Commands;
using NoteWorx.Infrastructure.Data.Models;
using NoteWorx.Infrastructure.Data.Queries;

namespace NoteWorx.Infrastructure.Data.Repositories
{
   public sealed class NoteRepository : INoteRepository
   {
      private readonly INoteQuery _noteQuery;
      private readonly IAddNoteCommand _addNoteCommand;
      private readonly IAddTagsCommand _addTagsCommand;
      private readonly IDeleteNotesCommand _deleteNotesCommand;
      private readonly UserManager<AppUser> _userManager;
      private readonly IUpdateNoteCommand _updateNoteCommand;

      public NoteRepository(
         INoteQuery noteQuery,
         IAddNoteCommand addNoteCommand,
         IAddTagsCommand addTagsCommand,
         IDeleteNotesCommand deleteNotesCommand,
         IUpdateNoteCommand updateNoteCommand,
         UserManager<AppUser> userManager)
      {
         _noteQuery = noteQuery
            ?? throw new ArgumentNullException(nameof(noteQuery));

         _addNoteCommand = addNoteCommand
            ?? throw new ArgumentNullException(nameof(addNoteCommand));

         _addTagsCommand = addTagsCommand
            ?? throw new ArgumentNullException(nameof(addTagsCommand));

         _deleteNotesCommand = deleteNotesCommand
            ?? throw new ArgumentNullException(nameof(deleteNotesCommand));

         _updateNoteCommand = updateNoteCommand
            ?? throw new ArgumentNullException(nameof(_updateNoteCommand));

         _userManager = userManager
            ?? throw new ArgumentNullException(nameof(userManager));
      }

      public async Task<bool> AddNote(
         string username,
         Note note,
         IReadOnlyList<string> tags = null)
      {
         if (string.IsNullOrWhiteSpace(username))
         {
            var message = "Cannot add note."
               + $" The specified username '{username}'"
               + " may not be null, empty. or whitespace";

            throw new ArgumentException(message, nameof(username));
         }

         var user = await _userManager.FindByNameAsync(username);

         if (user == null)
         {
            var message = "Cannot add note."
               + $" A user having username '{username}' does not exist.";

            throw new InvalidOperationException(message);
         }

         note.UserId = user.Id;

         if (tags == null || !tags.Any())
         {
            return await _addNoteCommand.ExecuteAsync(note);
         }

         using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
         {
            var addTagsResult = await _addTagsCommand.ExecuteAsync(tags);

            foreach (var tag in addTagsResult)
            {
               note.NoteTags.Add(new NoteTag { TagId = tag.Id });
            }

            var addNoteResult = await _addNoteCommand.ExecuteAsync(note);

            if (!addNoteResult)
               return false;

            scope.Complete();
            return true;
         }
      }

      public async Task<bool> DeleteNotes(IReadOnlyList<long> noteIds)
      {
         return await _deleteNotesCommand.DeleteNotes(noteIds);
      }

      public async Task<Note> FindNoteById(long noteId)
      {
         return await _noteQuery.SingleOrDefaultAsync(noteId);
      }

      public async Task<IPagedList<Note>> GetNotesAsync(NoteQueryParams noteQueryParams)
      {
         if (noteQueryParams == null)
            throw new ArgumentNullException(nameof(noteQueryParams));

         var user = await _userManager.FindByNameAsync(noteQueryParams.Username);

         if (user == null)
         {
            throw new InvalidOperationException(
               $"The user '{noteQueryParams.Username}' does not exist.");
         }

         var notes = await _noteQuery
            .WhereUsernameOrDefault(noteQueryParams.Username)
            .WhereTagOrDefault(noteQueryParams.Tag)
            .WhereSearchTermOrDefault(noteQueryParams.Search)
            .Build()
            .ToPagedListAsync(
               noteQueryParams.PageNumber,
               noteQueryParams.PageSize);

         return notes;
      }

      public async Task<bool> Update(Note note, IReadOnlyList<string> tags)
      {
         return await _updateNoteCommand.ExecuteAsync(note, tags);
      }
   }
}