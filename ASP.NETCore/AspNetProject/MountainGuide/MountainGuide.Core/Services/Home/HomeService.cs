using MountainGuide.Core.Services.Contracts;
using MountainGuide.Core.Services.Home.Models;
using MountainGuide.Infrastructure.Data;

namespace MountainGuide.Core.Services.Home
{
    using static HomeServiceConstant;
    public class HomeService : IHomeService
    {
        private readonly MountainGuideDbContext data;

        public HomeService(MountainGuideDbContext data)
        {
            this.data = data;
        }

        public List<AnnouncementServiceModel> GetAnnouncementInfo()
            => data
                .Announcements
                .OrderByDescending(a => a.DateTime)
                .Take(IndexModelListCount)
                .Select(a => new AnnouncementServiceModel
                {
                    Id = a.Id,
                    ContentBegining = string.Concat(a.Content.Take(AnnouncementContentLength)) + "..."
                })
                .ToList();

        public List<MountainServiceModel> GetMountainInfo()
            => data
                .Mountains
                .OrderByDescending(m => m.Id)
                .Take(IndexModelListCount)
                .Select(m => new MountainServiceModel
                {
                    Id = m.Id,
                    Name = m.Name
                })
                .ToList();

        public List<PeakServiceModel> GetPeakInfo()
            => data
                .Peaks
                .OrderByDescending(p => p.Id)
                .Take(IndexModelListCount)
                .Select(p => new PeakServiceModel
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToList();

        public List<TouristBuildingServiceModel> GetTouristBuildingsInfo()
            => data
                .TouristBuildings
                .OrderByDescending(t => t.Id)
                .Take(3)
                .Select(p => new TouristBuildingServiceModel
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToList();

        public int TotalAnnouncements()
            => data
                .Announcements
                .Count();

        public int TotalMountains()
            => data
                .Mountains
                .Count();

        public int TotalPeaks()
            => data
                .Peaks
                .Count();

        public int TotalTouristBuildings()
            => data
                .TouristBuildings
                .Count();
    }
}
