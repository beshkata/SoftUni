using MountainGuide.Core.Services.Announcement.Models;

namespace MountainGuide.Core.Services.Contracts
{
    public interface IAnnouncementService
    {
        List<AnnouncementAllServiceModel> GetAllAnnouncements();
    }
}
