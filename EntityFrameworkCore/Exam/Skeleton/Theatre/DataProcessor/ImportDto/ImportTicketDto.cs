using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTicketDto
    {
        [Required]
        [Range(GlobalConstants.TicketPriceMinValue, GlobalConstants.TicketPriceMaxValue)]
        public decimal Price { get; set; }

        [Required]
        [Range(GlobalConstants.TicketRowNumberMinValue, GlobalConstants.TicketRowNumberMaxValue)]
        public sbyte RowNumber { get; set; }

        [Required]
        public int PlayId { get; set; }
    }
}
