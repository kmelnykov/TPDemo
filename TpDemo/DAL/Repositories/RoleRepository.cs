using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpDemo.DAL.Entities;
using TpDemo.DAL.EFContext;
using Microsoft.EntityFrameworkCore;

namespace TpDemo.DAL.Repositories
{
    public class RoleRepository :BaseRepository, IRepository<Role>
    {
        public RoleRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await dbContext.Roles
                                  .Include(r => r.Users)
                                  .ToListAsync();
        }

        public async Task AddAsync(Role role)
        {
            await dbContext.Roles.AddAsync(role);   
        }

        public async Task<Role> GetAsync(int id)
        {
            return await dbContext.Roles.FindAsync(id);
        }

        public void Update(Role role)
        {
            dbContext.Roles.Update(role);
        }

        public void Remove(Role role)
        {
            dbContext.Roles.Remove(role);
        }
    }
}
