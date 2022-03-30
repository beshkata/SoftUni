#nullable disable
using System.ComponentModel.DataAnnotations;

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
    }
}