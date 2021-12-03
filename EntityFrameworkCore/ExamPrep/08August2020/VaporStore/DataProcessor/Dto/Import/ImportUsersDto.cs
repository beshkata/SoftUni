using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Common;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportUsersDto
    {
        [JsonProperty("FullName")]
        [Required]
        [RegularExpression(GlobalConstants.UserFullNameRegex)]
        public string FullName { get; set; }

        [Required]
        [JsonProperty("Username")]
        [MaxLength(GlobalConstants.UserUsernameMaxLength)]
        [MinLength(GlobalConstants.UserUsernameMinLength)]
        public string Username { get; set; }

        [JsonProperty("Email")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [Range(GlobalConstants.UserAgeMinValue, GlobalConstants.UserAgeMaxValue)]
        [JsonProperty("Age")]
        public int Age { get; set; }

        [Required]
        public ImportCardDto[] Cards { get; set; }
    }
}
