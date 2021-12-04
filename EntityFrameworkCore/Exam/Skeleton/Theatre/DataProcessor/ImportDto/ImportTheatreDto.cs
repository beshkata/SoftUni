using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheatreDto
    {
        [Required]
        [MaxLength(GlobalConstants.TheatreNameMaxLength)]
        [MinLength(GlobalConstants.TheatreNameMinLength)]
        public string Name { get; set; }

        [Required]
        [Range(GlobalConstants.TheatreNumberOfHallsMinValue, GlobalConstants.TheatreNumberOfHallsMaxValue)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [MaxLength(GlobalConstants.TheatreDirectorMaxLength)]
        [MinLength(GlobalConstants.TheatreDirectorMinLength)]
        public string Director { get; set; }

        public ImportTicketDto[] Tickets { get; set; }

    }
}
