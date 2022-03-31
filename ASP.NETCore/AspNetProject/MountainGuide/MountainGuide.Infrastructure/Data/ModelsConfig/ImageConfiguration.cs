using Microsoft.EntityFrameworkCore;
using MountainGuide.Infrastructure.Data.Models;

namespace MountainGuide.Infrastructure.Data.ModelConfig
{
    public class ImageConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder
                .Entity<Image>()
                .HasOne(i => i.Mountain)
                .WithMany(m => m.Images)
                .HasForeignKey(i => i.MountainId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Image>()
                .HasOne(i => i.TouristBuilding)
                .WithMany(tb => tb.Images)
                .HasForeignKey(i => i.TouristBuildingId)
                .OnDelete(DeleteBehavior.Restrict);
            builder
                .Entity<Image>()
                .HasOne(i => i.TouristAssociation)
                .WithMany(ta => ta.Images)
                .HasForeignKey(i => i.TouristAssociationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Image>()
                .HasOne(i => i.Peak)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.PeakId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Image>()
                .Property(i => i.PeakId)
                .IsRequired(false);

            builder
                .Entity<Image>()
                .Property(i => i.MountainId)
                .IsRequired(false);

            builder
                .Entity<Image>()
                .Property(i => i.TouristAssociationId)
                .IsRequired(false);

            builder
                .Entity<Image>()
                .Property(i => i.TouristBuildingId)
                .IsRequired(false);
        }

    }
}
