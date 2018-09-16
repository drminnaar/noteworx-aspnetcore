using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoteWorx.Infrastructure.Data.Models;
using NoteWorx.Web.ViewModels.Account;

namespace NoteWorx.Web.Controllers
{
   public sealed class AccountController : Controller
   {
      private readonly UserManager<AppUser> _userManager;
      private readonly SignInManager<AppUser> _signInManager;

      internal static readonly string Name =
         nameof(AccountController).Replace("Controller", "");

      public AccountController(
         UserManager<AppUser> userManager,
         SignInManager<AppUser> signInManager)
      {
         _userManager = userManager
            ?? throw new ArgumentNullException(nameof(userManager));

         _signInManager = signInManager
            ?? throw new ArgumentNullException(nameof(signInManager));
      }

      [HttpGet]
      public IActionResult Login()
      {
         if (_signInManager.IsSignedIn(User))
         {
            return RedirectToAction(
               actionName: nameof(NotesController.Index),
               controllerName: NotesController.Name);
         }

         if (Request.Query.ContainsKey("Registered"))
         {
            ViewBag.Registered = true;
         }

         return View();
      }

      [HttpPost]
      public async Task<IActionResult> Login(
         LoginViewModel loginViewModel,
         string returnUrl = null)
      {
         ViewData["ReturnUrl"] = returnUrl;

         if (!ModelState.IsValid)
            return View(loginViewModel);

         var result = await _signInManager.PasswordSignInAsync(
            userName: loginViewModel.Email,
            password: loginViewModel.Password,
            isPersistent: false,
            lockoutOnFailure: false);

         if (result.Succeeded)
         {
            if (Url.IsLocalUrl(returnUrl))
            {
               return Redirect(returnUrl);
            }
            else
            {
               return RedirectToAction(
                  actionName: nameof(NotesController.Index),
                  controllerName: NotesController.Name);
            }
         }

         ModelState.AddModelError("", "Login attempt failed");

         return View(loginViewModel);
      }

      public async Task<IActionResult> Logout()
      {
         await _signInManager.SignOutAsync();

         return RedirectToAction(
            actionName: nameof(HomeController.Index),
            controllerName: HomeController.Name);
      }

      [HttpGet]
      public IActionResult Register()
      {
         if (_signInManager.IsSignedIn(User))
         {
            return RedirectToAction(
               actionName: nameof(NotesController.Index),
               controllerName: NotesController.Name);
         }

         return View();
      }

      [HttpPost]
      public async Task<IActionResult> Register(RegisterViewModel viewModel)
      {
         if (!ModelState.IsValid)
            return View(viewModel);

         var user = new AppUser
         {
            Email = viewModel.Email,
            UserName = viewModel.Email
         };

         var result = await _userManager.CreateAsync(user, viewModel.Password);

         if (result.Succeeded)
         {
            return RedirectToAction(
               actionName: nameof(AccountController.Login),
               controllerName: AccountController.Name,
               routeValues: new { registered = true });
         }

         foreach (var error in result.Errors)
         {
            ModelState.AddModelError("", error.Description);
         }

         return View(viewModel);
      }
   }
}