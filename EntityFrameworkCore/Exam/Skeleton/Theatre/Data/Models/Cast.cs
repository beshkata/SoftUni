using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Theatre.Common;

namespace Theatre.Data.Models
{
    public class Cast
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CastFullNameMaxLength)]
        public string FullName { get; set; }

        public bool IsMainCharacter { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CastPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [ForeignKey(nameof(Play))]
        public int PlayId { get; set; }

        public Play Play { get; set; }
    }
}
