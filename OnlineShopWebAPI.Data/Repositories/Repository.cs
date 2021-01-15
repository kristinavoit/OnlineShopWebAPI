using Microsoft.EntityFrameworkCore;
using OnlineShopWebAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopWebAPI.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }
        public void Add(T item)
        {
            Context.Set<T>().Add(item);
        }
        public void Update(T item)
        {
            Context.Set<T>().Update(item);
            Context.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public void Delete(T item)
        {
            Context.Set<T>().Remove(item);
        }
    }
}
