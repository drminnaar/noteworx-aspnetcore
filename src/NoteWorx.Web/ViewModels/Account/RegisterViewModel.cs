using System.ComponentModel.DataAnnotations;

namespace NoteWorx.Web.ViewModels.Account
{
    public sealed class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address specified")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#\$%\^&\*]).{8,}$", ErrorMessage = "Invalid password specified")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Confirmation password is required")]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        public string ConfirmationPassword { get; set; } = string.Empty;
    }
}
