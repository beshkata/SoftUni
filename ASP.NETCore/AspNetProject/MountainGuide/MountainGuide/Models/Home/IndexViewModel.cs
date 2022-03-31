using MountainGuide.Core.Services.Home.Models;

namespace MountainGuide.Models.Home
{
    public class IndexViewModel
    {
        public int TotalAnnouncements { get; set; }

        public int TotalMountains { get; set; }

        public int TotalTouristBuildings { get; set; }

        public int TotalPeaks { get; set; }

        public List<AnnouncementServiceModel> Announcements { get; set; } = new List<AnnouncementServiceModel>();

        public List<MountainServiceModel> Mountains { get; set; } = new List<MountainServiceModel>();

        public List<PeakServiceModel> Peaks { get; set; } = new List<PeakServiceModel>();

        public List<TouristBuildingServiceModel> TouristBuildings { get; set; } = new List<TouristBuildingServiceModel>();

    }
}
