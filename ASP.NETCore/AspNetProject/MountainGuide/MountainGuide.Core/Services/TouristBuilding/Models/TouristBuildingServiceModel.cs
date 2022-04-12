#nullable disable

namespace MountainGuide.Core.Services.TouristBuilding.Models
{
    public class TouristBuildingServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TouristBuildingTypeId { get; set; }

        public string MountainName { get; set; }

        public string FrontImageUrl { get; set; }

        public int CommentsCount { get; set; }

        public int LikesCount { get; set; }

        public int AnnouncementsCount { get; set; }
    }
}
