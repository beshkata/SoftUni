#nullable disable
using System.ComponentModel.DataAnnotations;

namespace MountainGuide.Infrastructure.Data.Models
{
    using static DataConstant.Coordinate;

    public class Coordinate
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(LatitudeTypeLength)]
        public string LatitudeType { get; init; } = "North";

        [Required]
        [StringLength(ValueMaxLength)]
        public string LatitudeValue { get; set; }

        [Required]
        [StringLength(LongitudeTypeLength)]
        public string LongitudeType { get; init; } = "East";

        [Required]
        [StringLength(ValueMaxLength)]
        public string LongitudeValue { get; set; }
    }
}