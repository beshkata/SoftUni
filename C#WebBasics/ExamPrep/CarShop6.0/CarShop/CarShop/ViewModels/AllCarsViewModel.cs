using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class AllCarsViewModel
    {
        public string CarId { get; set; }
        public string PictureUrl { get; set; }

        public string Model { get; set; }

        public string PlateNumber { get; set; }

        public int RemainingIssues { get; set; }

        public int FixedIssues { get; set; }
    }
}
