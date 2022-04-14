using MountainGuide.Core.Services.TouristBuilding.Models;

namespace MountainGuide.Core.Services.Contracts
{
    public interface ITouristBuildingService
    {
        List<TouristBuildingServiceModel> GetAllBuildings(
            int typeFilter,
            int mountainFilter,
            int buildingsPerPage,
            int currentPage);
        List<MountainServiceModel> GetAllMountains();
        List<TouristBuildingTypeServiceModel> GetAllBuildingTypes();

        int GetAllBuildingsCount(int typeFilter, int mountainFilter);
        TouristBuildingDetailsServiceModel GetBuildingDetails(int id);
    }
}
