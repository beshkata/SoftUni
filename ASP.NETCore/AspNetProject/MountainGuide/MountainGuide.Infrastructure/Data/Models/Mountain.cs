#nullable disable
using System.ComponentModel.DataAnnotations;

namespace MountainGuide.Infrastructure.Data.Models
{    
    using static DataConstant.Mountain;
    public class Mountain
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; }
        
        [Required]
        public string Description { get; set; }

        public IEnumerable<Peak> Peaks { get; init; } = new List<Peak>();

        public IEnumerable<TouristBuilding> TouristBuildings { get; init; } = new List<TouristBuilding>();

        public IEnumerable<Image> Images { get; init; } = new List<Image>();
    }
}