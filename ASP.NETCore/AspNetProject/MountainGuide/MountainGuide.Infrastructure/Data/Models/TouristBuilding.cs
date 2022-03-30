using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MountainGuide.Infrastructure.Data.Models
{
    using static DataConstant.TouristBuilding;

    public class TouristBuilding
    {
        [Key]
        public int Id { get; init; }

#nullable disable
        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; }

        public double Altitude { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        public int Capacity { get; set; }

        [ForeignKey(nameof(Type))]
        public int TouristBuildingTypeId { get; set; }

        public TouristBuildingType Type { get; set; }

        [ForeignKey(nameof(TouristAssociation))]
        public int TouristAssociationId { get; set; }

        public TouristAssociation TouristAssociation { get; set; }

        [ForeignKey(nameof(Coordinate))]
        public int CoordinateId { get; set; }

        public Coordinate Coordinate { get; set; }

        [ForeignKey(nameof(Mountain))]
        public int? MountainId { get; set; }

        public Mountain Mountain { get; set; }

        public IEnumerable<Image> Images { get; init; } = new List<Image>();

        public IEnumerable<Comment> Comments { get; init; } = new List<Comment>();

        public IEnumerable<Like> Likes { get; init; } = new List<Like>();

        public IEnumerable<Announcement> Announcements { get; set; } = new List<Announcement>();
    }
}