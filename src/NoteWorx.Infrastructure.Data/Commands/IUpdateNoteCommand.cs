using System.Collections.Generic;
using System.Threading.Tasks;
using NoteWorx.Infrastructure.Data.Models;

namespace NoteWorx.Infrastructure.Data.Commands
{
   public interface IUpdateNoteCommand
   {
      Task<bool> ExecuteAsync(Note note, IReadOnlyList<string> tags);
   }
}