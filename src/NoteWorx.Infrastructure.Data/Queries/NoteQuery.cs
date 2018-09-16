using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoteWorx.Infrastructure.Data.Models;

namespace NoteWorx.Infrastructure.Data.Queries
{
   public sealed class NoteQuery : INoteQuery
   {
      private readonly NoteWorxDbContext _db;
      private Expression<Func<Note, bool>> _filter = ExpressionBuilder.True<Note>();

      public NoteQuery(NoteWorxDbContext db)
      {
         _db = db ?? throw new ArgumentNullException(nameof(db));
      }

      // query builders

      public async Task<Note> SingleOrDefaultAsync(long noteId)
      {
         return await _db
            .Notes
            .Where(n => n.Id == noteId)
            .Include(n => n.NoteTags)
            .ThenInclude(nameof => nameof.Tag)
            .FirstOrDefaultAsync();
      }

      public IQueryable<Note> Build()
      {
         return _db
            .Notes
            .Include(note => note.NoteTags)
            .ThenInclude(noteTag => noteTag.Tag)
            .Include(note => note.User)
            .Where(_filter)
            .OrderByDescending(note => note.ModifiedAt);
      }

      // filters

      public INoteQuery WhereSearchTerm(string searchTerm)
      {
         if (string.IsNullOrWhiteSpace(searchTerm))
         {
            var message = $"Specified '{nameof(searchTerm)}' may not be null,"
               + " empty, or whitespace.";

            throw new ArgumentException(message, nameof(searchTerm));
         }

         return WhereSearchTermOrDefault(searchTerm);
      }

      public INoteQuery WhereSearchTermOrDefault(string searchTerm)
      {
         if (string.IsNullOrWhiteSpace(searchTerm))
            return this;

         var normalizedSearchTerm = searchTerm.Trim().ToLower();

         _filter = _filter.And(n =>
            n.Title.ToLower().Contains(normalizedSearchTerm)
            || n.Description.ToLower().Contains(searchTerm));

         return this;
      }

      public INoteQuery WhereUsername(string username)
      {
         if (string.IsNullOrWhiteSpace(username))
         {
            var message = $"Specified '{nameof(username)}' may not be null,"
               + " empty, or whitespace.";

            throw new ArgumentException(message, nameof(username));
         }

         return WhereUsernameOrDefault(username);
      }

      public INoteQuery WhereUsernameOrDefault(string username)
      {
         if (string.IsNullOrWhiteSpace(username))
            return this;

         var normalizedUsername = username.Trim().ToUpper();

         _filter = _filter.And(note => note.User.NormalizedUserName == normalizedUsername);

         return this;
      }

      public INoteQuery WhereTag(string tag)
      {
         if (string.IsNullOrWhiteSpace(tag))
         {
            var message = $"Specified '{nameof(tag)}' may not be null,"
               + " empty, or whitespace.";

            throw new ArgumentException(message, nameof(tag));
         }

         return WhereTagOrDefault(tag);
      }

      public INoteQuery WhereTagOrDefault(string tag)
      {
         if (string.IsNullOrWhiteSpace(tag))
            return this;

         var normalizedTag = tag.Trim().ToLower();

         _filter = _filter.And(n => n.NoteTags.Select(
            nt => nt.Tag.Value).Contains(normalizedTag));

         return this;
      }
   }
}