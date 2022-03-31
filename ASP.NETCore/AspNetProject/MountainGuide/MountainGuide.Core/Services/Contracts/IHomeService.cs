using MountainGuide.Core.Services.Home.Models;

namespace MountainGuide.Core.Services.Contracts
{
    public interface IHomeService
    {
        List<AnnouncementServiceModel> GetAnnouncementInfo();
        List<TouristBuildingServiceModel> GetTouristBuildingsInfo();
        List<PeakServiceModel> GetPeakInfo();
        List<MountainServiceModel> GetMountainInfo();
        int TotalMountains();
        int TotalPeaks();
        int TotalTouristBuildings();
        int TotalAnnouncements();
    }
}
