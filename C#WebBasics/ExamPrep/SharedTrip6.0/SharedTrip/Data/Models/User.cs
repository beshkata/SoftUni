using SharedTrip.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Data.Models
{
    public class User
    {
        public User()
        {
            UserTrips = new HashSet<UserTrip>();
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.UserUsernameMaxLength)]
        public string Username { get; set; }

        [Required]
        [StringLength(GlobalConstants.UserEmailMaxLength)]
        public string Email { get; set; }

        [Required]
        [StringLength(GlobalConstants.UserPasswordHashlMaxLength)]
        public string Password { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; }
    }
}

