using OnlineShopWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopWebAPI.Core.Repositories
{
    interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(int id);
        void Delete(int id);
    }
}
