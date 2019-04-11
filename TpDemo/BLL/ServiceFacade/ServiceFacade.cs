using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpDemo.BLL.TourCatalogueService;
using TpDemo.BLL.TourEditService;

namespace TpDemo.BLL.ServiceFacade
{
    public class ServiceFacade
    {
        public readonly ITourCatalogueService tourCatalogueService;
        public readonly ITourEditService tourEditService;

        public ServiceFacade(ITourCatalogueService tourCatalogueService ,ITourEditService tourEditService)
        {
            this.tourCatalogueService = tourCatalogueService;
            this.tourEditService = tourEditService;
        }


    }
}
