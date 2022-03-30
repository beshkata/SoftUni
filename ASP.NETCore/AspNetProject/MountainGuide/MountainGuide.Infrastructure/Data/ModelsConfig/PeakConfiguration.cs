using Microsoft.EntityFrameworkCore;
using MountainGuide.Infrastructure.Data.Models;

namespace MountainGuide.Infrastructure.Data.ModelConfig
{
    public class PeakConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder
                .Entity<Peak>()
                .HasOne(p => p.Mountain)
                .WithMany(m => m.Peaks)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Peak>()
                .HasOne(p => p.Coordinate)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Peak>()
                .Property(p => p.CoordinateId)
                .IsRequired(false);

            builder
                .Entity<Peak>()
                .Property(p => p.MountainId)
                .IsRequired(false);
        }

    }
}
