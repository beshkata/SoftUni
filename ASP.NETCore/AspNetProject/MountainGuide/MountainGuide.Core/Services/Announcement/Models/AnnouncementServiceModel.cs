#nullable disable
namespace MountainGuide.Core.Services.Announcement.Models
{
    public class AnnouncementServiceModel
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public string Content { get; init; }

        public string DateTimeAdded { get; init; }

        public int LikesCount { get; init; }

    }
}
