using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TpDemo.BLL.TourCatalogueService.SearchOptions
{
    public class TourSearchModel
    {
        public string CountryNames { get; set; }
        public bool? HotTour { get; set; }
        public int? PriceFrom { get; set; }
        public int? PriceTo { get; set; }
        //public DateTime? DateFrom { get; set; }
        //public DateTime? DateTo { get; set; }

    }
}
