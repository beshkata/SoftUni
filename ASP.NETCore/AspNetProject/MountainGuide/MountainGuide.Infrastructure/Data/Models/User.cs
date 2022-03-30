using Microsoft.AspNetCore.Identity;

namespace MountainGuide.Infrastructure.Data.Models
{
    public class User : IdentityUser
    {
        public IEnumerable<Like> Likes { get; set; } = new List<Like>();

        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();

        public IEnumerable<Announcement> Announcements { get; set; } = new List<Announcement>();
    }
}
