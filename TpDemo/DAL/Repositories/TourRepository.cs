using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpDemo.DAL.EFContext;
using TpDemo.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace TpDemo.DAL.Repositories
{
    public class TourRepository : BaseRepository, IRepository<Tour>
    {
        public TourRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Tour>> GetAllAsync()
        {
            return await dbContext.Tours.ToListAsync();
        }

        public async Task AddAsync(Tour tour)
        {
            await dbContext.Tours.AddAsync(tour);
        }

        public async Task<Tour> GetAsync(int id)
        {
            return await dbContext.Tours.FindAsync(id);
        }

        public void Update(Tour tour)
        {
            dbContext.Tours.Update(tour);
        }

        public void Remove(Tour tour)
        {
            dbContext.Tours.Remove(tour);
        }    
    }
}
