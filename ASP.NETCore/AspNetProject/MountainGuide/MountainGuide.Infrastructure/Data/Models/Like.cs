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

        [ForeignKey(nameof(TouristAssociation))]
        public int? TouristAssociationId { get; set; }

        public TouristAssociation TouristAssociation { get; set; }

        [ForeignKey(nameof(TouristBuilding))]
        public int? TouristBuildingId { get; set; }

        public TouristBuilding TouristBuilding { get; set; }

        [ForeignKey(nameof(Comment))]
        public int? CommentId { get; set; }

        public Comment Comment { get; set; }

    }
}