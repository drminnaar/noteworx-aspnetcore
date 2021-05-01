using System.ComponentModel.DataAnnotations;

namespace NoteWorx.Web.ViewModels.Notes
{
    public sealed class AddNoteViewModel
    {
        [Required(ErrorMessage = "A title is required")]
        [MaxLength(200, ErrorMessage = "A title may not exceed {0} characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "A description is required")]
        [MaxLength(500, ErrorMessage = "A description may not exceed {0} characters")]
        public string Description { get; set; } = string.Empty;

        public string Tags { get; set; } = string.Empty;
    }
}
