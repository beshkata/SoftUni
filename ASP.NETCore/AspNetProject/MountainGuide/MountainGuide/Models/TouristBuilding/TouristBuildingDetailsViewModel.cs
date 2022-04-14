#nullable disable
using MountainGuide.Core.Services.TouristBuilding.Models;
using System.ComponentModel.DataAnnotations;

namespace MountainGuide.Models.TouristBuilding
{
    public class TouristBuildingDetailsViewModel
    {
        public TouristBuildingDetailsServiceModel TouristBuilding { get; set; }

        [Required]
        [StringLength(int.MaxValue, MinimumLength = ViewConstant.CommentMinLength)]
        public string AddCommentContent { get; set; }

    }
}
