using Microsoft.AspNetCore.Mvc;
using MountainGuide.Core.Services.Announcement.Models;
using MountainGuide.Core.Services.Contracts;

namespace MountainGuide.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            this.announcementService = announcementService;
        }
        public IActionResult All(int currentPage = 1)
        {
            var queryResult = this.announcementService.GetAllAnnouncements(
                currentPage, 3);

            return View(new AllAnnouncementServiceQueryModel
            {
                CurrentPage = currentPage,
                TotalAnnouncements = queryResult.TotalAnnouncements,
                Announcements = queryResult.Announcements
            });
        }
    }
}
