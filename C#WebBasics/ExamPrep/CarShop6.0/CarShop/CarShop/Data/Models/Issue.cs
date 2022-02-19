using CarShop.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShop.Data.Models
{
    public class Issue
    {
        [Key]
        [MaxLength(GlobalConstants.GuidMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; set; }

        [Required]
        public bool IsFixed { get; set; }

        [Required]
        [MaxLength(GlobalConstants.GuidMaxLength)]
        [ForeignKey(nameof(Car))]
        public string CarId { get; set; }

        public Car Car { get; set; }
    }
}

