namespace MountainGuide.Core.Services.Announcement.Models
{
    public class AllAnnouncementServiceQueryModel
    {
        public int AnnouncementPerPage { get; set; }

        public int CurrentPage { get; init; }

        public int TotalAnnouncements { get; set; }

        public IEnumerable<AnnouncementAllServiceModel> Announcements { get; set; }
    }
}
