using System.Collections.Generic;
using System.Linq;
using NoteWorx.Web.Models.Notes;

namespace NoteWorx.Web.ViewModels.Notes
{
   public sealed class NotesViewModel
   {
      public IPagedList<NoteModel> Notes { get; set; }

      public string Search { get; set; }
   }
}