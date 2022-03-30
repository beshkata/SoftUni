using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MountainGuide.Infrastructure.Data.ModelConfig;
using MountainGuide.Infrastructure.Data.Models;

namespace MountainGuide.Infrastructure.Data
{
    public class MountainGuideDbContext : IdentityDbContext
    {
        public MountainGuideDbContext(DbContextOptions<MountainGuideDbContext> options)
            : base(options)
        {
        }

        public DbSet<Announcement> Announcements { get; set; }

        public DbSet<AssociationManager> AssociationManagers { get; set; }

        public DbSet<BuildingManager> BuildingManagers { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Coordinate> Coordinates { get; set; }

        public DbSet<Image> Images { get; set; }

        public DbSet<Like> Likes { get; set; }

        public DbSet<Mountain> Mountains { get; set; }

        public DbSet<Peak> Peaks { get; set; }

        public DbSet<TouristAssociation> TouristAssociations { get; set; }

        public DbSet<TouristBuilding> TouristBuildings { get; set; }

        public DbSet<TouristBuildingType> TouristBuildingTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            AnnouncementConfiguration.Configure(builder);
            AssociationManagerConfiguration.Configure(builder);
            BuildingManagerConfiguration.Configure(builder);
            CommentConfiguration.Configure(builder);
            LikeConfiguration.Configure(builder);
            PeakConfiguration.Configure(builder);
            TouristAssociationConfiguration.Configure(builder);
            TouristBuildingConfiguration.Configure(builder);

            base.OnModelCreating(builder);
        }
    }
}