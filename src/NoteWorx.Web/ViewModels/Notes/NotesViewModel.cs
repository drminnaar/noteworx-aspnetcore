using System.Collections.Generic;
using NoteWorx.Web.Models.Notes;

namespace NoteWorx.Web.ViewModels.Notes
{
    public sealed class NotesViewModel
    {
        public IPagedList<NoteModel> Notes { get; set; } = PagedList<NoteModel>.Empty;

        public string Search { get; set; } = string.Empty;
    }
}
