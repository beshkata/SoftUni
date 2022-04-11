using MountainGuide.Core.Services.Announcement.Models;

namespace MountainGuide.Core.Services.Contracts
{
    public interface IAnnouncementService
    {
        AllAnnouncementServiceQueryModel GetAllAnnouncements(int currentPage, int announcementPerPage);
        AnnouncementDetailsServiceModel GetAnnouncementDetails(int id);
    }
}
