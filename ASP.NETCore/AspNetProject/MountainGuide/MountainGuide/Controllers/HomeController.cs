using Microsoft.AspNetCore.Mvc;
using MountainGuide.Core.Services.Contracts;
using MountainGuide.Models;
using MountainGuide.Models.Home;
using System.Diagnostics;

namespace MountainGuide.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService homeService;
        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }
        public IActionResult Index()
        {
            var indexModel = new IndexViewModel
            {
                TotalAnnouncements = homeService.TotalAnnouncements(),
                TotalMountains = homeService.TotalMountains(),
                TotalPeaks = homeService.TotalPeaks(),
                TotalTouristBuildings = homeService.TotalTouristBuildings(),
                Announcements = homeService.GetAnnouncementInfo(),
                Mountains = homeService.GetMountainInfo(),
                Peaks = homeService.GetPeakInfo(),
                TouristBuildings = homeService.GetTouristBuildingsInfo()
            };
            return View(indexModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}