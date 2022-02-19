using CarShop.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class AddCarViewModel
    {
        [Required]
        [StringLength(GlobalConstants.CarModelMaxLength,
            MinimumLength = GlobalConstants.CarModelMinLength,
            ErrorMessage = ErrorMessages.ModelErrorMessage)]
        public string Model { get; set; }

        [Required]
        public int Year { get; set; }
        [Required]
        [StringLength(GlobalConstants.CarPictureUrlMaxLength,
            ErrorMessage = ErrorMessages.PictureUrlErrorMessage)]
        public string ImageUrl { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.PlateNumberRegex)]
        public string PlateNumber { get; set; }
    }
}
