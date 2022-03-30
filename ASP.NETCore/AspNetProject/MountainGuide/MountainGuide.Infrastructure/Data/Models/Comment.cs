using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MountainGuide.Infrastructure.Data.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; init; }

        [Required]
        public string Content { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; init; }

        public User User { get; init; }

        public DateTime DateTime { get; init; } = DateTime.UtcNow;

        public IEnumerable<Comment> Comments { get; init; } = new List<Comment>();

        public IEnumerable<Like> Likes { get; init; } = new List<Like>();

    }
}