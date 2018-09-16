using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace NoteWorx.Infrastructure.Data.Models
{
   public sealed class AppUser : IdentityUser<int>
   {
      public ICollection<Note> Notes { get; set; }

      internal static List<AppUser> AsEmptyList => new List<AppUser>();
   }
}