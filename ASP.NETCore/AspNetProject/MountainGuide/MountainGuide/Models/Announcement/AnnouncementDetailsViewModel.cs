using MountainGuide.Core.Services.Announcement.Models;
using System.ComponentModel.DataAnnotations;

namespace MountainGuide.Models.Announcement
{
    public class AnnouncementDetailsViewModel
    {
        public AnnouncementDetailsServiceModel Announcement { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = ViewConstant.CommentMinLength)]
        public string AddCommentContent { get; set; }
    }
}
