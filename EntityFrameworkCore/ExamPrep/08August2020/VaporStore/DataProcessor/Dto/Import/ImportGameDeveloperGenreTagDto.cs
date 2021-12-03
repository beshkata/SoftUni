using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VaporStore.Common;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportGameDeveloperGenreTagDto
    {
        [Required]
        [JsonProperty("Name")]
        public string GameName { get; set; }

        [JsonProperty("Price")]
        [Range(GlobalConstants.GamePriceMinValue, (double)decimal.MaxValue)]
        public decimal GamePrice { get; set; }

        [Required]
        [JsonProperty("ReleaseDate")]
        public string GameReleaseDate { get; set; }

        [Required]
        [JsonProperty("Developer")]
        public string DeveloperName { get; set; }

        [Required]
        [JsonProperty("Genre")]
        public string GenreName { get; set; }

        [Required]
        public string[] Tags { get; set; }
    }
}
