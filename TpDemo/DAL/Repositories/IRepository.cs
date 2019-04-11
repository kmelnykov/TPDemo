using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TpDemo.DAL.Repositories
{
    public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T item);
        Task<T> GetAsync(int id);
        void Update(T item);
        void Remove(T item);
    }
}
