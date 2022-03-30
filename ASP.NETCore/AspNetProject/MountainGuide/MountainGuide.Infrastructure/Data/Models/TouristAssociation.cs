#nullable disable
using System.ComponentModel.DataAnnotations;

namespace MountainGuide.Infrastructure.Data.Models
{
    using static DataConstant.TouristAssociation;
    public class TouristAssociation
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; init; }

        [Required]
        public string Description { get; set; }

        [StringLength(LogoUrlMaxLength)]
        public string LogoUrl { get; set; }

        [StringLength(WebSiteUrlMaxLength)]
        public string WebSiteUrl { get; set; }

        public IEnumerable<TouristBuilding> TouristBuildings { get; set; } = new List<TouristBuilding>();

        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();

        public IEnumerable<Image> Images { get; set; } = new List<Image>();

        public IEnumerable<Announcement> Announcements { get; set; } = new List<Announcement>();
    }
}