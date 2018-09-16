using System;
using Microsoft.AspNetCore.Mvc;

namespace NoteWorx.Web.Controllers
{
   public sealed class ErrorController : Controller
   {
      internal static readonly string Name =
         nameof(ErrorController).Replace("Controller", "");

      [Route("error/404")]
      public IActionResult Error404()
      {
         return View();
      }

      [Route("error/{code:int}")]
      public IActionResult Error(int code)
      {
         // handle different codes or just return the default error view
         return View();
      }

      public IActionResult Index()
      {
         return View();
      }
   }
}