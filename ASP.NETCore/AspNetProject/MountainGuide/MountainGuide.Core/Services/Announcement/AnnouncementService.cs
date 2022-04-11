using Microsoft.EntityFrameworkCore;
using MountainGuide.Core.Services.Announcement.Models;
using MountainGuide.Core.Services.Comment.Models;
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

        public AnnouncementDetailsServiceModel GetAnnouncementDetails(int id)
        {
            var announcement = data
                .Announcements
                .Where(a => a.Id == id)
                .Include(a => a.TouristBuilding)
                .ThenInclude(tb => tb.TouristBuildingType)
                .Include(a => a.TouristAssociation)
                .Include(a => a.Comments)
                .ThenInclude(c => c.User)
                .Select(a => new AnnouncementDetailsServiceModel
                {
                    Id = a.Id,
                    Title = a.Title,
                    Content = a.Content,
                    PublishingOrganizationName =
                        a.TouristAssociation.Name != null ?
                        a.TouristAssociation.Name :
                        a.TouristBuilding.Name + " " + a.TouristBuilding.TouristBuildingType.Name,
                    DateTimeAdded = a.DateTime.ToString("g"),
                    TouristBuildingId = a.TouristBuildingId,
                    TouristAssociationId = a.TouristAssociationId,
                    LikesCount = a.Likes.Count(),
                    Comments = a.Comments.Select(c => new CommentServiceModel
                    {
                        Id = c.Id,
                        Content = c.Content,
                        UserName = c.User.UserName,
                        DateTimeAdded = c.DateTime.ToString("g"),
                        LikesCount = c.Likes.Count()
                    })
                })
                .FirstOrDefault();
            return announcement;
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
