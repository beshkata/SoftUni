namespace MountainGuide.Core.Services.Comment.Models
{
    public class CommentServiceModel
    {
        public int Id { get; init; }

        public string Content { get; init; }

        public string UserName { get; init; }

        public int LikesCount { get; init; }

        public string DateTimeAdded { get; set; }
    }
}
