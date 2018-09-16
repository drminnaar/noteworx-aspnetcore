using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoteWorx.Infrastructure.Data.Models;

namespace NoteWorx.Web.Controllers
{
   public class HomeController : Controller
   {
      private readonly SignInManager<AppUser> _signInManager;

      internal static readonly string Name
         = nameof(HomeController).Replace("Controller", "");

      public HomeController(SignInManager<AppUser> signInManager)
      {
         _signInManager = signInManager
            ?? throw new ArgumentNullException(nameof(signInManager));
      }

      public IActionResult Index()
      {
         if (_signInManager.IsSignedIn(User))
         {
            return RedirectToAction(
               actionName: nameof(NotesController.Index),
               controllerName: NotesController.Name);
         }

         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return RedirectToAction(
            actionName: nameof(ErrorController.Index),
            controllerName: ErrorController.Name);
      }
   }
}
