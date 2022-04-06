using FootballManager.Common;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PlayerFullnameMaxLength)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PlayerImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PlayerPositionMaxLength)]
        public string Position { get; set; }

        public byte Speed { get; set; }

        public byte Endurance { get; set; }

        [Required]
        [MaxLength(GlobalConstants.PlayerDescriptionMaxLength)]
        public string Description { get; set; }

        public ICollection<UserPlayer> UserPlayers { get; set; } = new HashSet<UserPlayer>();
    }
}

