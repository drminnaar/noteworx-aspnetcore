using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoteWorx.Identity.Data.Models;
using NoteWorx.Notes.Data;
using NoteWorx.Notes.Data.Models;
using NoteWorx.Web.Models.Notes;
using NoteWorx.Web.ViewModels.Notes;

namespace NoteWorx.Web.Controllers
{
    [Authorize]
    public sealed class NotesController : Controller
    {
        internal static readonly string Name = nameof(NotesController).Replace("Controller", "");

        private readonly NoteDao _noteDao;
        private readonly UserManager<AppUser> _userManager;

        public NotesController(NoteDao noteDao, UserManager<AppUser> userManager)
        {
            _noteDao = noteDao ?? throw new ArgumentNullException(nameof(noteDao));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        [HttpGet]
        public IActionResult AddNote()
        {
            return View(new AddNoteViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNote(AddNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var user = await _userManager.FindByNameAsync(User.Identity?.Name);

            if (user is null)
                return Unauthorized();

            var tags = viewModel
               .Tags
               ?.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
               ?.Select(tag => tag.Trim().ToLowerInvariant())
               ?.ToList()
               ?? Enumerable.Empty<string>().ToList();

            var note = new Note
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                UserId = user.Id,
                Tags = string.Join(',', tags)
            };

            var success = await _noteDao.SaveNote(note);

            if (!success)
            {
                ModelState.AddModelError("", "Add note failed due to unexpected error");
                return View(viewModel);
            }

            return RedirectToAction(
               actionName: nameof(NotesController.Index),
               controllerName: NotesController.Name);
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteNotes(string[] noteIds)
        {
            if (noteIds != null && noteIds.Any())
            {
                var ids = noteIds
                   .Select(noteId => long.Parse(noteId))
                   .ToList();

                await _noteDao.DeleteNotes(ids);
            }

            var redirectUrl = Url.Link(
               "default",
               new
               {
                   Controller = NotesController.Name,
                   Action = nameof(NotesController.Index)
               });

            return Json(new { Url = redirectUrl });
        }

        [HttpGet]
        public async Task<IActionResult> EditNote(long noteId)
        {
            var note = await _noteDao.GetNoteById(noteId);

            if (note is null)
            {
                return NotFound($"A note having specified id '{noteId}' could not be found.");
            }

            return View(new EditNoteViewModel
            {
                Id = note.Id,
                Description = note.Description,
                Title = note.Title,
                Tags = note.Tags
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditNote(EditNoteViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            var user = await _userManager.FindByNameAsync(User.Identity?.Name);

            if (user is null)
                return Unauthorized();

            var tags = viewModel
               .Tags
               ?.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
               ?.Select(tag => tag.Trim().ToLowerInvariant())
               ?.ToList()
               ?? Enumerable.Empty<string>().ToList();

            var note = new Note
            {
                Id = viewModel.Id,
                Description = viewModel.Description,
                Tags = string.Join(',', tags),
                Title = viewModel.Title,
                UserId = user.Id
            };

            var success = await _noteDao.SaveNote(note);

            if (!success)
            {
                ModelState.AddModelError("", "Edit note failed due to unexpected error");
                return View(viewModel);
            }

            return RedirectToAction(
               actionName: nameof(NotesController.Index),
               controllerName: NotesController.Name);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string tag = "", string search = "", int pageNumber = 1)
        {
            ViewBag.Search = search;
            ViewBag.Tag = tag;

            var notesFromDb = await _noteDao.GetNotes(new NoteQueryOptions
            {
                Order = "-modifiedat",
                PageNumber = pageNumber,
                PageSize = 5,
                Tag = tag,
                Term = search,
                Username = User.Identity?.Name ?? string.Empty
            });
            var noteModels = notesFromDb.Select(n => (NoteModel)n).ToList();
            var pagedNoteModels = new PagedList<NoteModel>(
                noteModels,
                notesFromDb.ItemCount,
                notesFromDb.PageNumber,
                notesFromDb.PageSize);

            return View(new NotesViewModel
            {
                Notes = pagedNoteModels,
                Search = string.Empty
            });
        }
    }
}
