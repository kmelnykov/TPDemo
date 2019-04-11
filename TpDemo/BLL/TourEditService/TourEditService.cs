using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpDemo.BLL.DTO;
using TpDemo.DAL.UnitOfWork;
using TpDemo.DAL.Entities;
using AutoMapper;

namespace TpDemo.BLL.TourEditService
{
    public class TourEditService : ITourEditService
    {
        private readonly IUnitOfWork dataBase;
        private readonly IMapper mapper;

        public TourEditService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            dataBase = unitOfWork;
            this.mapper = mapper;
        }

        public async Task AddTourAsync(TourDTO tourDTO)
        {
            var tour = mapper.Map<TourDTO, Tour>(tourDTO);
            await dataBase.Tours.AddAsync(tour);

            await dataBase.CompleteAsync();
        }

        public async Task EditTourAsync(int id, TourDTO tourDTO)
        {
            //Check for nullRefExc
            //if
            //var tour = await dataBase.Tours.GetAsync(id);
            //else  
            var editedTour = mapper.Map<TourDTO, Tour>(tourDTO);
            dataBase.Tours.Update(editedTour);

            await dataBase.CompleteAsync();
        }

        public async Task RemoveTourAsync(int id)
        {
            //Check for nullRefExc
            //if
            var tour = await dataBase.Tours.GetAsync(id);
            dataBase.Tours.Remove(tour);

            await dataBase.CompleteAsync();
        }
    }
}
