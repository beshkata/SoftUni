#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MountainGuide.Infrastructure.Data.Models
{
    using static DataConstant.AssociationManager;
    public class AssociationManager
    {
        [Key]
        [StringLength(IdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(NameMaxLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(IdMaxLength)]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public User User { get; set; }

        [ForeignKey(nameof(TouristAssociation))]
        public int TouristAssociationId { get; set; }

        public TouristAssociation TouristAssociation { get; set; }
    }
}