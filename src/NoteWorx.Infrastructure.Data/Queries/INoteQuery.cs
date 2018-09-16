using System.Linq;
using System.Threading.Tasks;
using NoteWorx.Infrastructure.Data.Models;

namespace NoteWorx.Infrastructure.Data.Queries
{
   public interface INoteQuery
   {
      IQueryable<Note> Build();

      Task<Note> SingleOrDefaultAsync(long noteId);

      INoteQuery WhereSearchTerm(string searchTerm);

      INoteQuery WhereSearchTermOrDefault(string searchTerm);

      INoteQuery WhereTag(string tag);

      INoteQuery WhereTagOrDefault(string tag);

      INoteQuery WhereUsername(string username);

      INoteQuery WhereUsernameOrDefault(string username);
   }
}