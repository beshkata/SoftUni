using SharedTrip.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Data.Models
{
    public class Trip
    {
        public Trip()
        {
            UserTrips = new HashSet<UserTrip>();
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        [StringLength(GlobalConstants.GuidMaxLength)]
        public string Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.TripStartEndPointMaxLength)]
        public string StartPoint { get; set; }

        [Required]
        [StringLength(GlobalConstants.TripStartEndPointMaxLength)]
        public string EndPoint { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        [Range(GlobalConstants.TripSeatsMinValue, GlobalConstants.TripSeatsMaxValue)]
        public int Seats { get; set; }

        [Required]
        [StringLength(GlobalConstants.TripDescriptionMaxLength)]
        public string Description { get; set; }

        [StringLength(GlobalConstants.TripImagePathMaxLength)]
        public string ImagePath { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; }
    }
}

