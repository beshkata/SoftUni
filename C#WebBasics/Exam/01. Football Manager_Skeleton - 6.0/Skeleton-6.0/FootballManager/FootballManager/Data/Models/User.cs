using FootballManager.Common;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class User
    {
        [Key]
        [MaxLength(GlobalConstants.GuidMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(GlobalConstants.UserUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UserEmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [MaxLength(GlobalConstants.UserPasswordHashMaxLength)]
        public string Password { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; } = new HashSet<UserPlayer>();
    }
}
