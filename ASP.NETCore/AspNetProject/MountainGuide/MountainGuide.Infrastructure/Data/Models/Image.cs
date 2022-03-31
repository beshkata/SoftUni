#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MountainGuide.Infrastructure.Data.Models
{
    using static DataConstant.Image;
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [StringLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [StringLength(ImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        [ForeignKey(nameof(TouristBuilding))]
        public int? TouristBuildingId { get; set; }

        public TouristBuilding TouristBuilding { get; set; }

        [ForeignKey(nameof(Peak))]
        public int? PeakId { get; set; }

        public Peak Peak { get; set; }

        [ForeignKey(nameof(TouristAssociation))]
        public int? TouristAssociationId { get; set; }

        public TouristAssociation TouristAssociation { get; set; }

        [ForeignKey(nameof(Mountain))]
        public int? MountainId { get; set; }

        public Mountain Mountain { get; set; }

    }
}