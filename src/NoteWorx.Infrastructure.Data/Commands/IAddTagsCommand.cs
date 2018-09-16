using System.Collections.Generic;
using System.Threading.Tasks;
using NoteWorx.Infrastructure.Data.Models;

namespace NoteWorx.Infrastructure.Data.Commands
{
   public interface IAddTagsCommand
   {
      Task<IReadOnlyList<Tag>> ExecuteAsync(IReadOnlyList<string> tags);
   }
}