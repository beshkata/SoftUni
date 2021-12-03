using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;
using VaporStore.Common;

namespace VaporStore.DataProcessor.Dto.Import
{
    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {

        [XmlAttribute("title")]
        [Required]
        public string GameTitle { get; set; }

        [XmlElement("Type")]
        [Required]
        public string Type { get; set; }

        [XmlElement("Key")]
        [Required]
        [RegularExpression(GlobalConstants.PurchaseProductKeyRegex)]
        [MaxLength(GlobalConstants.PurchaseProductKeyMaxLength)]
        public string ProductKey { get; set; }

        [XmlElement("Date")]
        [Required]
        public string Date { get; set; }

        [XmlElement("Card")]
        [Required]
        [RegularExpression(GlobalConstants.CardNumberRegex)]
        [MaxLength(GlobalConstants.CardNumberMaxLength)]
        public string CardNumber { get; set; }
    }
}
