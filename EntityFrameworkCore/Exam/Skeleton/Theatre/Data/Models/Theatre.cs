using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Theatre.Common;

namespace Theatre.Data.Models
{
    public class Theatre
    {
        public Theatre()
        {
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.TheatreNameMaxLength)]
        public string Name { get; set; }

        [Range(GlobalConstants.TheatreNumberOfHallsMinValue, GlobalConstants.TheatreNumberOfHallsMaxValue)]
        public sbyte NumberOfHalls  { get; set; }

        [Required]
        [MaxLength(GlobalConstants.TheatreDirectorMaxLength)]
        public string Director { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
