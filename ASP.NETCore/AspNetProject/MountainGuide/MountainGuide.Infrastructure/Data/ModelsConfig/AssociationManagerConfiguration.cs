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
                .HasForeignKey<AssociationManager>(am => am.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<AssociationManager>()
                .HasOne(am => am.TouristAssociation)
                .WithOne()
                .HasForeignKey<AssociationManager>(am => am.TouristAssociationId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
