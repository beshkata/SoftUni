using MountainGuide.Core.Services.TouristBuilding.Models;
using System.ComponentModel.DataAnnotations;

namespace MountainGuide.Models.TouristBuilding
{
    public class AllTouristBuildingViewModel
    {
        public List<TouristBuildingTypeServiceModel> BuildingTypes { get; set; } = new List<TouristBuildingTypeServiceModel>();

        public List<MountainServiceModel> Mountains { get; set; } = new List<MountainServiceModel>();

        public List<TouristBuildingServiceModel> Buildings { get; set; } = new List<TouristBuildingServiceModel>();

        [Display(Name = "Building Type")]
        public int TypeFilter { get; set; } = 0;

        [Display(Name = "Mountain")]
        public int MountainFilter { get; set; } = 0;

        public int BuildingsPerPage { get; set; } = 3;

        public int CurrentPage { get; init; } = 1;

        public int TotalBuildings { get; set; }

    }
}
