using MountainGuide.Core.Services.Comment.Models;

namespace MountainGuide.Core.Services.Announcement.Models
{
    public class AnnouncementDetailsServiceModel
    {
        public int Id { get; init; }

        public string Title { get; init; }

        public string Content { get; init; }

        public string PublishingOrganizationName { get; init; }

        public string DateTimeAdded { get; init; }

        public int? TouristBuildingId { get; init; }

        public int? TouristAssociationId { get; init; }

        public int LikesCount { get; init; }

        public IEnumerable<CommentServiceModel> Comments { get; init; } = new List<CommentServiceModel>();
    }
}
