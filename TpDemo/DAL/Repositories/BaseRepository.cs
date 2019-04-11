using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TpDemo.DAL.EFContext;

namespace TpDemo.DAL.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext dbContext;

        public BaseRepository(AppDbContext context)
        {
            dbContext = context;
        }
    }
}
