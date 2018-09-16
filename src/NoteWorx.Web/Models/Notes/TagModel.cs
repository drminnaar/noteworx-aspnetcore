using System;
using System.Collections.Generic;
using NoteWorx.Infrastructure.Data.Models;

namespace NoteWorx.Web.Models.Notes
{
   public sealed class TagModel
   {
      public TagModel()
      {
      }

      internal TagModel(Tag tag)
      {
         if (tag == null)
            throw new ArgumentNullException(nameof(tag));

         Id = tag.Id;
         Value = tag.Value;
      }

      public long Id { get; set; }
      public string Value { get; set; }

      public static explicit operator TagModel(Tag tag)
      {
         if (tag == null)
            throw new ArgumentNullException(nameof(tag));

         return new TagModel(tag);
      }

      internal static List<TagModel> AsEmptyList => new List<TagModel>();
   }
}