#nullable disable
using System.ComponentModel.DataAnnotations;

namespace MountainGuide.Infrastructure.Data.Models
{
    using static DataConstant.Peak;
    public class Peak
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; init; }

        [Required]
        public double Altitude { get; set; }

        public string Description { get; set; }

        public int? CoordinateId { get; set; }

        public Coordinate Coordinate { get; set; }

        public int? MountainId { get; set; }

        public Mountain Mountain { get; set; }

        public IEnumerable<Image> Images { get; set; } = new List<Image>();
    }
}