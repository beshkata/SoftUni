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

        public AllAnnouncementServiceQueryModel GetAllAnnouncements(
            int currentPage = 1,
            int announcementsPerPage = 3)
        {
            var announcementQuery = data.Announcements
                .Include(a => a.TouristBuilding)
                .ThenInclude(tb => tb.TouristBuildingType)
                .Include(a => a.TouristAssociation).AsQueryable();

            int totalAnnouncements = announcementQuery.Count();

            var announcements = GetAnnouncements(announcementQuery
                .Skip((currentPage - 1) * announcementsPerPage)
                .Take(announcementsPerPage));

            return new AllAnnouncementServiceQueryModel
            {
                Announcements = announcements,
                TotalAnnouncements = totalAnnouncements,
                CurrentPage = currentPage,
                AnnouncementPerPage = announcementsPerPage
            };
        }

        private IEnumerable<AnnouncementAllServiceModel> GetAnnouncements(IQueryable<Infrastructure.Data.Models.Announcement> announcementQuery)
        {
            return announcementQuery
                .Select(a => new AnnouncementAllServiceModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    DateAdded = a.DateTime.ToString("g"),
                    PublishingOrganizationName =
                        a.TouristAssociation.Name != null ?
                        a.TouristAssociation.Name :
                        a.TouristBuilding.Name + " " + a.TouristBuilding.TouristBuildingType.Name,
                    LikesCount = a.Likes.Count(),
                    CommentsCount = a.Comments.Count()
                })
                .ToList();
        }
    }
}
