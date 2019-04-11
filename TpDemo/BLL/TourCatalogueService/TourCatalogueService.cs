using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpDemo.BLL.DTO;
using TpDemo.DAL.UnitOfWork;
using AutoMapper;
using TpDemo.DAL.Entities;
using TpDemo.BLL.TourCatalogueService.SearchOptions;

namespace TpDemo.BLL.TourCatalogueService
{
    public class TourCatalogueService : ITourCatalogueService
    {
        private readonly IUnitOfWork database;
        private readonly IMapper mapper;
        //public TourSearchModel SearchModel { get; set; }

        public TourCatalogueService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            database = unitOfWork;
        }

        public async Task<List<TourDTO>> ShowAllToursAsync()
        {
            var result = await mapper.Map<Task<IEnumerable<Tour>>, Task<IEnumerable<TourDTO>>>(database.Tours.GetAllAsync());
            return (List<TourDTO>)result;
        }

        public async Task<List<TourDTO>> ShowFilteredToursAsync(TourSearchModel SearchModel)
        {
            
            var result = await database.Tours.GetAllAsync();
            if (SearchModel != null)
            {
                result.AsQueryable();

                if (!string.IsNullOrEmpty(SearchModel.CountryNames))
                    result = result.Where(t => t.CountryNames == SearchModel.CountryNames);
                if (SearchModel.HotTour.HasValue)
                    result = result.Where(t => t.HotTour == SearchModel.HotTour);
            }
            return mapper.Map<IEnumerable<Tour>, List<TourDTO>>(result);
            
        }
    }
}
