using Microsoft.EntityFrameworkCore;
using MountainGuide.Infrastructure.Data.Models;

namespace MountainGuide.Infrastructure.Data.ModelConfig
{
    public class TouristAssociationConfiguration
    {
        public static void Configure(ModelBuilder builder)
        {
            builder
                .Entity<TouristAssociation>()
                .Property(ta => ta.LogoUrl)
                .IsRequired(false);

            builder
                .Entity<TouristAssociation>()
                .Property(ta => ta.WebSiteUrl)
                .IsRequired(false);
        }

    }
}
