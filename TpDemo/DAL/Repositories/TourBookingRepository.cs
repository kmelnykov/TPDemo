using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpDemo.DAL.EFContext;
using TpDemo.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace TpDemo.DAL.Repositories
{
    public class TourBookingRepository : BaseRepository, IRepository<TourBooking>
    {
        public TourBookingRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<TourBooking>> GetAllAsync()
        {
            return await dbContext.TourBookings
                                  .Include(t => t.Tour)
                                  .Include(t => t.User)
                                  .ToListAsync();
        }

        public async Task AddAsync(TourBooking tourBooking)
        {
            await dbContext.TourBookings.AddAsync(tourBooking);
        }

        public async Task<TourBooking> GetAsync(int id)
        {
            return await dbContext.TourBookings
                                  .Include(t => t.Tour)
                                  .Include(t => t.User)
                                  .FirstOrDefaultAsync(t => t.Id == id);
        }

        public void Update(TourBooking tourBooking)
        {
            dbContext.TourBookings.Update(tourBooking);
        }

        public void Remove(TourBooking tourBooking)
        {
            dbContext.TourBookings.Remove(tourBooking);
        }
    }
}
