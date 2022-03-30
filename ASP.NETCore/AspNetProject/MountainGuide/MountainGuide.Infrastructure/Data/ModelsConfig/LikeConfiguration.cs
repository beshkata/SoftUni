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
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
