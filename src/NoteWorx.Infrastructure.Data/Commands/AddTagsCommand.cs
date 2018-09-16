using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NoteWorx.Infrastructure.Data.Models;

namespace NoteWorx.Infrastructure.Data.Commands
{
   public sealed class AddTagsCommand : IAddTagsCommand
   {
      private readonly NoteWorxDbContext _db;

      public AddTagsCommand(NoteWorxDbContext db)
      {
         _db = db ?? throw new ArgumentNullException(nameof(db));
      }

      public async Task<IReadOnlyList<Tag>> ExecuteAsync(IReadOnlyList<string> tags)
      {
         if (tags == null || !tags.Any() || !tags.All(tag => tag != null))
         {
            var message = "Add tags failed. The specified collection of tags"
               + "may not be null, empty, or contain null tags";

            throw new ArgumentException(message, nameof(tags));
         }

         tags = tags.Select(t => t.Trim().ToLower()).ToList();

         var duplicateTags = await _db
            .Tags
            .Where(tag => tags.Contains(tag.Value.ToLower()))
            .ToListAsync();

         var duplicateTagValues = duplicateTags
            .Select(tag => tag.Value)
            .ToList();

         var uniqueTags = tags
            .Where(tag => !duplicateTagValues.Contains(tag))
            .Select(tag => new Tag { Value = tag })
            .ToList();

         if (uniqueTags.Any())
         {
            _db.Tags.AddRange(uniqueTags);

            var result = await _db.SaveChangesAsync();

            if (result < 1)
            {
               throw new InvalidOperationException("Invalid number of tags saved");
            }
         }

         return uniqueTags
            .Concat(duplicateTags)
            .ToList();
      }
   }
}