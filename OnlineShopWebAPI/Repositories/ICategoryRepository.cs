using OnlineShopWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Core.Repositories
{
    interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<Category> GetAll();
        Category GetById(int id);
        void Add(int id);
        void Delete(int id);
    }
}
