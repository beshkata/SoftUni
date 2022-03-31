#nullable disable
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

        [ForeignKey(nameof(TouristBuilding))]
        public int? TouristBuildingId { get; init; }

        public TouristBuilding TouristBuilding { get; init; }

        [ForeignKey(nameof(TouristAssociation))]
        public int? TouristAssociationId { get; set; }

        public TouristAssociation TouristAssociation { get; set; }

        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();

        public IEnumerable<Like> Likes { get; init; } = new List<Like>();

    }
}