using Microsoft.EntityFrameworkCore;
using OnlineShopWebAPI.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Delete(T item)
        {
            Context.Set<T>().Remove(item);
        }
    }
}
