#nullable disable
namespace MountainGuide.Core.Services.Announcement.Models
{
    public class AnnouncementAllServiceModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string DateAdded { get; set; }

        public string PublishingOrganizationName { get; set; }

        public int LikesCount { get; set; }

        public int CommentsCount { get; set; }
    }
}
