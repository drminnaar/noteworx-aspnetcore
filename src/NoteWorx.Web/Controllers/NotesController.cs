using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NoteWorx.Infrastructure.Data.Models;
using NoteWorx.Infrastructure.Data.Repositories;
using NoteWorx.Web.Models.Notes;
using NoteWorx.Web.ViewModels.Notes;

namespace NoteWorx.Web.Controllers
{
   [Authorize]
   public sealed class NotesController : Controller
   {
      private readonly INoteRepository _noteRepository;
      public NotesController(INoteRepository noteRepository)
      {
         _noteRepository = noteRepository
            ?? throw new ArgumentNullException(nameof(noteRepository));
      }

      internal static readonly string Name =
         nameof(NotesController).Replace("Controller", "");

      [HttpGet]
      public async Task<IActionResult> Index(
         string tag = null, string search = null)
      {
         ViewBag.Search = search;
         ViewBag.Tag = tag;

         var noteQueryParams = new NoteQueryParams(User.Identity.Name);
         noteQueryParams.Tag = tag;
         noteQueryParams.Search = search;

         var notes = await _noteRepository.GetNotesAsync(noteQueryParams);

         var noteModels = notes.Select(n => (NoteModel)n).ToList();

         foreach (var noteModel in noteModels)
         {
            noteModel.Tags = notes
               .FirstOrDefault(n => n.Id == noteModel.Id)
               ?.NoteTags
               ?.Select(nt => (TagModel)nt.Tag)
               ?.ToList()
               ?? TagModel.AsEmptyList;
         }

         var pagedNoteModels = new PagedList<NoteModel>(
            noteModels, notes.ItemCount, notes.PageNumber, notes.PageSize);

         var notesViewModel = new NotesViewModel
         {
            Notes = pagedNoteModels,
            Search = string.Empty
         };

         return View(notesViewModel);
      }

      [HttpGet]
      public IActionResult AddNote()
      {
         return View(new AddNoteViewModel());
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> AddNote(AddNoteViewModel addNoteViewModel)
      {
         if (addNoteViewModel == null)
            throw new ArgumentNullException(nameof(addNoteViewModel));

         if (!ModelState.IsValid)
            return View(addNoteViewModel);

         var tags = addNoteViewModel
            .Tags
            ?.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
            ?.Select(tag => tag.Trim().ToLower())
            ?.ToList();

         var note = new Note
         {
            Title = addNoteViewModel.Title,
            Description = addNoteViewModel.Description,
            CreatedAt = DateTimeOffset.Now,
            ModifiedAt = DateTimeOffset.Now
         };

         var success = await _noteRepository.AddNote(User.Identity.Name, note, tags);

         if (!success)
         {
            ModelState.AddModelError("", "Add note failed due to unexpected error");
            return View(addNoteViewModel);
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

            await _noteRepository.DeleteNotes(ids);
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
         var note = await _noteRepository.FindNoteById(noteId);

         if (note == null)
         {
            throw new InvalidOperationException(
               $"A note having specified id '{noteId}' could not be found.");
         }

         var editNoteViewModel = new EditNoteViewModel
         {
            Id = note.Id,
            Description = note.Description,
            Title = note.Title,
            Tags = string.Join(", ", note.NoteTags.Select(nt => nt.Tag.Value))
         };

         return View(editNoteViewModel);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> EditNote(EditNoteViewModel editNoteViewModel)
      {
         if (editNoteViewModel == null)
            throw new ArgumentNullException(nameof(editNoteViewModel));

         if (!ModelState.IsValid)
            return View(editNoteViewModel);

         var note = new Note
         {
            Id = editNoteViewModel.Id,
            Description = editNoteViewModel.Description,
            Title = editNoteViewModel.Title
         };

         var tags = editNoteViewModel
            .Tags
            ?.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
            ?.Select(tag => tag.Trim().ToLower())
            ?.ToList();

         await _noteRepository.Update(note, tags);

         return RedirectToAction(
            actionName: nameof(NotesController.Index),
            controllerName: NotesController.Name);
      }
   }
}