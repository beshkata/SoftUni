using Microsoft.EntityFrameworkCore;
using MountainGuide.Infrastructure.Data.Models;

namespace MountainGuide.Infrastructure.Data.ModelConfig
{
    public class AssociationManagerConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder
                .Entity<AssociationManager>()
                .HasOne(am => am.User)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<AssociationManager>()
                .HasOne(am => am.TouristAssociation)
                .WithOne()
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
