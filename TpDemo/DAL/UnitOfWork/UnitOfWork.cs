using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpDemo.DAL.Entities;
using TpDemo.DAL.EFContext;
using TpDemo.DAL.Repositories;

namespace TpDemo.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        private  UserRepository userRepository;
        private RoleRepository roleRepository;
        private TourRepository tourRepository;
        private TourBookingRepository tourBookingRepository;


        public UnitOfWork(AppDbContext context)
        {
            dbContext = context;
        }
        
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(dbContext);
                return userRepository;
            }
        }

        public IRepository<Role> Roles
        {
            get
            {
                if (roleRepository == null)
                    roleRepository = new RoleRepository(dbContext);
                return roleRepository;
            }
        }

        public IRepository<Tour> Tours
        {
            get
            {
                if (tourRepository == null)
                    tourRepository = new TourRepository(dbContext);
                return tourRepository;
            }
        }

        public IRepository<TourBooking> TourBookings
        {
            get
            {
                if (tourBookingRepository == null)
                    tourBookingRepository = new TourBookingRepository(dbContext);
                return tourBookingRepository;
            }
        }

        public async Task CompleteAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
