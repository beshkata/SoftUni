using System.ComponentModel.DataAnnotations;
using VaporStore.Common;

namespace VaporStore.DataProcessor.Dto.Import
{
    public class ImportCardDto
    {
        [Required]
        [RegularExpression(GlobalConstants.CardNumberRegex)]
        public string Number { get; set; }

        [Required]
        [RegularExpression(GlobalConstants.CardCvcRegex)]
        public string Cvc { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
