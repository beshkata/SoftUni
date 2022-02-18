using SMS.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace SMS.Models
{
    public class CreateViewModel
    {
        [Required]
        [StringLength(GlobalConstants.ProductNameMaxLength,
            MinimumLength = GlobalConstants.ProductNameMinLength, 
            ErrorMessage = ErrorMessages.CreateProductErrorMessage)]
        public string Name { get; set; }

        public string Price { get; set; }
    }
}
