using SMS.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SMS.Data.Models
{
    public class Product
    {
        [Key]
        [MaxLength(GlobalConstants.GuidMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(GlobalConstants.ProductNameMaxLength)]
        public string Name { get; set; }

        public decimal Price { get; set; }

        [ForeignKey(nameof(Cart))]
        public string CartId { get; set; }

        public Cart Cart { get; set; }
    }
 }
