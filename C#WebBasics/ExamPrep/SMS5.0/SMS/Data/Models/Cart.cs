using SMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Data.Models
{
    public class Cart
    {
        [Key]
        [MaxLength(GlobalConstants.GuidMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        //[Required]
        //[MaxLength(GlobalConstants.GuidMaxLength)]
        //[ForeignKey(nameof(User))]
        //public string UserId { get; set; }

        //public User User { get; set; }

        //public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
