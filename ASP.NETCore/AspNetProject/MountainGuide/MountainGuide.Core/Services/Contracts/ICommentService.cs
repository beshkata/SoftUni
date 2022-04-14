namespace MountainGuide.Core.Services.Contracts
{
    public interface ICommentService
    {
        public void AddCommentToAnnouncement(int AnnouncementId, string commentContent, string userId);
        void AddCommentToTouristBuilding(int id, string commentContent, string userId);
    }
}
