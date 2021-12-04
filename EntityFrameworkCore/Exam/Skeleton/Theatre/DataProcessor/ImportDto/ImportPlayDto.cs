using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlayDto
    {
        [XmlElement("Title")]
        [MinLength(GlobalConstants.PlayTitleMinLength)]
        [MaxLength(GlobalConstants.PlayTitleMaxLength)]
        [Required]
        public string Title { get; set; }

        [XmlElement("Duration")]
        [Required]
        public string Duration { get; set; }

        [XmlElement("Rating")]
        [Range(GlobalConstants.PlayRaitingMinValue, GlobalConstants.PlayRaitingMaxValue)]
        public float Rating { get; set; }

        [XmlElement("Genre")]
        [Required]
        public string Genre { get; set; }

        [XmlElement("Description")]
        [MaxLength(GlobalConstants.PlayDescriptionMaxLength)]
        [Required]
        public string Description { get; set; }

        [XmlElement("Screenwriter")]
        [Required]
        [MaxLength(GlobalConstants.PlayScreenwriterMaxLength)]
        [MinLength(GlobalConstants.PlayScreenwriterMinLength)]
        public string Screenwriter { get; set; }
    }
}
