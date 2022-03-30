using Microsoft.EntityFrameworkCore;
using MountainGuide.Infrastructure.Data.Models;

namespace MountainGuide.Infrastructure.Data.ModelConfig
{
    public class TouristBuildingConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder
                .Entity<TouristBuilding>()
                .HasOne(tb => tb.Type)
                .WithMany(tt => tt.TouristBuildings)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<TouristBuilding>()
                .HasOne(tb => tb.TouristAssociation)
                .WithMany(ta => ta.TouristBuildings)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<TouristBuilding>()
                .HasOne(tb => tb.Coordinate)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<TouristBuilding>()
                .HasOne(tb => tb.Mountain)
                .WithMany(m => m.TouristBuildings)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<TouristBuilding>()
                .Property(tb => tb.MountainId)
                .IsRequired(false);

        }

    }
}
