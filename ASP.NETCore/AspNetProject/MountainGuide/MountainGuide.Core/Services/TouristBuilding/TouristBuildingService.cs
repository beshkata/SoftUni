using Microsoft.EntityFrameworkCore;
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

        public TouristBuildingDetailsServiceModel GetBuildingDetails(int id)
        {
            var building = data
                .TouristBuildings
                .Where(b => b.Id == id)
                .Include(b => b.Mountain)
                .Include(b => b.TouristAssociation)
                .Include(b => b.Images)
                .Include(b => b.Comments)
                .ThenInclude(c => c.User)
                .Include(b => b.Coordinate)
                .Include(b => b.TouristBuildingType)
                .Include(b => b.Announcements)
                .FirstOrDefault();

            if (building == null)
            {
                return null;
            }

            var result = new TouristBuildingDetailsServiceModel
            {
                Id = building.Id,
                Name = building.Name,
                Altitude = building.Altitude,
                Description = building.Description,
                PhoneNumber = building.PhoneNumber,
                Capacity = building.Capacity,
                TouristBuildingTypeName = building.TouristBuildingType.Name,
                TouristAssociationId = building.TouristAssociationId,
                TouristAssociationName = building.TouristAssociation.Name,
                Latitude = building.Coordinate.LatitudeValue,
                Longitude = building.Coordinate.LongitudeValue,
                LikesCount = building.Likes.Count(),
                MountainId = building.MountainId,
                MountainName = building.Mountain.Name,
                Images = building.Images
                .Select(i => new Image.ImageServiceModel
                {
                    ImageUrl = i.ImageUrl,
                    Description = i.Description
                }),
                Announcements = building.Announcements
                .Select(a => new Announcement.Models.AnnouncementServiceModel
                {
                    Id = a.Id,
                    Content = a.Content,
                    DateTimeAdded = a.DateTime.ToString("g"),
                    LikesCount = a.Likes.Count(),
                    Title = a.Title
                }),
                Comments = building.Comments
                .Select(c => new Comment.Models.CommentServiceModel
                {
                    Content = c.Content,
                    UserName = c.User.UserName,
                    DateTimeAdded = c.DateTime.ToString("g"),
                    LikesCount = c.Likes.Count()
                })
            };
            return result;
        }
    }
}
