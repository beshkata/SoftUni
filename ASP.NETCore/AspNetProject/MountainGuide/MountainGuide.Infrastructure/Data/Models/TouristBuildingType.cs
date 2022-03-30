using System.ComponentModel.DataAnnotations;

namespace MountainGuide.Infrastructure.Data.Models
{
    using static DataConstant.TouristBuildingType;
    public class TouristBuildingType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string Name { get; set; }

        public IEnumerable<TouristBuilding> TouristBuildings { get; set; } = new List<TouristBuilding>();
    }
}