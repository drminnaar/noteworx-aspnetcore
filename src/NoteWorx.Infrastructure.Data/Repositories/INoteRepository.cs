using System.Collections.Generic;
using System.Threading.Tasks;
using NoteWorx.Infrastructure.Data.Models;

namespace NoteWorx.Infrastructure.Data.Repositories
{
   public interface INoteRepository
   {
      Task<bool> AddNote(string username, Note note, IReadOnlyList<string> tags = null);

      Task<bool> DeleteNotes(IReadOnlyList<long> noteIds);

      Task<Note> FindNoteById(long noteId);

      Task<IPagedList<Note>> GetNotesAsync(NoteQueryParams noteQueryParams);

      Task<bool> Update(Note note, IReadOnlyList<string> tags);
   }
}