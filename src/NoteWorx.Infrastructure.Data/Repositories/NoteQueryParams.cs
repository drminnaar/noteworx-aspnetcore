using System;

namespace NoteWorx.Infrastructure.Data.Repositories
{
   public sealed class NoteQueryParams
   {
      public NoteQueryParams(string username)
      {
         if (username.IsNullOrWhiteSpace())
            throw new ArgumentNullException(nameof(username));

         Username = username;
      }

      public string Search { get; set; }

      public string Tag { get; set; }

      public string Username { get; private set; }

      public int PageNumber { get; set; } = 1;

      public int PageSize { get; set; } = 5;
   }
}