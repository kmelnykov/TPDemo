using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpDemo.DAL.EFContext;
using TpDemo.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace TpDemo.DAL.Repositories
{
    public class UserRepository : BaseRepository, IRepository<User>
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await dbContext.Users
                                  .Include(u => u.Role) 
                                  .ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
        }

        public async Task<User> GetAsync(int id)
        {
            return await dbContext.Users
                                  .Include(u => u.Role)
                                  .FirstOrDefaultAsync(u => u.Id == id);
        }

        public void Update(User user)
        {
            dbContext.Users.Update(user);
        }

        public void Remove(User user)
        {
            dbContext.Users.Remove(user);
        }
    }
}
