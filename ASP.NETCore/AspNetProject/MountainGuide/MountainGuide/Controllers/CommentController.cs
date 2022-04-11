using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MountainGuide.Core.Services.Contracts;
using MountainGuide.Infrastructure.Data.Models;
using MountainGuide.Models.Announcement;

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

            //if (!ModelState.IsValid)
            //{
            //    return Redirect($"/Announcement/Details/{model.Announcement.Id}");
            //}
            commentService.AddCommentToAnnouncement(model.Announcement.Id, model.AddCommentContent, userManager.GetUserId(User));

            return Redirect($"/Announcement/Details/{model.Announcement.Id}");
        }
    }
}
