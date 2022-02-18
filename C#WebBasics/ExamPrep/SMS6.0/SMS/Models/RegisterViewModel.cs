using SMS.Common;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class RegisterViewModel
    {
        [StringLength(GlobalConstants.UserUsernameMaxLength,
            MinimumLength = GlobalConstants.UserUsernameMinLength,
            ErrorMessage = ErrorMessages.UsernameErrorMessage)]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = ErrorMessages.EmailErrorMessage)]
        public string Email { get; set; }

        [StringLength(GlobalConstants.UserPasswordMaxLength,
            MinimumLength = GlobalConstants.UserPasswordMinLength,
            ErrorMessage = ErrorMessages.PasswordErrorMessage)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = ErrorMessages.PasswordConfirmPassrordErrorMessage)]
        public string ConfirmPassword { get; set; }
    }
}
