using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MountainGuide.Core.Services.Contracts;
using MountainGuide.Infrastructure.Data.Models;
using MountainGuide.Models.Announcement;
using MountainGuide.Models.TouristBuilding;

namespace MountainGuide.Controllers
{
    public class CommentController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;
        private readonly ICommentService commentService;


        public CommentController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            ICommentService commentService)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.commentService = commentService;
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddCommentToAnnouncement(AnnouncementDetailsViewModel model)
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Identity/Account/Login");
            }

            commentService.AddCommentToAnnouncement(model.Announcement.Id, model.AddCommentContent, userManager.GetUserId(User));

            return Redirect($"/Announcement/Details/{model.Announcement.Id}");
        }

        public IActionResult AddCommentToTouristBuilding(TouristBuildingDetailsViewModel model)
        {
            if (!signInManager.IsSignedIn(User))
            {
                return Redirect("/Identity/Account/Login");
            }

            commentService.AddCommentToTouristBuilding(model.TouristBuilding.Id, model.AddCommentContent, userManager.GetUserId(User));
            return Redirect($"/TouristBuilding/Details/{model.TouristBuilding.Id}");
        }
    }
}
