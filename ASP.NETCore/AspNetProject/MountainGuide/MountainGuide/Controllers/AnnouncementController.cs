using Microsoft.AspNetCore.Mvc;
using MountainGuide.Core.Services.Announcement.Models;
using MountainGuide.Core.Services.Contracts;
using MountainGuide.Models.Announcement;

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
                currentPage, ViewConstant.AnnouncementsPerPage);

            return View(new AllAnnouncementServiceQueryModel
            {
                CurrentPage = currentPage,
                TotalAnnouncements = queryResult.TotalAnnouncements,
                Announcements = queryResult.Announcements
            });
        }

        public IActionResult Details(int id)
        {
            var serviceModel = announcementService.GetAnnouncementDetails(id);
            
            if (serviceModel == null)
            {
                return NotFound();
            }

            return View(new AnnouncementDetailsViewModel
            {
                Announcement = serviceModel
            });
        }
    }
}
