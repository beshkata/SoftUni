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
        [StringLength(ValueMaxLength)]
        public string Latitude { get; set; }

        [Required]
        [StringLength(ValueMaxLength)]
        public string Longitude { get; set; }

    }
}