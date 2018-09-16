using System.Threading.Tasks;
using NoteWorx.Infrastructure.Data.Models;

namespace NoteWorx.Infrastructure.Data.Commands
{
   public interface IAddNoteCommand
   {
      Task<bool> ExecuteAsync(Note note);
   }
}