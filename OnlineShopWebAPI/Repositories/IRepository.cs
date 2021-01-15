using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopWebAPI.Core.Repositories
{
    public interface IRepository<T> where T : class
        {
            Task<IEnumerable<T>> GetAllAsync();
            Task<T> GetById(int id);
            void Add(T item);
            void Update(T item);
            void Delete(T item);
        }
}
