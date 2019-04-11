using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpDemo.DAL.Repositories;
using TpDemo.DAL.Entities;

namespace TpDemo.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        IRepository<Tour> Tours { get; }
        IRepository<TourBooking> TourBookings { get; }
        
        Task CompleteAsync();
    }
}
