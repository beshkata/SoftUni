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
                .HasOne(tb => tb.TouristBuildingType)
                .WithMany(tt => tt.TouristBuildings)
                .HasForeignKey(tb => tb.TouristBuildingTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<TouristBuilding>()
                .HasOne(tb => tb.TouristAssociation)
                .WithMany(ta => ta.TouristBuildings)
                .HasForeignKey(tb => tb.TouristAssociationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<TouristBuilding>()
                .HasOne(tb => tb.Coordinate)
                .WithOne()
                .HasForeignKey<TouristBuilding>(tb => tb.CoordinateId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<TouristBuilding>()
                .HasOne(tb => tb.Mountain)
                .WithMany(m => m.TouristBuildings)
                .HasForeignKey(tb => tb.MountainId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<TouristBuilding>()
                .Property(tb => tb.MountainId)
                .IsRequired(false);
        }

    }
}
