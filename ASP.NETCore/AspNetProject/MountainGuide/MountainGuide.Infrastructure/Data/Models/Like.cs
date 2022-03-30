#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MountainGuide.Infrastructure.Data.Models
{
    public class Like
    {
        public int Id { get; init; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; init; }

        public User User { get; init; }

        public DateTime DateTime { get; init; } = DateTime.UtcNow;

    }
}