using MountainGuide.Core.Services.Contracts;
using MountainGuide.Core.Services.TouristBuilding.Models;
using MountainGuide.Infrastructure.Data;

namespace MountainGuide.Core.Services.TouristBuilding
{
    public class TouristBuildingService : ITouristBuildingService
    {
        private readonly MountainGuideDbContext data;

        public TouristBuildingService(MountainGuideDbContext data) => this.data = data;
        public List<TouristBuildingServiceModel> GetAllBuildings(
            int typeFilter, 
            int mountainFilter,
            int buildingsPerPage,
            int currentPage)
        {
            var buildings = data
                .TouristBuildings.AsQueryable();
            if (typeFilter != 0)
            {
                buildings = buildings.Where(b => b.TouristBuildingTypeId == typeFilter);
            };
            if (mountainFilter != 0)
            {
                buildings = buildings.Where(b => b.MountainId == mountainFilter);
            };

            return buildings
                .Select(b => new TouristBuildingServiceModel
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description,
                    TouristBuildingTypeId = b.TouristBuildingTypeId,
                    MountainName = b.Mountain.Name,
                    FrontImageUrl = b.Images.First().ImageUrl,
                    CommentsCount = b.Comments.Count(),
                    LikesCount = b.Likes.Count(),
                    AnnouncementsCount = b.Announcements.Count(),
                })
                .Skip((currentPage - 1) * buildingsPerPage)
                .Take(buildingsPerPage)
                .ToList();
        }

        public int GetAllBuildingsCount(int typeFilter, int mountainFilter)
        {
            var buildings = data
                .TouristBuildings.AsQueryable();
            if (typeFilter != 0)
            {
                buildings = buildings.Where(b => b.TouristBuildingTypeId == typeFilter);
            };
            if (mountainFilter != 0)
            {
                buildings = buildings.Where(b => b.MountainId == mountainFilter);
            };
            return buildings.Count();
        }

        public List<TouristBuildingTypeServiceModel> GetAllBuildingTypes() => data
                .TouristBuildingTypes
                .Select(t => new TouristBuildingTypeServiceModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToList();

        public List<MountainServiceModel> GetAllMountains() => data
                .Mountains
                .Select(m => new MountainServiceModel
                {
                    Id = m.Id,
                    Name = m.Name
                })
                .ToList();
    }
}
