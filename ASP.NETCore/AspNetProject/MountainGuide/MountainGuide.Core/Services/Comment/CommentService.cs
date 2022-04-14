using MountainGuide.Core.Services.Contracts;
using MountainGuide.Infrastructure.Data;

namespace MountainGuide.Core.Services.Comment
{
    public class CommentService : ICommentService
    {
        private readonly MountainGuideDbContext data;

        public CommentService(MountainGuideDbContext data)
        {
            this.data = data;
        }

        public void AddCommentToAnnouncement(int AnnouncementId, string commentContent, string userId)
        {
            var comment = new Infrastructure.Data.Models.Comment
            {
                AnnouncementId = AnnouncementId,
                Content = commentContent,
                UserId = userId
            };
            data.Comments.Add(comment);
            data.SaveChanges();
        }

        public void AddCommentToTouristBuilding(int id, string commentContent, string userId)
        {
            var comment = new Infrastructure.Data.Models.Comment
            {
                TouristBuildingId = id,
                Content = commentContent,
                UserId = userId
            };
            data.Comments.Add(comment);
            data.SaveChanges();

        }
    }
}
