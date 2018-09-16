using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteWorx.Infrastructure.Data.Commands
{
   public interface IDeleteNotesCommand
   {
      Task<bool> DeleteNotes(IReadOnlyList<long> noteIds);
   }
}