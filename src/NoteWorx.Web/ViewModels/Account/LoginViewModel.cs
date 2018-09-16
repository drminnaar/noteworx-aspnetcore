using System.ComponentModel.DataAnnotations;

namespace NoteWorx.Web.ViewModels.Account
{
   public sealed class LoginViewModel
   {
      [Required(ErrorMessage = "Email is required")]
      [EmailAddress(ErrorMessage = "Invalid email address specified")]
      public string Email { get; set; }

      [Required(ErrorMessage = "Password is required")]
      [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#\$%\^&\*]).{8,}$", ErrorMessage = "Invalid password specified")]
      public string Password { get; set; }
   }
}