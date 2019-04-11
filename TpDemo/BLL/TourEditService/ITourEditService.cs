using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpDemo.BLL.DTO;


namespace TpDemo.BLL.TourEditService
{
    public interface ITourEditService
    {
        Task AddTourAsync(TourDTO tourDTO);
        Task EditTourAsync(int id, TourDTO tourDTO);
        Task RemoveTourAsync(int id);
    }
}
