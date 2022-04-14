#nullable disable
using MountainGuide.Core.Services.Announcement.Models;
using MountainGuide.Core.Services.Comment.Models;
using MountainGuide.Core.Services.Image;

namespace MountainGuide.Core.Services.TouristBuilding.Models
{
    public class TouristBuildingDetailsServiceModel
    {
        public int Id { get; init; }

        public string Name { get; set; }

        public double Altitude { get; set; }

        public string Description { get; set; }

        public string PhoneNumber { get; set; }

        public int Capacity { get; set; }

        public string TouristBuildingTypeName { get; set; }

        public int TouristAssociationId { get; set; }

        public string TouristAssociationName { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int LikesCount { get; init; }

        public int? MountainId { get; set; }

        public string MountainName { get; set; }

        public IEnumerable<ImageServiceModel> Images { get; init; } = new List<ImageServiceModel>();

        public IEnumerable<CommentServiceModel> Comments { get; init; } = new List<CommentServiceModel>();

        public IEnumerable<AnnouncementServiceModel> Announcements { get; set; } = new List<AnnouncementServiceModel>();

    }
}
