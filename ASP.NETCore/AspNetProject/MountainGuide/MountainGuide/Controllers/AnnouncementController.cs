using Microsoft.AspNetCore.Mvc;
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
        public IActionResult All()
        {
            var all = announcementService.GetAllAnnouncements();
            return View(all);
        }
    }
}
