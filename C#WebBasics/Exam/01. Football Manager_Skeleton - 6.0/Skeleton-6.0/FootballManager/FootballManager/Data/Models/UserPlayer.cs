using FootballManager.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManager.Data.Models
{
    public class UserPlayer
    {
        [ForeignKey(nameof(User))]
        [MaxLength(GlobalConstants.GuidMaxLength)]
        public string UserId { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(Player))]
        [MaxLength(GlobalConstants.GuidMaxLength)]
        public int PlayerId { get; set; }

        public Player Player { get; set; }
    }
}

