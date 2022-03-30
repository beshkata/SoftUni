using Microsoft.EntityFrameworkCore;
using MountainGuide.Infrastructure.Data.Models;

namespace MountainGuide.Infrastructure.Data.ModelConfig
{
    public static class AnnouncementConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder
                .Entity<Announcement>()
                .HasOne(a => a.User)
                .WithMany(u => u.Announcements)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Announcement>()
                .Property(p => p.TouristBuildingId)
                .IsRequired(false);

            builder
                .Entity<Announcement>()
                .Property(p => p.TouristAssociationId)
                .IsRequired(false);
        }
    }
}
