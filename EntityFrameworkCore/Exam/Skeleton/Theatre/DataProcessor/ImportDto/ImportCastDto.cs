using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class ImportCastDto
    {
        [XmlElement("FullName")]
        [Required]
        [MaxLength(GlobalConstants.CastFullNameMaxLength)]
        [MinLength(GlobalConstants.CastFullNameMinLength)]
        public string FullName { get; set; }

        [XmlElement("IsMainCharacter")]
        [Required]
        public bool IsMainCharacter { get; set; }

        [XmlElement("PhoneNumber")]
        [MaxLength(GlobalConstants.CastPhoneNumberMaxLength)]
        [RegularExpression(GlobalConstants.CastPhoneNumberRegex)]
        [Required]
        public string PhoneNumber { get; set; }

        [XmlElement("PlayId")]
        [Required]
        public int PlayId { get; set; }
    }
}
