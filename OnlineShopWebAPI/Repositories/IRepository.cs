using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Core.Repositories
{
    public interface IRepository<T> where T : class
        {
            IEnumerable<T> GetAll();
            T GetById(int id);
            void Add(T item);
            void Update(T item);
            void Delete(T item);
        }
}
