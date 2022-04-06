using Microsoft.EntityFrameworkCore;
using MountainGuide.Infrastructure.Data.Models;

namespace MountainGuide.Infrastructure.Data.ModelConfig
{
    public class CommentConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder
                .Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Comment>()
                .HasOne(c => c.TouristBuilding)
                .WithMany(tb => tb.Comments)
                .HasForeignKey(c => c.TouristBuildingId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Comment>()
                .HasOne(c => c.TouristAssociation)
                .WithMany(ta => ta.Comments)
                .HasForeignKey(c => c.TouristAssociationId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Comment>()
                .HasOne(c => c.Announcement)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.AnnouncementId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Comment>()
                .Property(c => c.TouristAssociationId)
                .IsRequired(false);
            builder
                .Entity<Comment>()
                .Property(c => c.TouristBuildingId)
                .IsRequired(false);
            builder
                .Entity<Comment>()
                .Property(c => c.AnnouncementId)
                .IsRequired(false);
        }

    }
}
