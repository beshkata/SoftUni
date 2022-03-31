using Microsoft.EntityFrameworkCore;
using MountainGuide.Infrastructure.Data.Models;

namespace MountainGuide.Infrastructure.Data.ModelConfig
{
    public class LikeConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder
                .Entity<Like>()
                .HasOne(l => l.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(l => l.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Like>()
                .HasOne(l => l.TouristAssociation)
                .WithMany(ta => ta.Likes)
                .HasForeignKey(l => l.TouristAssociationId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Like>()
                .HasOne(l => l.TouristBuilding)
                .WithMany(tb => tb.Likes)
                .HasForeignKey(l => l.TouristBuildingId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Like>()
                .HasOne(l => l.Comment)
                .WithMany(c => c.Likes)
                .HasForeignKey(l => l.CommentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Like>()
                .Property(l => l.TouristAssociationId)
                .IsRequired(false);
            builder
                .Entity<Like>()
                .Property(l => l.TouristBuildingId)
                .IsRequired(false);
            builder
                .Entity<Like>()
                .Property(l => l.CommentId)
                .IsRequired(false);
        }

    }
}
