using Microsoft.EntityFrameworkCore;
using MountainGuide.Infrastructure.Data.Models;

namespace MountainGuide.Infrastructure.Data.ModelConfig
{
    public class BuildingManagerConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder
                .Entity<BuildingManager>()
                .HasOne(bm => bm.User)
                .WithOne()
                .HasForeignKey<BuildingManager>(bm => bm.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<BuildingManager>()
                .HasOne(bm => bm.TouristBuilding)
                .WithOne()
                .HasForeignKey<BuildingManager>(bm => bm.TouristBuildingId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
