using FootballManager.Common;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.ViewModels
{
    public class AddPlayerViewModel
    {
        [Required]
        [StringLength(GlobalConstants.PlayerFullnameMaxLength,
            MinimumLength = GlobalConstants.PlayerFullnameMinLength)]
        public string FullName { get; set; }

        [Required]
        [StringLength(GlobalConstants.PlayerImageUrlMaxLength)]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(GlobalConstants.PlayerPositionMaxLength,
            MinimumLength = GlobalConstants.PlayerPositionMinLength)]
        public string Position { get; set; }

        [Required]
        [Range(GlobalConstants.PlayerSkillMinValue,
            GlobalConstants.PlayerSkillMaxValue)]
        public byte Speed { get; set; }

        [Required]
        [Range(GlobalConstants.PlayerSkillMinValue,
            GlobalConstants.PlayerSkillMaxValue)]
        public byte Endurance { get; set; }

        [Required]
        [StringLength(GlobalConstants.PlayerDescriptionMaxLength)]
        public string Description { get; set; }
    }
}
