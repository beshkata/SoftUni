using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MountainGuide.Infrastructure.Data.Models
{
    using static DataConstant.Announcement;
    public class Announcement
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ContentMaxLength)]
        public string Content { get; set; }

        public DateTime DateTime { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(UserIdMaxLength)]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(TouristBuilding))]
        public int? TouristBuildingId { get; set; }

        public TouristBuilding TouristBuilding { get; set; }

        [ForeignKey(nameof(TouristAssociation))]
        public int? TouristAssociationId { get; set; }
        
        public TouristAssociation TouristAssociation { get; set; }
    }
}