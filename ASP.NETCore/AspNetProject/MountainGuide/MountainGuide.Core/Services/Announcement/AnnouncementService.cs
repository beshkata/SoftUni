using Microsoft.EntityFrameworkCore;
using MountainGuide.Core.Services.Announcement.Models;
using MountainGuide.Core.Services.Contracts;
using MountainGuide.Infrastructure.Data;

namespace MountainGuide.Core.Services.Announcement
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly MountainGuideDbContext data;

        public AnnouncementService(MountainGuideDbContext data)
        {
            this.data = data;
        }

        public List<AnnouncementAllServiceModel> GetAllAnnouncements()
        {
            var all = data
                .Announcements
                .Include(a => a.TouristBuilding)
                .ThenInclude(tb => tb.TouristBuildingType)
                .Include(a => a.TouristAssociation)
                .Select(a => new AnnouncementAllServiceModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    DateAdded = a.DateTime.ToString("g"),
                    PublishingOrganizationName =
                        a.TouristAssociation.Name != null ?
                        a.TouristAssociation.Name :
                        a.TouristBuilding.Name + " " + a.TouristBuilding.TouristBuildingType.Name
                })
                .ToList();
            return all;
        }
    }
}
