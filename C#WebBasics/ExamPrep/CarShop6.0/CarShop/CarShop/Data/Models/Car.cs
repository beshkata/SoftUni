using CarShop.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShop.Data.Models
{
    public class Car
    {
        [Key]
        [MaxLength(GlobalConstants.GuidMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(GlobalConstants.CarModelMaxLength)]
        public string Model { get; set; }

        public int Year { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CarPictureUrlMaxLength)]
        public string PictureUrl { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CarPlateNumberMaxLength)]
        public string PlateNumber { get; set; }

        [Required]
        [MaxLength(GlobalConstants.GuidMaxLength)]
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }

        public User Owner { get; set; }

        public ICollection<Issue> Issues { get; set; } = new HashSet<Issue>();

    }
}
