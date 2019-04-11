using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpDemo.BLL.DTO;
using TpDemo.BLL.TourCatalogueService.SearchOptions;

namespace TpDemo.BLL.TourCatalogueService
{
    public interface ITourCatalogueService
    {
        Task<List<TourDTO>> ShowAllToursAsync();
        Task<List<TourDTO>> ShowFilteredToursAsync(TourSearchModel tourSearchModel);
        //void SetModel(TourSearchModel model);
        //TourSearchModel SearchModel { get; set; }
    }
}
