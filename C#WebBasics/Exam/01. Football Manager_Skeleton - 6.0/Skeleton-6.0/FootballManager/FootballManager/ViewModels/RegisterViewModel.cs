using FootballManager.Common;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.ViewModels
{
    public class RegisterViewModel
    {
        [StringLength(GlobalConstants.UserUsernameMaxLength,
            MinimumLength = GlobalConstants.UserUsernameMinLength)]
        public string Username { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(GlobalConstants.UserPasswordMaxLength,
            MinimumLength = GlobalConstants.UserPasswordMinLength)]
        public string Password { get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
