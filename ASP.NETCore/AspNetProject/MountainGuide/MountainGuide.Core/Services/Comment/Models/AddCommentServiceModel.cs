namespace MountainGuide.Core.Services.Comment.Models
{
    public class AddCommentServiceModel
    {
        public string Content { get; set; }

        public string UserId { get; init; }

        public int? TouristBuildingId { get; init; }

        public int? TouristAssociationId { get; set; }

        public int? AnnouncementId { get; set; }
    }
}
